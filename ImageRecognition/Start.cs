using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ImageRecognition
{
    public partial class Start : Form
    {
        ImageData image;
        private readonly List<string> selectedImagePaths = new List<string>();
        private int clickCount = 0;
        public Start()
        {
            InitializeComponent();
            if (CheckRegistered())
            {
                start_btn.Text = "Login";
            }
            else
            {
                Directory.CreateDirectory(@"SelectedImages");
                start_btn.Text = "Register";
                openFileDialog.Title = "Browse Image Files";
                openFileDialog.Filter = "Images(*.BMP; *.JPG; *.PNG;)| *.BMP; *.JPG; *.PNG;";
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                foreach (Control control in this.Controls)
                {
                    if (control is PictureBox && control.Name.Contains("pictureBox"))
                    {
                        control.Click += PictureBox_Click;
                    }
                }
            }
        }
        private bool CheckRegistered()
        {
            if (File.Exists(@"SecurityData/key.md5"))
            {
                return true;
            }
            return false;
        }
        private void PopulateImages()
        {
            string[] fileNames = new string[6];
            WebClient client = new WebClient();
            client.DownloadFile(@"http://127.0.0.1/data/image_names.data", "image_names.data");
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                fileNames[i] = File.ReadAllLines(@"image_names.data")[random.Next(0, File.ReadAllLines(@"image_names.data").Length)];
            }
            int counter = 0;
            foreach (PictureBox pictureBox in this.Controls.OfType<PictureBox>())
            {
                if (pictureBox.Name.Contains("pictureBox"))
                {
                    pictureBox.ImageLocation = @"http://127.0.0.1/datafiles/" + fileNames[counter];
                }
                counter++;
            }
        }
        private string[] GeneratePasswords()
        {
            Random random = new Random();
            string[] passwords = new string[54];
            string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!£$%&*(),.@";
            for (int passwordIndex = 0; passwordIndex < 54; passwordIndex++)
            {
                string password = string.Empty;
                for (int i = 0; i < 12; i++)
                {
                    password += alphabet[random.Next(0, alphabet.Length)];
                }
                passwords[passwordIndex] = password;
            }
            return passwords;
        }
        private void ProcessImage() //PROCESS IMAGE STRAIGHT AFTER SELECTING EACH ONE
        {
            image = new ImageData(selectedImagePaths[(clickCount - 1) * 9].Substring(selectedImagePaths[(clickCount - 1) * 9].LastIndexOf('/') + 1, (selectedImagePaths[(clickCount - 1) * 9].Length) - selectedImagePaths[(clickCount - 1) * 9].LastIndexOf('/') - 1), selectedImagePaths[(clickCount - 1) * 9]);
            selectedImagePaths.AddRange(new ImageComparison().Start(image));
            for (int i = (clickCount - 1) * 9 ; i < selectedImagePaths.Count; i++)
            {
                WebClient client = new WebClient();
                if (i % 9 == 0)
                {
                    client.DownloadFile(image.GetServerPath(), @"Images\" + image.GetLocalPath());
                }
                else
                {
                    client.DownloadFile(@"http://127.0.0.1/datafiles/" + selectedImagePaths[i], @"Images\" + selectedImagePaths[i]);
                }
            }
        }
        private void Start_btn_Click(object sender, EventArgs e)
        {
            if (CheckRegistered())
            {
                Process.Start(@"E:\University\Course Folders\Year 3\FYP\Code\image_recognition\ImageRecognition\ImageRecognition\bin\Debug\Render\GRABLOK.exe");
            }
            else
            {
                start_btn.Visible = false;
                submit_btn.Visible = true;
                username_txt.Visible = true;
                instruction_lbl.Text = "Please enter a username or email";
            }
        }
        private void Submit_btn_Click(object sender, EventArgs e)
        {
            upload_lbl.Visible = true;
            upload_lbl.Enabled = true;
            counter_lbl.Visible = true;
            submit_btn.Visible = false;
            username_txt.Visible = false;
            instruction_lbl.Text = "Please select 6 of the images from above or upload your own";
            foreach (PictureBox pictureBox in this.Controls.OfType<PictureBox>())
            {
                if (pictureBox.Name.Contains("pictureBox"))
                {
                    pictureBox.Enabled = true;
                }
            }
            PopulateImages();
        }
        private void Info_img_Click(object sender, EventArgs e)
        {
            Process.Start(@"readme.txt");
        }

        private void Upload_lbl_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePaths.Add(openFileDialog.FileName);
            }
            HandleSelection(null);
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            selectedImagePaths.Add(pictureBox.ImageLocation);
            PopulateImages();
            HandleSelection(sender);
        }
        private void HandleSelection(object sender)
        {
            clickCount++;
            counter_lbl.Text = clickCount + "/6";
            ProcessImage();
            if (clickCount == 6)
            {
                instruction_lbl.Text = "Processing selection...";
                instruction_lbl.Text = "Select a master image";
            }
            if (clickCount == 7)
            {
                PictureBox pictureBox = sender as PictureBox;
                WebClient client = new WebClient();
                client.DownloadFile(pictureBox.ImageLocation, "master.jpg");
                MD5 md5 = MD5.Create();
                FileStream fs = new FileStream(@"master.jpg", FileMode.Open);
                byte[] hash = md5.ComputeHash(fs);
                fs.Close();
                File.Delete(@"master.jpg");
                string hashString = BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
                File.WriteAllText(@"SecurityData/key.md5", hashString);

                string[] toEmbed = GeneratePasswords();

                // All of the steganography and DWT

                //Process render = Process.Start()
            }
        }
    }
}
