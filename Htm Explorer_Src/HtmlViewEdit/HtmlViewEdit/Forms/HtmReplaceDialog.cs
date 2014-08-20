
namespace System.Windows.Forms
{
    using mshtml;
    public partial class HtmReplaceDialog : Form
    {
        HtmEdit htmEdit1;
        public HtmReplaceDialog(HtmEdit htmEdit)
        {
            htmEdit1 = htmEdit;
            InitializeComponent();
        }

        private void SearchDialog_Load(object sender, EventArgs e)
        {
            findText1.Text = htmEdit1.SelectionText;
            htmEdit1.Search(findText1.Text, false, matchWholeWord1.Checked, matchCase1.Checked);
        }

        private void replaceText1_TextChanged(object sender, EventArgs e)
        {
            replace1.Enabled = replaceText1.Text != "";
            replaceAll1.Enabled = replaceText1.Text != "";
        }

        private void findText1_TextChanged(object sender, EventArgs e)
        {
            findNext1.Enabled = findText1.Text != "";
        }

        private void replaceAll1_Click(object sender, EventArgs e)
        {
            icon1.Visible = true;
            tips1.Visible = true;

            int i = 0;
            do
            {
                i++;
                if (i > 1)
                    htmEdit1.SelectionText = replaceText1.Text;
            }
            while (htmEdit1.Search(findText1.Text, true, matchWholeWord1.Checked, matchCase1.Checked));
            tips1.Text = String.Format("���滻��{0}��", i - 1); 
        }

        private void replace1_Click(object sender, EventArgs e)
        {
            htmEdit1.SetSelection(0, 0);
            if (htmEdit1.Search(findText1.Text, true, matchWholeWord1.Checked, matchCase1.Checked))
            {
                icon1.Visible = false;
                tips1.Visible = false;
                //�����滻��ʽ����滻 1Ϊ111�ͻ�����
                htmEdit1.SelectionText = replaceText1.Text;
                htmEdit1.Search(findText1.Text, true, matchWholeWord1.Checked, matchCase1.Checked);
            }
            else
            {
                icon1.Visible = true;
                tips1.Visible = true;
                tips1.Text = "δ�ҵ�ƥ����";        
            }
        }

        private void findNext1_Click(object sender, EventArgs e)
        {
            if (htmEdit1.Search(findText1.Text, true, matchWholeWord1.Checked, matchCase1.Checked))
            {
                icon1.Visible = false;
                tips1.Visible = false;
            }
            else
            {
                icon1.Visible = true;
                tips1.Visible = true;
                tips1.Text = "δ�ҵ�ƥ����";
                htmEdit1.SetSelection(0, 0);
            }
        }

        private void HtmReplaceDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void HtmReplaceDialog_Shown(object sender, EventArgs e)
        {
            findText1.Text = htmEdit1.SelectionText;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}