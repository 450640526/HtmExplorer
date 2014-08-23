

//2014年7月2日22:29:29 
//功能
//本代码是在Syed Umar Anis的
//http://www.codeproject.com/Articles/13099/Loading-and-Saving-a-TreeView-control-to-an-XML-fi
//这个代码的基础上进行了修改并增加了能恢复TREEVIEW的展开的状态 和选中最后选择的一项

//1 用XML保存和读取TREE VIEW的状态
//2 将一个XML文件加载到TREEVIEW中

//使用
//private void buttonLoad_Click(object sender, EventArgs e)
//     {
//         treeView1.Focus();
//         string xmlFileName = "TreeView.xml";
//         if (System.IO.File.Exists(xmlFileName))
//         {
//             WindowsForms.XmlTreeViewState TreeState = new WindowsForms.XmlTreeViewState();
//             TreeState.LoadXml(treeView1, xmlFileName);
//         }
//     }

//     private void buttonSave_Click(object sender, EventArgs e)
//     {
//         string xmlFileName = "TreeView.xml";
//         WindowsForms.XmlTreeViewState TreeState = new WindowsForms.XmlTreeViewState();
//         TreeState.SaveXml(treeView1, xmlFileName);
//     }

//     private void Form1_Load(object sender, EventArgs e)
//     {
//         treeView1.HideSelection = false;
//     }

namespace System
{
    using System.Xml;
    using System.Windows.Forms;
    using System.Text;


    public class XmlTreeView
    {

        #region const...
        private const string XmlNodeTag = "Node";

        /*
         *  <TreeView>
         *     <node  text = "节点1" imageindex = "0" expland = "true" lastselect = "false">
         *        <node  text = "节点2" imageindex = "-1" expland = "true" lastselect = "false"></node>
         *     </node>
         *  </TreeView>
        */
        private const string XmlNodeTextAtt = "Text";
        private const string XmlNodeTagAtt = "Tag";
        private const string XmlNodeImageIndexAtt = "ImageIndex";
        private const string XmlNodeExpandState = "Expland";//展开状态
        private const string XmlNodeIsSelect = "LastSelect";//最后选中的项
        private const string XmlNodeIndex = "Index";//当前TreeView索引 
        #endregion

        #region 保存TREEVIEW状态
        /// <summary>
        /// 保存TREEVIEW状态
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="fileName"></param>
        public static void SaveXml(TreeView treeView, string fileName)
        {
            //TreeNode node
            XmlTextWriter textWriter = new XmlTextWriter(fileName, System.Text.Encoding.Unicode);
            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("TreeView");
            SaveXmlNodes(treeView.Nodes, textWriter);
            textWriter.WriteEndElement();
            textWriter.Close();
        }
        #endregion

