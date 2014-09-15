using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using WTnote.Properties;

namespace WTnote
{
    public partial class MainForm : Form
    {
        private List<NationData> NationsData { get; set; } // All data that needs to be persistent.
        private const string PlanesFileName = "Planes.txt";
        private const string DataFileName = "NationData.txt";
        private Nation PreviouslySelectedNation { get; set; } // In order to save the current data, before going to other tab.
        private List<string> PlaneNames { get; set; } // List of planes used for suggestions in textboxes.
        // Lists with the necessary UI elements, hooked up to a number for easy and consistent access.
        private Dictionary<int, TextBox> Textboxes { get; set; }
        private Dictionary<int, NumericUpDown> GunnerNumericBoxes { get; set; }
        private Dictionary<int, NumericUpDown> LevelNumericBoxes { get; set; }
        private Dictionary<int, ComboBox> TrainingComboBoxes { get; set; }

        public MainForm()
        {
            InitializeComponent();

            PreviouslySelectedNation = Nation.American;

            NationsData = LoadNationDataFromFile(DataFileName) ?? new List<NationData>();   // Load from file, if null is returned, creates a new (empty) list,
            PlaneNames = LoadPlanesFromFile(PlanesFileName) ?? new List<string>();          //    this way you prevent a null pointer exception.

            if (NationsData.Count < 1) // Happens only when nothing comes from reading the file with data.
            {
                NationsData.Add(new NationData(Nation.American));   // 0
                NationsData.Add(new NationData(Nation.German));     // 1
                NationsData.Add(new NationData(Nation.Russian));    // 2
                NationsData.Add(new NationData(Nation.British));    // 3
                NationsData.Add(new NationData(Nation.Japanese));   // 4
            }

            Textboxes = new Dictionary<int, TextBox>
                {
                    {1, tbAmCr1},
                    {2, tbAmCr2},
                    {3, tbAmCr3},
                    {4, tbAmCr4},
                    {5, tbAmCr5},
                    {6, tbAmCr6},
                    {7, tbAmCr7},
                    {8, tbAmCr8},
                    {9, tbAmCr9}
                };

            GunnerNumericBoxes = new Dictionary<int, NumericUpDown>
                {
                    {1, numAmGn1},
                    {2, numAmGn2},
                    {3, numAmGn3},
                    {4, numAmGn4},
                    {5, numAmGn5},
                    {6, numAmGn6},
                    {7, numAmGn7},
                    {8, numAmGn8},
                    {9, numAmGn9}
                };

            LevelNumericBoxes = new Dictionary<int, NumericUpDown>
                {
                {1, numAmLv1},
                {2, numAmLv2},
                {3, numAmLv3},
                {4, numAmLv4},
                {5, numAmLv5},
                {6, numAmLv6},
                {7, numAmLv7},
                {8, numAmLv8},
                {9, numAmLv9}
            };

            TrainingComboBoxes = new Dictionary<int, ComboBox>
                {
                    {1, cbAm1},
                    {2, cbAm2},
                    {3, cbAm3},
                    {4, cbAm4},
                    {5, cbAm5},
                    {6, cbAm6},
                    {7, cbAm7},
                    {8, cbAm8},
                    {9, cbAm9}
                };

            var trainingItems = Enum.GetValues(typeof(CrewTraining)).Cast<object>().ToArray();
            foreach (var cb in TrainingComboBoxes.Values)
            {
                cb.Items.AddRange(trainingItems);
            }

            cbSelectedNation.Items.AddRange(Enum.GetValues(typeof(Nation)).Cast<object>().ToArray());

            BindSuggestionsToAllTextboxes();

            cbSelectedNation.SelectedIndex = 0; // Selects the first nation in the combobox, automatically triggering the event linked to it.
            // This fires of the LoadDataIntoGui() method with the selected nation.
        }

        private static List<string> LoadPlanesFromFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
                return null;
            }

