using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WTnote
{
    public partial class EditPlanesForm : Form
    {
        public List<string> Planes { get; set; }

        public EditPlanesForm(List<string> planes)
        {
            InitializeComponent();
            Planes = planes;
            ShowItemsInListbox();
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbPlaneName.Text.Trim().Length < 1) return;

            Planes.Add(tbPlaneName.Text.Trim());

            ShowItemsInListbox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbPlanes.SelectedIndex < 0) return;

            Planes.RemoveAt(lbPlanes.SelectedIndex);

            ShowItemsInListbox();
        }

        private void ShowItemsInListbox()
        {
            TakeOutDuplicates();
            lbPlanes.BeginUpdate();

            lbPlanes.Items.Clear();
            foreach (var s in Planes)
            {
                lbPlanes.Items.Add(s);
            }

            lbPlanes.EndUpdate();
        }

        private void TakeOutDuplicates()
        {
            var list = Planes.Select(x => x).Distinct();
            Planes = list.OrderBy(x => x).ToList();
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            var listForm = new ListForm();
            var dialogResult = listForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                Planes.AddRange(listForm.Result);
            }

            ShowItemsInListbox();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var editForm = new EditStringForm(Planes[lbPlanes.SelectedIndex]);
            var dialogResult = editForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                Planes[lbPlanes.SelectedIndex] = editForm.EditedString;
            }

            ShowItemsInListbox();
        }
    }
}
