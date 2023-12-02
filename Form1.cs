using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO.Compression;
using System.Net;
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

        string[] voyellePossibles = { "a", "e", "i", "o", "u", "y", "au", "aë", "ei", "ou" };
        string[] consonnePossibles = { "a", "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "ch", "br", "dr", "gr", };

        // Générer un mot aléatoire alternant voyelle-consonne trois fois
        string motAleatoire;

        string VersionActu;
        string VersionDispo;

        private string nomDll = "YimMenu.dll";
        string urlChangelog = "http://apoca.eu/Yim/changelog.txt";
        string urlNewVersion = "http://apoca.eu/Yim/NewVersion.txt";
        string urlYim = "http://apoca.eu/Yim/YimMenu.zip";

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
            cheminDossierDll = Path.Combine(cheminApplication, nomDossier);

            // Vérifiez si le dossier existe
            if (!Directory.Exists(cheminDossierDll))
            {
                // Le dossier n'existe pas, donc créez-le
                Directory.CreateDirectory(cheminDossierDll);
            }

            Protect();

            // Vérifiez si la dll est dans le dossier dll
            if (!File.Exists(cheminDossierDll + @"\" + nomDll))
            {
                // La dll n'existe pas, la télécharger
                DownloadDll();
            }
            else
            {
                testMajInstall();
            }
        }

        private void DownloadDll()
        {
            //supprime les fichiers et dossier
            try
            {
                File.Delete(cheminDossierDll + @"\" + nomDll);
                File.Delete(cheminDossierDll + @"\info.txt");


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }


            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += (s, er) =>
            {
                try
                {
                    toolStripProgressBar1.Value = er.ProgressPercentage;
                }
                catch
                {

                }

            };
            webClient.DownloadFileCompleted += (s, er) =>
            {

                try
                {
                    try
                    {
                        //télécharger et affiche la nouvelle version
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile(urlNewVersion, cheminDossierDll + @"\NewVersion.txt");
                        string NewVersion = cheminDossierDll + @"\NewVersion.txt";
                        IEnumerable<string> line2 = File.ReadLines(NewVersion);
                        VersionDispo = String.Join("", line2);

                        //Passe le chemin de fichier et le nom de fichier au constructeur StreamWriter
                        StreamWriter sw = new StreamWriter(cheminDossierDll + @"\info.txt");
                        //écrit la version du jeu (Edit>Project Settings>Player)
                        sw.WriteLine(VersionDispo);
                        //Ferme le fichier
                        sw.Close();
                    }
                    catch
                    {

                    }
                    ZipFile.ExtractToDirectory(cheminDossierDll + @"\tmp\YimMenu.zip", cheminDossierDll);//installe le fichier

                    //supprime le dossier tmp
                    Directory.Delete(cheminDossierDll + @"\tmp", true);

                    timer1.Start();
                    //this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur est survenue lors de la décompression :" + ex.ToString());
                }

            };
            DirectoryInfo di = Directory.CreateDirectory(cheminDossierDll + @"\tmp");//créer dossier tmp
            webClient.DownloadFileAsync(new Uri(urlYim), cheminDossierDll + @"\tmp\YimMenu.zip");

        }

        private void testMajInstall()
        {
            try
            {
                string CurrentVersion = cheminDossierDll + @"\info.txt";
                // Creating enumerable object  
                IEnumerable<string> line = File.ReadLines(CurrentVersion);
                VersionActu = String.Join("", line);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur 156 : " + ex);
                //installer pour la première fois
                DownloadDll();
            }


            try
            {
                //télécharger et affiche la nouvelle version
                WebClient webClient = new WebClient();
                webClient.DownloadFile(urlNewVersion, cheminDossierDll + @"\NewVersion.txt");
                string NewVersion = cheminDossierDll + @"\NewVersion.txt";
                IEnumerable<string> line2 = File.ReadLines(NewVersion);
                VersionDispo = String.Join("", line2);

                //Télécharge et affiche le changelog
                WebClient webClient2 = new WebClient();
                webClient2.DownloadFile(urlChangelog, cheminDossierDll + @"\changelog.txt");
                string changelogNew = cheminDossierDll + @"\changelog.txt";
                IEnumerable<string> line3 = File.ReadLines(changelogNew);
                //changelog += String.Join(Environment.NewLine, line3);



                //recupère la taille du fichier
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.OpenRead(urlYim);
                Int64 bytes_total = Convert.ToInt64(wc.ResponseHeaders["Content-Length"]);

                // Ecrira le nombre sur deux chiffres et deux
                // chiffres après la virgule
                decimal tmpTaille = Convert.ToDecimal(ConvertBytesToMegabytes(bytes_total).ToString());
                //TailleMaj.Text = decimal.Round(tmpTaille, 2, MidpointRounding.AwayFromZero).ToString() + " MB"; //l'affiche dans TailleMaj



                //Si une mise à jour est disponible
                if (VersionActu != VersionDispo)
                {
                    DownloadDll();
                    //MessageBox.Show("Versions differentes");
                }
                else //sinon
                {
                    try
                    {

                        //Passe le chemin de fichier et le nom de fichier au constructeur StreamWriter
                        StreamWriter sw = new StreamWriter(cheminDossierDll + @"\info.txt");
                        //écrit la version du jeu (Edit>Project Settings>Player)
                        sw.WriteLine(VersionDispo);
                        //Ferme le fichier
                        sw.Close();
                        timer1.Start();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("erreur 238 : " + ex.ToString());
                    }

                    //this.Close(); //fermer l'updater
                }


            }
            catch (WebException ex)
            {
                // Traitement des erreurs
                MessageBox.Show("erreur : " + ex.ToString());
            }
        }


        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
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

        void DoInject()
        {
            Process proc = null;
            try
            {
                proc = Process.GetProcessById(Convert.ToInt32("GTA5"));
            }
            catch (Exception ex)
            {
                try
                {
                    proc = Process.GetProcessesByName("GTA5")[0];
                }
                catch (Exception exx)
                {
                }
            }

            if (proc == null)
            {
                timer1.Start();
                //MessageBox.Show("Sélectionnez un processus");
                return;
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.Close();
                }));
                
            }

            Injecteur.Inject(cheminDossierDll + @"\" + nomDll, proc);
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                File.Delete(cheminDossierDll + @"\NewVersion.txt");
                File.Delete(cheminDossierDll + @"\changelog.txt");
                Directory.Delete(Application.StartupPath + @"\tmp", true);
            }
            catch
            {

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            new Thread(DoInject).Start(); //Injecter le menu
        }
    }
}