using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace KaliInjecteur
{
    public partial class Form1 : Form
    {
        private string cheminDossierDll;

        // Définir les caractères possibles
        string caracteresPossibles = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        string[] voyellePossibles = { "a", "e", "i", "o", "u", "y", "au", "aë", "ei", "ou"  };
        string[] consonnePossibles = { "a", "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "ch", "br", "dr", "gr",  };

        // Générer un mot aléatoire alternant voyelle-consonne trois fois
        string motAleatoire;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //motAleatoire = GenererMotAleatoire(voyellePossibles, consonnePossibles, 3);
            //this.Text = motAleatoire;

            // Spécifiez le nom du dossier DLL
            string nomDossier = "DLL";

            // Obtenez le chemin du dossier de l'application
            string cheminApplication = AppDomain.CurrentDomain.BaseDirectory;



            // Combinez le chemin de l'application avec le nom du dossier
            string cheminDossierDll = Path.Combine(cheminApplication, nomDossier);

            // Vérifiez si le dossier existe
            if (!Directory.Exists(cheminDossierDll))
            {
                // Le dossier n'existe pas, donc créez-le
                Directory.CreateDirectory(cheminDossierDll);
            }

            Protect();

            var directoryInfo = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).Parent;
            if (directoryInfo != null)
                txtDLLPath.Text = cheminDossierDll;

            var processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                if (!tableProcess.Items.Contains(process.ProcessName))
                {
                    tableProcess.Items.Add(process.ProcessName);
                }
            }

            LoadSettings();
        }

        private void Protect()
        {

                // Listes de voyelles et de consonnes possibles
                string[] voyellePossibles = { "a", "e", "i", "o", "u", "y", "au", "aë", "ei", "ou" };
                string[] consonnePossibles = { "a", "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "ch", "br", "dr", "gr" };

                // Générer un mot aléatoire alternant voyelle-consonne trois fois
                string motAleatoire = GenererMotAleatoire(voyellePossibles, consonnePossibles, 6);

            this.Text = motAleatoire;
        }

        private void tableProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPID.Text = tableProcess.SelectedItem.ToString();
        }

        private void actualiser_Click(object sender, EventArgs e)
        {
            var processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                if (!tableProcess.Items.Contains(process.ProcessName))
                {
                    tableProcess.Items.Add(process.ProcessName);
                }
            }
        }

        private void parcourir_Click(object sender, EventArgs e)
        {
           

            var file = new OpenFileDialog();
            file.InitialDirectory = cheminDossierDll;
            if (file.ShowDialog() == DialogResult.OK)
            {
                txtDLLPath.Text = file.FileName;
            }
        }

        private void injecter_Click(object sender, EventArgs e)
        {
            new Thread(DoInject).Start();
        }

        void DoInject()
        {
            Process proc = null;
            try
            {
                proc = Process.GetProcessById(Convert.ToInt32(txtPID.Text));
            }
            catch (Exception ex)
            {
                try
                {
                    proc = Process.GetProcessesByName(txtPID.Text)[0];
                }
                catch (Exception exx)
                {
                }
            }

            if (proc == null)
            {
                MessageBox.Show("Sélectionnez un processus");
                return;
            }

            Injecteur.Inject(txtDLLPath.Text, proc);
        }

        private void enregistrer_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void charger_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            if (ConfigurationManager.AppSettings["chemindll"] != "")
                txtDLLPath.Text = ConfigurationManager.AppSettings["chemindll"];
            txtPID.Text = ConfigurationManager.AppSettings["processus"];
            checkBox1.Checked = Convert.ToBoolean(Convert.ToInt32(ConfigurationManager.AppSettings["attendreprocessus"]));
            numericUpDown1.Value = Convert.ToInt32(ConfigurationManager.AppSettings["delais"]);
        }

        private void SaveSettings()
        {
            SetSetting("chemindll", txtDLLPath.Text);
            SetSetting("processus", txtPID.Text);
            SetSetting("attendreprocessus", Convert.ToInt32(checkBox1.Checked).ToString());
            SetSetting("delais", numericUpDown1.Value.ToString(CultureInfo.InvariantCulture));
        }

        internal static bool SetSetting(string key, string value)
        {
            var config =
                ConfigurationManager.OpenExeConfiguration(
                    ConfigurationUserLevel.None);

            config.AppSettings.Settings.Remove(key);
            var kvElem = new KeyValueConfigurationElement(key, value);
            config.AppSettings.Settings.Add(kvElem);

            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");

            return true;
        }

        static string GenererMotAleatoire(string[] voyelles, string[] consonnes, int longueur)
        {
            Random random = new Random();
            string motAleatoire = "";

            for (int i = 0; i < longueur; i++)
            {
                // Alterner entre voyelle et consonne
                if (i % 2 == 0)
                {
                    int indexVoyelle = random.Next(voyelles.Length);
                    motAleatoire += voyelles[indexVoyelle];
                }
                else
                {
                    int indexConsonne = random.Next(consonnes.Length);
                    motAleatoire += consonnes[indexConsonne];
                }
            }

            return motAleatoire;
        }

    }
}