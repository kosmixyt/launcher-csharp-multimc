using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.ServiceProcess;
using System.Diagnostics;
using MojangAPI;
using System.Timers;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Point mouseLocation;
        int finish = 0;
        int note = 0;
        int patch = 0;
        int navigate = 0;
        string appdatafile = @"C:\Tmp\lc.txt";
        string close = @"C:\Tmp\close.dll";
        string follow = @"C:\Tmp\follow.dll";
        Boolean closer = false;
        Boolean login = false;
        string client = "nada";
        Boolean update = false;

        public System.Timers.Timer t { get; private set; }

        public Form1()
        {

            InitializeComponent();
            button8.Hide();


            string labase = null;
            // si le fichier qui designe le chemin des fichiers existe alors il vérifie si le contenu est bien le chemin 
            //d'un dossier

            //      int patch = 0;
            //      int navigate = 0;
            //      string appdatafile = @"C:\Tmp\lc.txt";
            //      string close = @"C:\Tmp\close.dll";
            //      string follow = @"C:\Tmp\follow.dll";
            //      Boolean closer = false;
            //      Boolean login = false;
            //      string client = "nada";
            if (File.Exists(appdatafile))
            {
                labase = File.ReadAllText(appdatafile);
            }
            // si "labase"  est null alors il set le dossier des fichiers à c:\launcher\

            if (String.IsNullOrEmpty(labase))
            {
                labase = @"c:\launcher\";

            }
            // il set les variables des dossiers des instances et le dossier sys
            string directorylauncher = labase;
            string directoryinstance = labase + @"multimc\instances\";
            string directoryconfig = labase + @"sys\";

            // création des fichiers du jeu si il n'éxistent pas

            if (!Directory.Exists(directorylauncher))
            {
                Directory.CreateDirectory(directorylauncher);
            }
            if (!Directory.Exists(directoryconfig))
            {
                Directory.CreateDirectory(directoryconfig);
            }
            WebClient WebClient = new WebClient();


            // le string dl contient le nom du dernier module ajouter pour que le pc
            //vérifie si il existe dans le client si il n'éxiste pas alors il retélécharge entièrement multimc
            //téléchargement des fichiers systemes
            //il contitent le chemin exemple : \minecraft\mods\nomdumods.jar
            if (File.Exists(directoryconfig + @"1.dll"))
            {
                File.Delete(directoryconfig + @"1.dll");
            }

            // il télécharge 1.dll dans le fichier de config 

            WebClient.DownloadFile("http://kosmix.fr/dl/1.dll", directoryconfig + @"1.dll");

            if (!File.Exists(directoryinstance + File.ReadAllText(directoryconfig + @"1.dll")))
            {
                Console.WriteLine(directoryinstance + File.ReadAllText(directoryconfig + "1.dll"));
                update = true;

            }

            label2.Hide();
            checkBox1.Hide();
            textBox1.Hide();
            webBrowser1.Hide();

            button10.Hide();
            button11.Hide();
            label4.Hide();
            label3.Hide();
            button9.Hide();
            textBox2.Hide();
            progressBar1.Hide();
            if (update == true)
            {
                label2.Text = "Updating ...";
                label2.Show();
                button13.Show();
                button5.Hide();
                button12.Hide();
                button7.Hide();
                button8.Hide();

            }
            if (update == false)
            {

                button13.Hide();
                button5.Show();
                button12.Show();
                button7.Show();
            }
            File.Delete(directorylauncher + "multimc.zip");
            if (File.Exists(@"c:\Temp\patch.txt"))
            {
                if (File.ReadAllText(@"c:\Temp\patch.txt") == "true")
                {
                    note = 1;
                    webBrowser1.Navigate("http://hexcraft.co/patch");
                    webBrowser1.Show();
                    button13.Text = ("close");
                }
            }
            button8.Hide();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }


        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            button3.Show();
            button2.Hide();



        }

        private void button3_Click(object sender, EventArgs e)
        {
        

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Normal;
            button2.Show();
            button3.Hide();
            webBrowser1.Hide();
            button10.Hide();
            button11.Hide();
            label4.Hide();
            button9.Hide();
            label3.Hide();
            textBox1.Hide();
            button8.Hide();


        }

        private void min_Click(object sender, EventArgs e)
        {

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (patch == 1)
            {
                webBrowser1.Hide();
                button5.Text = "Launch";
                button5.Show();
                button6.Hide();
                button12.Hide();
                button7.Hide();


            }
            else
            {


                label2.Hide();
                textBox2.Hide();
                checkBox1.Hide();
                Process.Start(@"C:\Users\Maxime\Desktop\MultiMC\MultiMc.exe", "-l HS-1.5.3");
                string labase = null;
                if (File.Exists(appdatafile))
                {
                    if (Directory.Exists(File.ReadAllText(appdatafile)))

                        labase = File.ReadAllText(appdatafile);

                }

                if (String.IsNullOrEmpty(labase))
                {
                    labase = @"c:\launcher\";

                }

                //        if (Directory.GetFileSystemEntries(labase + @"multimc\accounts\").Length == 0){

                //    MessageBox.Show("Vous devez vour connecter à votre compte minecraft");

                //    return;
                //    afficher que il faut ajouter un compte

                //         }

                if (Process.GetProcessesByName("Java.exe").Length > 0)
                {
                    MessageBox.Show("Jeu déjà éxécuter");
                    return;
                }

                //    Process.Start(labase + @"multimc\Multimc.exe -l HS-1.5.3");

                label2.Text = "Game launched !";
                label2.Show();
                button5.Show();

                if (File.ReadAllText(close) == "yes")
                {
                    Close();


                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            checkBox1.Hide();
            textBox2.Hide();
            button10.Hide();
            button11.Hide();
            label4.Hide();
            button9.Hide();
            label2.Hide();
            label3.Hide();
            textBox1.Hide();
            button8.Hide();
            if (navigate == 0)
            {
                webBrowser1.Show();
                webBrowser1.Navigate("https://hexcraft.co/news/");
                navigate = navigate + 1;
                label2.Hide();
            }
            else
            {
                navigate = navigate - 1;
                label2.Hide();
                webBrowser1.Hide();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            checkBox1.Hide();
            button9.Text = "Reset";
            login = false;
            label3.Hide();
            textBox2.Hide();
            button10.Show();
            button11.Show();
            label4.Show();
            button9.Show();
            button8.Show();
            webBrowser1.Hide();

            label2.Text = "dossier du jeux";
            label2.Show();
            textBox1.Show();
            string textbox = @"c:\launcher";
            if (File.Exists(appdatafile))
            {
                try
                {
                    textbox = File.ReadAllText(appdatafile);

                }
                catch (Exception erreur1)
                {
                    MessageBox.Show("erreur 1" + erreur1.ToString());
                }
            }





            textBox1.Text = textbox;

        }


        private void button8_Click(object sender, EventArgs e)
        {



        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {



        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (closer == true)
            {

                File.WriteAllText(close, @"yes");
            }
            else
            {
                File.WriteAllText(close, @"no");
            }


            button10.Hide();
            button11.Hide();
            label4.Hide();
            button9.Hide();

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                label3.Text = "champ vide!";
                label3.Show();
                return;

            }
            if (!Directory.Exists(textBox1.Text))
            {
                label3.Text = "Dossier inexistant";
                label3.Show();
                return;
            }



            if (File.Exists(appdatafile))
            {



                File.Delete(appdatafile);








            }

            string txt = textBox1.Text;
            File.WriteAllText(appdatafile, txt);
            label3.Show();

            label2.Hide();
            textBox1.Hide();
            button8.Hide();

            label3.Text = "Changement efféctué avec succés";
            label3.Show();
            Thread.Sleep(1000);

            label3.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (!login == true)
            {
                string labase = null;
                if (File.Exists(appdatafile))
                {
                    if (Directory.Exists(File.ReadAllText(appdatafile)))

                        labase = File.ReadAllText(appdatafile);

                }

                if (String.IsNullOrEmpty(labase))
                {
                    labase = @"c:\launcher\";

                }

                textBox1.Text = labase;

            }
            else
            {

                Request authRequest = new Request(Request.Method.POST, URL.AUTHENTICATION.SIGN_IN);
                String rawResponse = authRequest.Execute((string)Header.Authentication.Signin(textBox1.Text, textBox2.Text));
                AuthenticationResponse authResponse = new AuthenticationResponse(rawResponse);


                if (authResponse.GetResponse.Error == null)
                {
                    checkBox1.Hide();
                    MessageBox.Show("Bonjour " + authResponse.GetResponse.PlayerName);
                    //              Console.WriteLine("  AccessToken:" +  authResponse.GetResponse.AccessToken);
                    //              Console.WriteLine("  ClientToken: "+  authResponse.GetResponse.ClientToken);
                    button9.Hide();

                    label2.Hide();
                    textBox1.Hide();
                    textBox2.Hide();
                    checkBox1.Hide();
                    label3.Hide();
                    if (File.Exists(follow))
                    {

                        File.Delete(follow);
                    }


                    if (checkBox1.Checked == true)
                    {
                        MessageBox.Show("textbox coché");
                        // chekbox egal à true
                        //  + "username=@" + authResponse.GetResponse.PlayerName + "@"
                        File.WriteAllText(follow, "true");
                    }
                    else
                    {
                        MessageBox.Show("checkbox pas coché");
                        File.WriteAllText(follow, "false");

                    }

                    // écriture du account.json




                    client = "{\"accounts\":[{ \"accessToken\":\" " + "eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiIwMzkyOTgxMTgxMWFiZTJhODRjOWEwZWQwNzNiMTY5YyIsInlnZ3QiOiJlNDI4OWY3MmQ3N2Y0ZTI0YWVkMzc3Y2I1NjA1ZjI1NiIsInNwciI6IjNjMjI5OTk5NDg2OTQ0ZDY4YjY4MmU1NDczNmEwZGRmIiwiaXNzIjoiWWdnZHJhc2lsLUF1dGgiLCJleHAiOjE2MTQ1MTczNzUsImlhdCI6MTYxNDM0NDU3NX0.TJmzaPF70bul0nTAal6Bj6a_soB1oT0bHnFoTF9rSOk" + "\",\"activeProfiles\":\"3c229999486944d68b682e54736a0ddf\", \"clientToken\":\"" + authResponse.GetResponse.ClientToken + "\",\"profiles\":[{\"id\":\"3c229999486944d68b682e54736a0ddf\",\"legacy\": false,\"name\":\"" + authResponse.GetResponse.PlayerName + "\"}],\"user\":{\"id\":\"03929811811abe2a84c9a0ed073b169c\"}, \"username\":\"" + textBox1.Text + "\"}],\"activeAccount\":\"" + textBox1.Text + "\",\"formatVersion\": 2}";
                    Console.WriteLine(authResponse.GetResponse.AccessToken);
                    Console.WriteLine(authResponse.GetResponse.ClientToken);
                    Console.WriteLine(authResponse.GetResponse.PlayerName);


                    File.WriteAllText(@"C:\Users\Maxime\Desktop\MultiMC\accounts.json", client);
























                }
                else
                {

                    MessageBox.Show("Authentication failed.");
                    Console.WriteLine("PlayerName: " + authResponse.GetResponse.PlayerName);
                    Console.WriteLine("  ErrorType: " + authResponse.GetResponse.Error);
                    Console.WriteLine("  ErrorMessage: " + authResponse.GetResponse.ErrorMessage);
                }





            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            closer = true;


        }

        private void button11_Click(object sender, EventArgs e)
        {
            closer = false;


        }

        private void button12_Click(object sender, EventArgs e)
        {
            checkBox1.Show();
            login = true;
            textBox1.Text = "";
            button9.Text = "login";
            textBox2.Hide();
            button10.Hide();
            button11.Hide();
            label4.Hide();
            webBrowser1.Hide();
            button9.Hide();
            label2.Hide();
            label3.Hide();
            textBox1.Hide();
            button8.Hide();
            label2.Text = "E-mail";
            label2.Show();
            textBox1.Show();
            label3.Text = "Password";
            label3.Show();
            textBox2.Show();
            button9.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (note == 1)
            {
                webBrowser1.Hide();

            }
            else
            {

                string labase = null;
                if (File.Exists(appdatafile))
                {
                    labase = File.ReadAllText(appdatafile);
                }
                // si "labase"  est null alors il set le dossier des fichiers à c:\launcher\

                if (String.IsNullOrEmpty(labase))
                {
                    labase = @"c:\launcher\";

                }
                // il set les variables des dossiers des instances et le dossier sys
                string directorylauncher = labase;
                string directoryinstance = labase + @"multimc\instance\";
                string directoryconfig = labase + @"sys\";
                //  
                progressBar1.Show();

                if (File.Exists(labase + "multimc"))
                {

                    Directory.Delete(labase + "multimc", true);
                }

                if (File.Exists(directoryconfig + "size.dll"))
                {


                    File.Delete(directoryconfig + "size.dll");

                }
                WebClient webClient = new WebClient();






                webClient.DownloadProgressChanged += (s, error4) =>
                {
                    progressBar1.Value = error4.ProgressPercentage;
                };
                webClient.DownloadFileCompleted += (s, error4) =>
                {
                    progressBar1.Visible = false;
                    finish = 1;
                    if (!Directory.Exists(directorylauncher + @"multimc\"))
                    {
                        Directory.CreateDirectory(directorylauncher + @"multimc\");
                    }
                    ZipFile.ExtractToDirectory(directorylauncher + "multimc.zip", directorylauncher + @"multimc\");

                    File.WriteAllText(@"c:\Temp\patch.txt", "true");

                    label2.Text = "Restarting ...";
                    label2.Show();
                    Thread.Sleep(1000);
                    Application.Restart();





                };

                webClient.DownloadFileAsync(new Uri("http://localhost/dl/MultiMC.zip"), directorylauncher + "multimc.zip");


                Console.WriteLine(directorylauncher + @"multimc\Multimc.exe");



                //téléchargement du fichier zip de multimc avec l'instance préinstaller
                //décmpression de multimc 

                // Suppression de multimc.zip





            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}



























        

