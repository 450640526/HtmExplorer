using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.Forms
{
    //http://stackoverflow.com/questions/1214289/how-do-i-sort-integers-in-a-listview
    public class ListItemsSorter : System.Collections.IComparer
    {
        public int Column = 0;
        public System.Windows.Forms.SortOrder Order = SortOrder.Ascending;
        public int Compare(object x, object y) // IComparer Member
        {
            if (!(x is ListViewItem))
                return (0);
            if (!(y is ListViewItem))
                return (0);

            ListViewItem listviewitem1 = (ListViewItem)x;
            ListViewItem listviewitem2 = (ListViewItem)y;

            if (listviewitem1.ListView.Columns[Column].Tag == null)
            {
                listviewitem1.ListView.Columns[Column].Tag = "Text";
            }

            //number compare
            if (listviewitem1.ListView.Columns[Column].Tag.ToString() == "Number")
            {
                float f1 = float.Parse(listviewitem1.SubItems[Column].Text);
                float f2 = float.Parse(listviewitem2.SubItems[Column].Text);

                if (Order == SortOrder.Ascending)
                {
                    return f1.CompareTo(f2);
                }
                else
                {
                    return f2.CompareTo(f1);
                }
            }
            else
            {

                //string compare
                string str1 = listviewitem1.SubItems[Column].Text;
                string str2 = listviewitem2.SubItems[Column].Text;

                if (Order == SortOrder.Ascending)
                {
                    return str1.CompareTo(str2);
                }
                else
                {
                    return str2.CompareTo(str1);
                }
            }
        }
    }
}