        #region 读取TreeView状态
        /// <summary>
        /// 恢复TREEVIEW最后一次选中的节点状态 和展开的状态和图标
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="fileName"></param>
        public static bool LoadXml(TreeView treeView, string fileName)
        {
            bool working = true;

            XmlTextReader reader = null;
            try
            {
                treeView.Nodes.Clear();
                // disabling re-drawing of treeview till all nodes are added
                treeView.BeginUpdate();
                reader = new XmlTextReader(fileName);


                TreeNode parentNode = null;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == XmlNodeTag)
                        {
                            TreeNode newNode = new TreeNode();
                            bool isEmptyElement = reader.IsEmptyElement;

                            // loading node attributes
                            int attributeCount = reader.AttributeCount;
                            if (attributeCount > 0)
                            {
                                for (int i = 0; i < attributeCount; i++)
                                {
                                    reader.MoveToAttribute(i);
                                    SetAttributeValue(newNode, reader.Name, reader.Value);
                                    SetTreeViewState(treeView);
                                }
                            }

                            // add new node to Parent Node or TreeView
                            if (parentNode != null)
                                parentNode.Nodes.Add(newNode);
                            else
                                treeView.Nodes.Add(newNode);

                            // making current node 'ParentNode' if its not empty
                            if (!isEmptyElement)
                            {
                                parentNode = newNode;
                            }
                        }
                    }
                    // moving up to in TreeView if end tag is encountered
                    else if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        if (reader.Name == XmlNodeTag)
                        {
                            parentNode = parentNode.Parent;
                        }
                    }
                    else if (reader.NodeType == XmlNodeType.XmlDeclaration)
                    { //Ignore Xml Declaration                    
                    }
                    else if (reader.NodeType == XmlNodeType.None)
                    {
                        working = false;
                    }
                    else if (reader.NodeType == XmlNodeType.Text)
                    {
                        parentNode.Nodes.Add(reader.Value);
                    }
                    working = false;
                }
                working = false;
            }
            finally
            {
                treeView.EndUpdate();
                reader.Close();
                working = false;
            }
            working = false;

            return working;
        }

        #endregion




        #region 设置 展开后的节点 最后选中的节点


        // Expland LastSelect
        private static void SetTreeViewState(TreeView treeView)
        {
            treeView.SelectedNode = ExpandNode;
            //Expland
            if (ExpandNode != null)
                ExpandNode.Expand();

            //Select
            if (LastSelectNode != null)
                treeView.SelectedNode = LastSelectNode;
        }
        #endregion

        #region 保存XML节点
        private static void SaveXmlNodes(TreeNodeCollection nodesCollection, XmlTextWriter textWriter)
        {
            for (int i = 0; i < nodesCollection.Count; i++)
            {
                TreeNode node = nodesCollection[i];
                textWriter.WriteStartElement(XmlNodeTag);// "node";

                textWriter.WriteAttributeString(XmlNodeTextAtt, node.Text);// "text";
                textWriter.WriteAttributeString(XmlNodeImageIndexAtt, node.ImageIndex.ToString());//"imageindex";

                if (node.IsExpanded == true)
                    textWriter.WriteAttributeString(XmlNodeExpandState, node.IsExpanded.ToString());////展开状态

                if (node.IsSelected)
                    textWriter.WriteAttributeString(XmlNodeIsSelect, node.IsSelected.ToString());//是否选中

                if (node.Tag != null)
                    textWriter.WriteAttributeString(XmlNodeTagAtt, node.Tag.ToString());

                textWriter.WriteAttributeString(XmlNodeIndex, node.Index.ToString());//Index

                // add other node properties to serialize here

                if (node.Nodes.Count > 0)
                {
                    SaveXmlNodes(node.Nodes, textWriter);
                }
                textWriter.WriteEndElement();
            }
        }
        #endregion

        #region 设置XML属性
        private static void SetAttributeValue(TreeNode node, string propertyName, string value)
        {
            if (propertyName == XmlNodeTextAtt) //text
            {
                node.Text = value;
            }
            else if (propertyName == XmlNodeImageIndexAtt) //ImageIndex
            {
                node.ImageIndex = int.Parse(value);
            }
            else if (propertyName == XmlNodeExpandState)
            {
                ExpandNode = node;
            }
            else if (propertyName == XmlNodeIsSelect)
            {
                LastSelectNode = node;
            }
            else if (propertyName == XmlNodeTagAtt)//tag
            {
                node.Tag = value;
            }
            else if (propertyName == XmlNodeIndex)
            {
               // 用来标识 这样看XML文件时结构清晰
            }
        }
        #endregion

        #region 把XML文件读取到TREE中
        /// <summary>
        /// 把XML文件读取到TREE中
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="fileName"></param>
        public static void LoadXmlFile(TreeView treeView, string fileName)
        {
            XmlTextReader reader = null;
            try
            {
                treeView.BeginUpdate();
                reader = new XmlTextReader(fileName);

                TreeNode n = new TreeNode(fileName);
                treeView.Nodes.Add(n);
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        bool isEmptyElement = reader.IsEmptyElement;
                        StringBuilder text = new StringBuilder();
                        text.Append(reader.Name);
                        int attributeCount = reader.AttributeCount;
                        if (attributeCount > 0)
                        {
                            text.Append(" ( ");
                            for (int i = 0; i < attributeCount; i++)
                            {
                                if (i != 0) text.Append(", ");
                                reader.MoveToAttribute(i);
                                text.Append(reader.Name);
                                text.Append(" = ");
                                text.Append(reader.Value);
                            }
                            text.Append(" ) ");
                        }

                        if (isEmptyElement)
                        {
                            n.Nodes.Add(text.ToString());
                        }
                        else
                        {
                            n = n.Nodes.Add(text.ToString());
                        }
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        n = n.Parent;
                    }
                    else if (reader.NodeType == XmlNodeType.XmlDeclaration)
                    {

                    }
                    else if (reader.NodeType == XmlNodeType.None)
                    {
                        return;
                    }
                    else if (reader.NodeType == XmlNodeType.Text)
                    {
                        n.Nodes.Add(reader.Value);
                    }

                }
            }
            finally
            {
                treeView.EndUpdate();
                reader.Close();
            }
        }
        #endregion




        private static TreeNode LastSelectNode = null;//最后选中的节点
        private static TreeNode ExpandNode = null;//展开后的节点
    }
}
