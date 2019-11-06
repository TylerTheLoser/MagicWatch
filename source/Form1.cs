using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace MTG_App
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public class Item //this class will deserialize the json key that the WebClient retrieves.
        {
            //these are the only three keys for the authentication
            public string token { get; set; } //get the value of the token key
            public string message { get; set; } //get the value of the message key
            public string status { get; set; } //get the value of the status key
        }

        //we use an auto implementation property to get the values of the email and password outside this method
        //this will GET the yourEmail/yourPass string that is SET elsewhere (see below)
        string yourEmail { get; set; }
        string yourPass { get; set; }
        public string authToken { get; set; }

        //the authentication method
        public void start_get()
        {
            //since i know this throws an error if the email/pass combo doesn't work, i nested it in a try/catch
            //basically, a try will TRY the code you nest in it, and if it CATCHES the error specified below, it won't crash the program and throw the code you put in place IF the error happens!
            try
            {
                //this downloads the info from the given URL
                //it's concatenated with the yourEmail and yourPass values that are GET and SET elsewhere!
                string json = new WebClient().DownloadString("https://www.echomtg.com/api/user/auth/email=" + yourEmail + "&type=curl&password=" + yourPass);
                
                //this deserializes the JSON keys that are specified in the Item class for the URL downloaded above
                Item items = JsonConvert.DeserializeObject<Item>(json);

                //more of a debug thing here...
                //i wrote this to get a response in the console window to ensure i'm getting the values back
                Console.WriteLine("Your token is " + items.token.ToString());
                Console.WriteLine("message: " + items.message.ToString());
                Console.WriteLine("status: " + items.status.ToString());

                //this initializes a new instance of the MainWindow
                MainWindow mainwin = new MainWindow();

                mainwin.dumbToken = items.token.ToString(); //gives value to a variable in MainWindow

                //TODO CLOSE THE WINDOW
                
                //this opens the MainWindow
                mainwin.Show();
                this.Hide(); //shitty lol
            }
            //since i know the error that happens when the credentials are wrong, i catch the error before it crashes my program
            catch (System.NullReferenceException)
            {
                //just a dumb way of showing you got an error.
                MessageBox.Show("Authentication Error. Please try your email/password again...", "Authentication Error");
            }
                   
        }
        //the shit that happens when you click the button
        private void btnLogin_Click(object sender, EventArgs e)
        {
            yourEmail = txtEmail.Text; //this is where the yourEmail string is SET!
            yourPass = txtPassword.Text; //this is where yourPass is SET!
            if (String.IsNullOrEmpty(txtEmail.Text)) //if the the textbox value is null or empty...
            {
                MessageBox.Show("Please enter an email...", "Missing email"); //throw the error
            } else if (String.IsNullOrEmpty(txtPassword.Text)) { //if the textbox value HERE is null or empty...
                MessageBox.Show("Please enter a password...", "Missing password"); //throw the error
            } else //otherwise...
            {
                start_get(); //run the authentication method
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://www.echomtg.com/register/");
            Process.Start(sInfo);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://www.echomtg.com/user/forgot_password/");
            Process.Start(sInfo);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
