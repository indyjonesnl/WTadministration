using System;
using System.Windows.Forms;

namespace WTnote
{
    public partial class EditStringForm : Form
    {
        public string EditedString { get; set; }

        public EditStringForm(string editString)
        {
            InitializeComponent();
            EditedString = editString;
            tbString.Text = EditedString;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbString.Text.Trim().Length > 0)
            {
                EditedString = tbString.Text;
                DialogResult = DialogResult.OK;
            }
            Close();
        }
    }
}
