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
using System.Net.NetworkInformation;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Point mouseLocation;

        string labase = null;
        Boolean account = false;    
        int finish = 0;
        int note = 0;
        int patch = 0;
        int install = 0;
        int navigate = 0;
        string pwd = @"C:\Temp\playerid.txt";
        string appdatafile = @"C:\Temp\lc.txt";
        string close = @"C:\Temp\close.dll";
        string follow = @"C:\Temp\follow.dll";
        Boolean closer = false;
        Boolean login = false;
        string client = "nada";
        Boolean update = false;

        public System.Timers.Timer t { get; private set; }

        public Form1()
        {

            InitializeComponent();
            checkBox2.Hide();
                


            button8.Hide();
            if (!Directory.Exists(@"c:\Temp"))
            {
                Directory.CreateDirectory(@"c:\Temp");
            }

            if (File.Exists(pwd))
            {
                label5.Text = File.ReadAllText(pwd);
            }else
            {


                label5.Text = "NO PLAYER CONNECTED";
            }
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
            if (File.Exists(labase + @"MultiMC.zip"))
            {
                File.Delete(labase + @"MultiMC.zip");
            }
            if (File.Exists(labase + @"instances.zip"))
            {
                File.Delete(labase + @"instances.zip");
            }
            if (!File.Exists(labase + @"MojangAPI.dll"))
            {

                WebClient webClient = new WebClient();
                webClient.DownloadFile("http://51.38.213.146/api.dll", Application.StartupPath + "MojangAPI.dll");

            }
            // il set les variables des dossiers des instances et le dossier sys
            string directorylauncher = labase;
            string directoryinstance = labase + @"multimc\instances\";
            string directoryconfig = labase + @"sys\";
         
            // voir si multi mc a été installer 
            if (!File.Exists(labase + @"multimc\MultiMC.exe"))
            {
                install = 1;

            }else
            {

                // le string dl contient le nom du dernier module ajouter pour que le pc
                //vérifie si il existe dans le client si il n'éxiste pas alors il retélécharge entièrement multimc
                //téléchargement des fichiers systemes
                //il contitent le chemin exemple : \minecraft\mods\nomdumods.jar
                if (File.Exists(directoryconfig + @"1.dll"))
                {
                    File.Delete(directoryconfig + @"1.dll");
                }

                // il télécharge 1.dll dans le fichier de config 
                WebClient webClient = new WebClient();
                webClient.DownloadFile("http://51.38.213.146/1.dll", directoryconfig + @"1.dll");
                if (!File.Exists(directoryinstance + File.ReadAllText(directoryconfig + @"1.dll")))
                {
                    Console.WriteLine(directoryinstance + File.ReadAllText(directoryconfig + "1.dll"));
                    update = true;
                    button12.Hide();


                }

            }
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
                label2.Text = "After Freeze please restart the launcher";
                label2.Show();
                button13.Show();
                button12.Hide();
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
             /*   if (File.ReadAllText(@"c:\Temp\patch.txt") == "true")
                {
                    note = 1;
                    webBrowser1.Navigate("http://hexcraft.co/patch");
                    webBrowser1.Show();
                    button13.Text = ("close");
                }
                */
            }
            if(install == 1) {
                button13.Show();
                button12.Hide();
            

            }
            button8.Hide();

            if (File.Exists(labase + @"multimc\accounts.json"))
            {
                account = true;
                Console.WriteLine("true");
            }
            else
            {
                button5.Hide();
                button7.Hide();
                button12.Hide();
            }
            if(update == false)
            {
                button12.Show();
            }


            label1.Show();


            Ping ping = new Ping();
            PingReply reply = ping.Send("hexcraft.co",1000);
            string reponse = reply.Status.ToString();
            if(reponse == "Timeout")
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Servers offline";
                label1.Show();
            }
            else
            {
                label1.ForeColor = Color.Lime;
                label1.Text = "Servers online";
                label1.Show();
            }


            if (button12.Visible == true) { Console.WriteLine("true"); }
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



        }

        private void button3_Click(object sender, EventArgs e)
        {
        

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Normal;
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

                if (File.Exists(appdatafile))
                {
                    if (Directory.Exists(File.ReadAllText(appdatafile)))

                        labase = File.ReadAllText(appdatafile);

                }

                if (String.IsNullOrEmpty(labase))
                {
                    labase = @"c:\launcher\";

                }



                File.WriteAllText(@"c:\Temp\cc.txt", labase + @"multimc\Multimc.exe");
                Process.Start(labase + @"multimc\MultiMC.exe", "-l HS-1.5.3");
                Process.Start(labase + @"multimc\MultiMC.exe", "-l HS-1.5.3");
                label2.Text = "Game launched !";
                label2.Show();
                button5.Show();
            
                if (File.Exists(@"c:\Temp"))
                {
                    if (File.ReadAllText(close) == "yes")
                    {
                        Close();


                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            checkBox2.Hide();
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
                button13.Hide();
                webBrowser1.Show();
                webBrowser1.Navigate("https://hexcraft.co/news/");
                navigate = navigate + 1;
                label2.Hide();
            }
            else
            {
                if (update == true)
                {
                    button13.Show();
                    button12.Hide();
                }
                navigate = navigate - 1;
                label2.Hide();
                webBrowser1.Hide();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            checkBox2.Show();
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

            label2.Text = "launcher folder";
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
                    MessageBox.Show("Error 1" + erreur1.ToString());
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
            if (File.Exists(appdatafile))
            {
                labase = File.ReadAllText(appdatafile);
            }
            // si "labase"  est null alors il set le dossier des fichiers à c:\launcher\

            if (String.IsNullOrEmpty(labase))
            {
                labase = @"c:\launcher\";

            }
            string directoryinstance = labase + @"multimc\instances\";
            string directorymods = directoryinstance + @"HS-1.5.3\minecraft\mods\";
            if (checkBox2.Checked == true)
            {

                WebClient webClient = new WebClient();
                webClient.DownloadFile("",  directorymods + "optifine.jar" );



            }
            else {

                File.Delete(directorymods + @"optifine.jar");



            }




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
            checkBox2.Hide();
        

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                label3.Text = "field empty!";
                label3.Show();
                return;

            }
            if (!Directory.Exists(textBox1.Text))
            {
                label3.Text = "non-existent folder";
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

            label3.Text = "Succesfully changed";
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
                    MessageBox.Show("Hello " + authResponse.GetResponse.PlayerName);
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
                        File.WriteAllText(pwd, authResponse.GetResponse.PlayerName);
                        label5.Text = authResponse.GetResponse.PlayerName;
                        MessageBox.Show("Password Remember");
                        // chekbox egal à true
                        //  + "username=@" + authResponse.GetResponse.PlayerName + "@"
                        File.WriteAllText(follow, "true");
                        


                    }
                    else
                    {
                        MessageBox.Show("Password not Remember");
                        if (File.Exists(follow))
                        {
                            File.WriteAllText(follow, "false");
                        }
                    }

                    // écriture du account.json




                    client = "{\"accounts\":[{ \"accessToken\":\" " + authResponse.GetResponse.AccessToken + "\",\"activeProfiles\":\"3c229999486944d68b682e54736a0ddf\", \"clientToken\":\"" + authResponse.GetResponse.ClientToken + "\",\"profiles\":[{\"id\":\"3c229999486944d68b682e54736a0ddf\",\"legacy\": false,\"name\":\"" + authResponse.GetResponse.PlayerName + "\"}],\"user\":{\"id\":\"03929811811abe2a84c9a0ed073b169c\"}, \"username\":\"" + textBox1.Text + "\"}],\"activeAccount\":\"" + textBox1.Text + "\",\"formatVersion\": 2}";
                    Console.WriteLine(authResponse.GetResponse.AccessToken);
                    Console.WriteLine(authResponse.GetResponse.ClientToken);
                    Console.WriteLine(authResponse.GetResponse.PlayerName);
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

                    File.WriteAllText(labase + @"multimc\accounts.json", client);
                    File.WriteAllText(@"c:\Temp\account.dll", authResponse.GetResponse.PlayerName);
                    button5.Show();
                    button7.Show();






















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
            checkBox2.Hide();
            label2.Text = "E-mail";
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
            button13.Hide();
            WebClient webClient = new WebClient();
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
            if (!Directory.Exists(directorylauncher))
            {
                Directory.CreateDirectory(directorylauncher);
            }
            if (!Directory.Exists(directoryconfig))
            {
                Directory.CreateDirectory(directoryconfig);
            }
            if (!Directory.Exists(directoryinstance))
            {
                Directory.CreateDirectory(directoryinstance);
            }
            if (!Directory.Exists(directorylauncher + @"multimc\"))
            {
                Directory.CreateDirectory(directorylauncher + @"multimc\");
            }
            if (install == 1) {



                
                webClient.DownloadProgressChanged += (s, error4) =>
                {
                    label4.Text = "Downloading...";
                    label4.Show();
                    progressBar1.Value = error4.ProgressPercentage;
                };
                webClient.DownloadFileCompleted += (s, error4) =>
                {

                    label4.Hide();
                    progressBar1.Visible = false;
                    finish = 1;
                    button13.Hide();
                    ZipFile.ExtractToDirectory(directorylauncher + @"\multimc.zip", directorylauncher + @"multimc\");
                    button13.Hide();
                    //      File.WriteAllText(@"c:\Temp\patch.txt", "true");
                    //     File.Delete(@"c:\Temp\patch.txt");
                    button12.Hide();
                    label2.Text = "Restarting ...";
                    Thread.Sleep(1000);
                    Application.Restart();





                };

                webClient.DownloadFileAsync(new Uri("http://51.38.213.146/MultiMC.zip"), directorylauncher + @"\multimc.zip");


            }

            if (note == 1)
            {
                webBrowser1.Hide();


            }
            else
            {
                button13.Hide();

                progressBar1.Show();

                if (File.Exists(labase + "multimc"))
                {

                    Directory.Delete(labase + "multimc", true);
                }

                if (File.Exists(directoryconfig + "size.dll"))
                {


                    File.Delete(directoryconfig + "size.dll");

                }




                if (update == true) {
                    if (Directory.Exists(labase + @"\multimc\instances"))
                    {
                        Directory.Delete(labase + @"\multimc\instances", true);
                    }
                    webClient.DownloadProgressChanged += (s, error4) =>
                    {
                        progressBar1.Value = error4.ProgressPercentage;
                        label4.Text = "Downloading...";
                        label4.Show();
                    };
                    webClient.DownloadFileCompleted += (s, error4) =>
                    {
                        label4.Hide();
                        progressBar1.Visible = false;
                        finish = 1;
                        if (!Directory.Exists(directorylauncher + @"multimc\instances\"))
                        {
                            Directory.Delete(labase + @"\multimc\instances", true);
 
                        }
                        if (!Directory.Exists(directorylauncher + @"multimc\instances\"))
                        {

                            Directory.CreateDirectory(directorylauncher + @"multimc\instances\");
                        }
                        ZipFile.ExtractToDirectory(directorylauncher + @"\instances.zip", directorylauncher + @"multimc\instances");

                  //      File.WriteAllText(@"c:\Temp\patch.txt", "true");

                        label2.Text = "Restarting ...";
                        label2.Hide();
                        button13.Hide();
                        Thread.Sleep(1000);
                        Application.Restart();
                        button12.Show();




                    };

                    webClient.DownloadFileAsync(new Uri("http://51.38.213.146/hs.zip"), directorylauncher + @"\instances.zip");
                    button13.Hide();
                }




                //téléchargement du fichier zip de multimc avec l'instance préinstaller
                //décmpression de multimc 

                // Suppression de multimc.zip





            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}



























        

