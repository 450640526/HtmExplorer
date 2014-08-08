using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace CommonControl
{
    public class AddressButtonClass:ImageButton
    {
        public AddressButtonClass()
        {

        }


        //#region CreateButtons


        //public void DisposeButtons()
        //{
        //    try
        //    {
        //        //btn.Dispose();
        //        for (int i = 0; i < btns.Length; i++)
        //        {
        //            btns[i].Dispose();
        //        }
        //    }
        //    catch { }

        //}

        //private Color bgbBkColor = SystemColors.Control;
        //private double position = 0;
        //private double max = 100;
        //public string workpath = "";
        //public string btnsPath = "";
        //public string currentPath = "";
        //private ImageButton[] btns;
        //private ImageButton btn;
        //public void CreateButtons(string s)
        //{
        //    currentPath = s;
        //    //buttons
        //    //ICON1.Visible = true;
        //    string[] arr = s.Split(new string[] { "\\", }, StringSplitOptions.None);
        //    string s1 = "";

        //    btns = new ImageButton[arr.Length];
        //    //  释放按钮
        //    DisposeButtons();


        //    int LEFT = 24;
        //    int TOP = 2;

        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        string name = string.Format("{0}", arr[i]);
        //        string path = string.Format("\\{0}", arr[i]);
        //        s1 += path;

        //        btn = new ImageButton();
        //        btn.Font = new Drawing.Font("微软雅黑", 9F);
        //        btn.Text = name;
        //        btn.Tag = s1.Remove(0, 1) + "\\";
        //        btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //        btn.BackColor = Color.Transparent;
        //        btn.Parent = pictureBox1;
        //        btn.Height = pictureBox1.ClientRectangle.Height;

        //        if (IsUserPath(btn))
        //        {
        //            btn.BorderColor = Color.Transparent;
        //            btn.MouseDownColor = Color.Transparent;
        //            btn.MouseEnterColor = Color.Transparent;
        //        }
        //        else
        //        {
        //            //label.BorderColor = Color.FromArgb(102, 167, 232);
        //            btn.MouseDownColor = Color.FromArgb(209, 232, 255);
        //            btn.MouseEnterColor = Color.FromArgb(229, 243, 251);
        //        }


        //        Size size = TextRenderer.MeasureText(name, btn.Font);

        //        btn.Width = size.Width;
        //        btn.Height -= 5;

        //        btn.Location = new Point(LEFT, TOP);
        //        LEFT += size.Width;

        //        btn.BringToFront();
        //        btn.Click += new System.EventHandler(btn_Click);
        //        btn.MouseLeave += new System.EventHandler(btn_MouseLeave);
        //        btn.MouseEnter += new System.EventHandler(btn_MouseEnter);

        //        btns[i] = btn;
        //        btn.Refresh();
        //    }

        //    LEFT = 24;
        //}

        //public void AddPathToListBox(string path)
        //{
        //    int index = listBox1.Items.IndexOf(path);
        //    if (index == -1)
        //    {
        //        listBox1.Items.Add(path);
        //        //imageList2
        //        if (!listBox1.Focused)
        //            listBox1.SelectedItem = listBox1.Items[listBox1.Items.Count - 1];
        //    }
        //    else
        //    {
        //        if (!listBox1.Focused)
        //            listBox1.SelectedItem = listBox1.Items[index];
        //    }
        //}
        //private bool IsUserPath(ImageButton imageButton)
        //{
        //    return (workpath.IndexOf(imageButton.Tag.ToString()) != -1);
        //}

        //#endregion

        //#region Label Events
        //private void btn_Click(object sender, EventArgs e)
        //{
        //    ImageButton btn = ((ImageButton)sender);
        //    btnsPath = btn.Tag.ToString();

        //    if (!IsUserPath(btn))
        //    {
        //        OnButtonsClick(sender, e);

        //        DisposeButtons();
        //        CreateButtons(btn.Tag.ToString());
        //    }
        //}

        //private void btn_MouseEnter(object sender, EventArgs e)
        //{
        //    ImageButton btn = ((ImageButton)sender);

        //    if (!IsUserPath(btn))
        //        btn.BorderColor = Color.FromArgb(102, 167, 232);
        //    else
        //        btn.BorderColor = Color.Transparent;
        //}

        //private void btn_MouseLeave(object sender, EventArgs e)
        //{
        //    ImageButton btn = ((ImageButton)sender);
        //    btn.BorderColor = Color.Transparent;
        //}




        //#endregion

    }
}