            using (var sr = new StreamReader(fileName))
            {
                var fullFileString = sr.ReadToEnd();
                var stringArray = JsonConvert.DeserializeObject<List<string>>(fullFileString);
                return stringArray;
            }
        }

        private static void SavePlanesToFile(string fileName, List<string> planeNames)
        {
            using (var sw = new StreamWriter(fileName))
            {
                var jsonString = JsonConvert.SerializeObject(planeNames);
                sw.Write(jsonString);
                sw.Close();
                Console.WriteLine("Planes saved!");
            }
        }

        private static List<NationData> LoadNationDataFromFile(string dataFileName)
        {
            if (!File.Exists(dataFileName))
            {
                File.Create(dataFileName);
                return null;
            }

            try
            {
                using (var sr = new StreamReader(dataFileName))
                {
                    var fullFile = sr.ReadToEnd();
                    sr.Close();
                    var deserializedObject = JsonConvert.DeserializeObject<List<NationData>>(fullFile);
                    return deserializedObject;
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        private void cbSelectedNation_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedNation = (Nation)cbSelectedNation.SelectedItem;

            ChangeBackground(selectedNation);

            LoadDataIntoGui(selectedNation);
        }

        private void ChangeBackground(Nation selectedNation)
        {
            switch (selectedNation)
            {
                case Nation.American:
                    BackgroundImage = Resources._1000px_Usa;
                    break;
                case Nation.German:
                    BackgroundImage = Resources._1000px_Germany;
                    break;
                case Nation.Russian:
                    BackgroundImage = Resources._1000px_Ussr;
                    break;
                case Nation.British:
                    BackgroundImage = Resources._1000px_Britain;
                    break;
                case Nation.Japanese:
                    BackgroundImage = Resources._1000px_Japan;
                    break;
            }
        }

        private void LoadDataIntoGui(Nation selectedNation)
        {
            SaveGuiData();

            PreviouslySelectedNation = selectedNation;

            var selectedNationNr = 0;
            switch (selectedNation)
            {
                case Nation.American:
                    //selectedNationNr = 0;
                    break;
                case Nation.German:
                    selectedNationNr = 1;
                    break;
                case Nation.Russian:
                    selectedNationNr = 2;
                    break;
                case Nation.British:
                    selectedNationNr = 3;
                    break;
                case Nation.Japanese:
                    selectedNationNr = 4;
                    break;
            }

            for (var i = 1; i < 10; i++)
            {
                Textboxes[i].Text = NationsData[selectedNationNr].CrewString[i];
                GunnerNumericBoxes[i].Value = NationsData[selectedNationNr].CrewGunner[i];
                LevelNumericBoxes[i].Value = NationsData[selectedNationNr].CrewLevel[i];
                TrainingComboBoxes[i].SelectedItem = NationsData[selectedNationNr].CrewTraining[i];
            }

            /*if (cbAm1.SelectedIndex < 0) // Use when json file goes bad
                cbAm1.SelectedIndex = 0;

            if (cbAm2.SelectedIndex < 0)
                cbAm2.SelectedIndex = 0;

            if (cbAm3.SelectedIndex < 0)
                cbAm3.SelectedIndex = 0;

            if (cbAm4.SelectedIndex < 0)
                cbAm4.SelectedIndex = 0;

            if (cbAm5.SelectedIndex < 0)
                cbAm5.SelectedIndex = 0;

            if (cbAm6.SelectedIndex < 0)
                cbAm6.SelectedIndex = 0;

            if (cbAm7.SelectedIndex < 0)
                cbAm7.SelectedIndex = 0;

            if (cbAm8.SelectedIndex < 0)
                cbAm8.SelectedIndex = 0;

            if (cbAm9.SelectedIndex < 0)
                cbAm9.SelectedIndex = 0;*/
        }

        private void SaveGuiData()
        {
            var selectedNation = 0;

            switch (PreviouslySelectedNation)
            {
                case Nation.American:
                    selectedNation = 0;
                    break;
                case Nation.German:
                    selectedNation = 1;
                    break;
                case Nation.Russian:
                    selectedNation = 2;
                    break;
                case Nation.British:
                    selectedNation = 3;
                    break;
                case Nation.Japanese:
                    selectedNation = 4;
                    break;
            }

            for (var i = 1; i < 10; i++)
            {
                NationsData[selectedNation].CrewString[i] = Textboxes[i].Text;
                NationsData[selectedNation].CrewGunner[i] = (int)GunnerNumericBoxes[i].Value;
                NationsData[selectedNation].CrewLevel[i] = (int)LevelNumericBoxes[i].Value;
                NationsData[selectedNation].CrewTraining[i] = (CrewTraining)TrainingComboBoxes[i].SelectedIndex;
            }
        }

        private void btnSaveAm_Click(object sender, EventArgs e)
        {
            SaveGuiData();
            SaveDataToFile(DataFileName, NationsData);
            SavePlanesToFile(PlanesFileName, PlaneNames);
        }

        private static void SaveDataToFile(string fileName, List<NationData> nationData)
        {
            using (var sw = new StreamWriter(fileName))
            {
                var serializedObject = JsonConvert.SerializeObject(nationData);
                sw.Write(serializedObject);
                sw.Close();
                Console.WriteLine("Crew data is saved!");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveGuiData();
            SaveDataToFile(DataFileName, NationsData);
            SavePlanesToFile(PlanesFileName, PlaneNames);
        }

        private void btnEditPlanes_Click(object sender, EventArgs e)
        {
            new EditPlanesForm(PlaneNames).ShowDialog();
            BindSuggestionsToAllTextboxes();
        }

        private void BindSuggestionsToAllTextboxes()
        {
            var source = new AutoCompleteStringCollection();
            source.AddRange(PlaneNames.ToArray());

            foreach (var tb in Textboxes.Values)
            {
                tb.AutoCompleteCustomSource = source;
                tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }
    }

    public enum Nation
    {
        American = 0,
        German = 1,
        Russian = 2,
        British = 3,
        Japanese = 4
    }
}
