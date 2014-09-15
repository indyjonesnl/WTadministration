using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WTnote
{
    public partial class ListForm : Form
    {
        public List<string> Result { get; set; }

        public ListForm()
        {
            InitializeComponent();
            Result = new List<string>();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbInput.Text.Trim().Length > 0)
            {
                //var splitStrings = new [] {',', ' ', '\n'};
                var stringArray = tbInput.Text.Trim().Split('\n');
                Result = stringArray.ToList();

                DialogResult = DialogResult.OK;
            }
            Close();
        }
    }
}
