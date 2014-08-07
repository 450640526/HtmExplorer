using System.Runtime.InteropServices;
using ShellBasics;

namespace System
{
    public class ShellFileOperation
    {
        public ShellFileOperation()
        {
            // set default properties
            Operation = FileOperations.FO_COPY;
            OwnerWindow = IntPtr.Zero;
            OperationFlags = ShellFileOperationFlags.FOF_ALLOWUNDO
                | ShellFileOperationFlags.FOF_MULTIDESTFILES
                | ShellFileOperationFlags.FOF_NO_CONNECTED_ELEMENTS
                | ShellFileOperationFlags.FOF_WANTNUKEWARNING;
            ProgressTitle = "";

            NameMappings = null;
        }

        public bool DoOperation()
        {
            ShellApi.SHFILEOPSTRUCT FileOpStruct = new ShellApi.SHFILEOPSTRUCT();

            FileOpStruct.hwnd = OwnerWindow;
            FileOpStruct.wFunc = (uint)Operation;

            String multiSource = StringArrayToMultiString(SourceFiles);
            String multiDest = StringArrayToMultiString(DestFiles);
            FileOpStruct.pFrom = Marshal.StringToHGlobalUni(multiSource);
            FileOpStruct.pTo = Marshal.StringToHGlobalUni(multiDest);

            FileOpStruct.fFlags = (ushort)OperationFlags;
            FileOpStruct.lpszProgressTitle = ProgressTitle;
            FileOpStruct.fAnyOperationsAborted = 0;
            FileOpStruct.hNameMappings = IntPtr.Zero;
            this.NameMappings = new ShellNameMapping[0];

            int RetVal;
            RetVal = ShellApi.SHFileOperation(ref FileOpStruct);

            ShellApi.SHChangeNotify(
                (uint)ShellChangeNotificationEvents.SHCNE_ALLEVENTS,
                (uint)ShellChangeNotificationFlags.SHCNF_DWORD,
                IntPtr.Zero,
                IntPtr.Zero);

            if (RetVal != 0)
                return false;

            if (FileOpStruct.fAnyOperationsAborted != 0)
                return false;

            // Newly added on 2007/08/29 to make hNameMappings work
            if (FileOpStruct.hNameMappings != IntPtr.Zero)
            {
                // Get MappingTable
                ShellApi.SHNAMEMAPPINGINDEXSTRUCT mappingIndex = (ShellApi.SHNAMEMAPPINGINDEXSTRUCT)Marshal.PtrToStructure(
                    FileOpStruct.hNameMappings,
                    typeof(ShellApi.SHNAMEMAPPINGINDEXSTRUCT));

                // Prepare array
                this.NameMappings = new ShellNameMapping[mappingIndex.counter];

                // Set pointer to first mapping struct
                IntPtr mover = mappingIndex.firstMappingStruct;
                for (int i = 0; i < mappingIndex.counter; i++)
                {
                    ShellApi.SHNAMEMAPPINGSTRUCT oneNameMappingStruct =
                        (ShellApi.SHNAMEMAPPINGSTRUCT)Marshal.PtrToStructure(mover, typeof(ShellApi.SHNAMEMAPPINGSTRUCT));
                        
                    this.NameMappings[i] = new ShellNameMapping(oneNameMappingStruct.pszOldPath, oneNameMappingStruct.pszNewPath);

                    // move pointer to the next mapping struct 
                    mover = (IntPtr)((int)mover + Marshal.SizeOf(typeof(ShellApi.SHNAMEMAPPINGSTRUCT)));
                }

                // Free NameMappings in memory
                ShellApi.SHFreeNameMappings(FileOpStruct.hNameMappings);
            }

            return true;
        }

        private static String StringArrayToMultiString(String[] stringArray)
        {
            String multiString = "";

            if (stringArray == null)
                return "";

            for (int i = 0; i < stringArray.Length; i++)
                multiString += stringArray[i] + '\0';

            multiString += '\0';

            return multiString;
        }

        // properties
        public FileOperations Operation;
        public IntPtr OwnerWindow;
        public ShellFileOperationFlags OperationFlags;
        public String ProgressTitle;
        public String[] SourceFiles;
        public String[] DestFiles;
        public ShellNameMapping[] NameMappings;
    }
}