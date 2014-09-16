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

            if (Planes.Count < 1)
                ResetPlanes();

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
            tbPlaneName.Text = String.Empty;

            ShowItemsInListbox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbPlanes.SelectedIndices.Count < 1) return;

            if (lbPlanes.SelectedIndices.Count > 1)
            {
                var selectedIndices = lbPlanes.SelectedIndices;
                var deletePlanes = (from int i in selectedIndices select Planes[i]).ToList();

                foreach (var s in deletePlanes)
                {
                    Planes.Remove(s);
                }
            }
            else if (lbPlanes.SelectedIndices.Count == 1)
            {
                if (lbPlanes.SelectedIndex < 0) return;

                Planes.RemoveAt(lbPlanes.SelectedIndex);
            }

            ShowItemsInListbox();
        }

        private void ShowItemsInListbox()
        {
            TakeOutDuplicates();
            var selectedIndex = lbPlanes.SelectedIndex;
            lbPlanes.BeginUpdate();

            lbPlanes.Items.Clear();
            foreach (var s in Planes)
            {
                lbPlanes.Items.Add(s);
            }

            if (selectedIndex < lbPlanes.Items.Count)
                lbPlanes.SelectedIndex = selectedIndex;
            else
                lbPlanes.SelectedIndex = lbPlanes.Items.Count - 1;

            lbPlanes.Select(); // Scrolls the listbox to the selected index

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

        private void ResetPlanes()
        {
            Planes = new List<string> {
                "A-20G\r",
                "A5M4\r",
                "A6M2 Reisen\r",
                "A6M2-N\r",
                "A6M3 Reisen\r",
                "A6M3 Reisen mod 22\r",
                "A6M5 Reisen\r",
                "B-17E\r",
                "B-17E Late\r",
                "B-17G\r",
                "B-24D Liberator\r",
                "B-25J-1 Mitchell\r",
                "B-25J-20 Mitchell\r",
                "B5N2\r",
                "Beaufghter Mk.21\r",
                "Beaufighter Mk. VIc\r",
                "Beaufighter Mk. X\r",
                "Beaufighter Mk.21\r",
                "Beaufort Mk.VIII\r",
                "Bf 109 E-3\r",
                "Bf 109 F-4/trop\r",
                "Bf 109 G-10/R5\r",
                "Bf 109 G-2/trop\r",
                "Bf 109 K-4/R6\r",
                "Bf 110 C-4\r",
                "Bf.109 F-4\r",
                "Bf.109E-3\r",
                "Bf.109F-4\r",
                "Bf.109F-4/trop\r",
                "Bf.109G-10\r",
                "Bf.110 C-4",
                "Blenheim Mk. IV\r",
                "Boomerang Mk.I\r",
                "CAC Boomerang Mk I\r",
                "CAC Boomerang Mk II\r",
                "CAC Wirraway\r",
                "Canadair CL-13A Sabre Mk.5\r",
                "CR.42 Falco\r",
                "D3A1\r",
                "Dewoitine D.520\r",
                "Dewoitine D.521\r",
                "DH.98 Mosquito FB Mk. VI\r",
                "Do-217 J-1\r",
                "Do-217 J-2\r",
                "Douglas A-20G\r",
                "Douglas A-20G Invader\r",
                "F1M2\r",
                "F2A-1\r",
                "F2A-3 Buffalo\r",
                "F4F-3 Wildcat\r",
                "F4F-4 Wildcat\r",
                "F4U-1A\r",
                "F4U-1C\r",
                "F4U-1D\r",
                "F6F-3\r",
                "F-86A-5 Sabre\r",
                "Fw 190 A-5/U3\r",
                "Fw 190 D-12\r",
                "Fw 190 D-13\r",
                "Fw 190 F-8\r",
                "Fw.190A-5\r",
                "Fw.190D-12\r",
                "Fw.190F-8\r",
                "Fw.190G0 D-13 \"Dora\"\r",
                "G.50 \"Freccia\"\r",
                "G.50 Freccia seria 2\r",
                "G.50 Freccia seria 7AS\r",
                "G.50 serie 2\r",
                "G4M1\r",
                "G5N1 Shinzan\r",
                "G8N1 Renzan\r",
                "Gloster Gladiator II\r",
                "Gloster Gladiator Mk II\r",
                "Gloster Meteor F.3\r",
                "Gloster Meteor F.4 LW\r",
                "Gloster Meteor F.4 SW\r",
                "Gloster Meteor F.8\r",
                "Gloster Sea Meteor F.3\r",
                "Glostor Meteor F.4 LW\r",
                "Glostor Meteor F.4 SW\r",
                "Glostor Meteor F.8\r",
                "Grumman Hellcat F Mk I\r",
                "H6K4\r",
                "Havoc Mk. I\r",
                "Hawker Fury\r",
                "Hawker Fury Mk I\r",
                "Hawker Fury Mk II\r",
                "Hawker Hurricane Mk II\r",
                "Hawker Nimord Mk I\r",
                "Hawker Nimrod\r",
                "Hawker Nimrod Mk I\r",
                "Hawker Tempest Mk V\r",
                "Hawker Typhoon Mk 1a\r",
                "Hawker Typhoon Mk 1b\r",
                "Hawker Typhoon Mk 1b/L\r",
                "He-112 A-0\r",
                "He-112 B-0\r",
                "He-112 B-1\r",
                "He-112 V-5\r",
                "He-112A-0\r",
                "He-112B-0\r",
                "He-112B-1\r",
                "He-112B-2\r",
                "He-112V-5\r",
                "He-162 A-2\r",
                "He-162A-2\r",
                "He-51 A-1\r",
                "He-51 B-1\r",
                "He-51 C-1\r",
                "He-51 C-1/Late\r",
                "He-51A-1\r",
                "He-51B-1\r",
                "He-51B-2 hydroplane\r",
                "He-51C-1\r",
                "He-51C-1 late\r",
                "Hurricane Mk I\r",
                "Hurricane Mk. II\r",
                "Kawasaki Ki-10\r",
                "Ki-10-I\r",
                "Ki-10-I C\r",
                "Ki-10-II\r",
                "Ki-10-II C\r",
                "Ki-200\r",
                "Ki-43-II Hayabusa\r",
                "Ki-49 Donryuu\r",
                "Ki-49-I Donryuu\r",
                "Ki-49-IIa Donryuu\r",
                "Ki-49-IIb Donryuu\r",
                "Ki-49-IIb Donryuu /Late\r",
                "Ki-61-Ia Hien\r",
                "Ki-61-Ib Hien\r",
                "Ki-61-Ic Hien\r",
                "La-5FN\r",
                "La-7\r",
                "La-7B-20\r",
                "LaGG-3-35\r",
                "LaGG-3-66\r",
                "Lancaster Mk. III\r",
                "M.C. 200 \"Saetta\"\r",
                "M.C. 202 \"Folgore\"\r",
                "M.C.200 serie 3\r",
                "M.C.200 serie 7\r",
                "M.C.202\r",
                "Me 163B\r",
                "Me 262 A-1a\r",
                "Me.163B\r",
                "Me.262A-1a\r",
                "MiG-15\r",
                "MiG-3-15\r",
                "MiG-9\r",
                "MiG-9 /Late\r",
                "Mosquito FB Mk. VI\r",
                "Mustang Mk. IA\r",
                "N1K2-J Shiden-Kai\r",
                "N1K2-Ja Shiden-Kai\r",
                "North American P-51 Mustang Mk IA\r",
                "OS2U-1 Kingfisher\r",
                "OS2U-3 Kingfisher\r",
                "P-26A-33\r",
                "P-26A-34 M2\r",
                "P-26B-35\r",
                "P-36C Hawk\r",
                "P-38G Lightning\r",
                "P-39N-0 Airacobra\r",
                "P-39Q-5 Airacobra\r",
                "P-40E-1\r",
                "P-40E-1 Kittyhawk\r",
                "P-47D Thunderbolt\r",
                "P-47D-25 Thunderbolt\r",
                "P-47D-28 Thunderbolt\r",
                "P-51D-30 Mustang\r",
                "P-51D-5 Mustang\r",
                "P-63A-10 Kingcobra\r",
                "P-63A-5 Kingcobra\r",
                "P-63C-5 Kingcobra\r",
                "PBY-5 Catalina\r",
                "PBY-5a Catalina\r",
                "S.79 \"Sparviero\"\r",
                "S.79 1936\r",
                "S.79 1937\r",
                "S.79 1939\r",
                "S.79 1941\r",
                "S.79B\r",
                "S.79bis\r",
                "S.79bis/L\r",
                "SBD-3\r",
                "Spitfire\r",
                "Supermarine Spirfire Mk Vc\r",
                "Supermarine Spitfire Mk I\r",
                "Supermarine Spitfire Mk II\r",
                "Supermarine Spitfire Mk IX\r",
                "Supermarine Spitfire Mk Vb\r",
                "Supermarine Spitfire Mk XVI\r",
                "Swordfish Mk. I\r",
                "Ta 152 H-1\r",
                "Ta.152H-1\r",
                "TBF-1C\r",
                "Tempest Mk. V\r",
                "Typhoon Mk. 1a\r",
                "Typhoon Mk. 1b\r",
                "Wellington Mk. Ic\r",
                "Wellington Mk. III\r",
                "Wellington Mk. X\r",
                "Yak-15\r",
                "Yak-15P\r",
                "Yak-1B\r",
                "Yak-3\r",
                "Yak-7B\r",
                "Yak-9P\r",
                "Yak-9T"
            };
            ShowItemsInListbox();
        }
    }
}
