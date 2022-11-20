using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Threading;

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
            else // Prepares the form for the registration process
            {
                Directory.CreateDirectory(@"Render/SelectedImages");
                start_btn.Text = "Register";
                openFileDialog.Title = "Browse Image Files";
                openFileDialog.Filter = "Images (*.BMP; *.JPG; *.PNG;)| *.BMP; *.JPG; *.PNG;";
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                foreach (Control control in this.Controls.OfType<PictureBox>().Where(n => n.Name.Contains("pictureBox"))) // Assigns the click event to each picture box except the information image.
                {
                    control.Click += PictureBox_Click;
                }
            }
        }
        private bool CheckRegistered()
        {
            if (File.Exists(@"SecurityData/key.md5")) // This key will only exist if the user completed registration.
            {
                return true;
            }
            return false;
        }
        private bool RetrieveFile(string serverPath, string localPath)
        {
            WebClient client = new WebClient();
            try
            {
                client.DownloadFile(serverPath, localPath); // Downloads a list of all the image names from the server.
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void PopulateImages() // Fills the 6 picture boxes with random images from the server.
        {
            string[] fileNames = new string[6];
            Random random = new Random();
            bool success = RetrieveFile(@"http://127.0.0.1/data/image_names.data", "image_names.data");
            while (!success)
            {
                DialogResult result = MessageBox.Show("Unable to connect with remote server!", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry)
                {
                    Thread.Sleep(5000);
                    success = RetrieveFile(@"http://127.0.0.1/data/image_names.data", "image_names.data");
                }
                else
                {
                    Environment.Exit(1);
                }
            }

            for (int i = 0; i < 6; i++)
            {
                fileNames[i] = File.ReadAllLines(@"image_names.data")[random.Next(0, File.ReadAllLines(@"image_names.data").Length)]; // Selects 6 random image names from the file.
            }
            int counter = 0;
            foreach (PictureBox pictureBox in this.Controls.OfType<PictureBox>().Where(n => n.Name.Contains("pictureBox"))) // Fills the picture boxes with the selected images.
            {
                pictureBox.ImageLocation = @"http://127.0.0.1/datafiles/" + fileNames[counter];
                counter++;
            }
            File.Delete(@"image_names.data"); // Deletes the image after it has been used.
        }
        private string GeneratePassword()
        {
            Random random = new Random();
            string password = String.Empty;
            string alphabet = File.ReadAllText(@"alphabet.txt"); // Reads file containing all ASCII characters.
            for (int i = 0; i < 12; i++) // Each password is of length 12
            {
                password = String.Concat(password, alphabet[random.Next(0, alphabet.Length)]);
            }
            return password;
        }
        private void ProcessImage()
        {
            selectedImagePaths[(clickCount - 1) * 9] = selectedImagePaths[(clickCount - 1) * 9].Replace(@"\", "/");
            image = new ImageData(selectedImagePaths[(clickCount - 1) * 9].Substring(selectedImagePaths[(clickCount - 1) * 9].LastIndexOf('/') + 1,
                (selectedImagePaths[(clickCount - 1) * 9].Length) - selectedImagePaths[(clickCount - 1) * 9].LastIndexOf('/') - 1), selectedImagePaths[(clickCount - 1) * 9]); // Sets the imagedata classes constructors with the local and server path of the selected image.
            selectedImagePaths.AddRange(new ImageComparison().Start(image));
            for (int i = (clickCount - 1) * 9 ; i < selectedImagePaths.Count; i++) // Stores the selected image and the 8 other similar images into the Render/SelectedImages directory
            {
                WebClient client = new WebClient();
                if (i % 9 == 0) // If the current image is the original selected image.
                {
                    client.DownloadFile(image.GetServerPath(), @"Images\" + image.GetLocalPath());
                }
                else
                {
                    client.DownloadFile(@"http://127.0.0.1/datafiles/" + selectedImagePaths[i], @"Images\" + selectedImagePaths[i]);
                }
            }
        }
        private void HandleSelection(object sender)
        {
            clickCount++;
            switch (clickCount)
            {
                case 6:
                    instruction_lbl.Text = "Select a master image";
                    counter_lbl.Text = clickCount - 6 + "/1";
                    break;
                case 7:
                    PerformSteganography(sender);
                    break;
                default:
                    ProcessImage();
                    counter_lbl.Text = clickCount + "/6";
                    break;
            }
        }
        private void PerformSteganography(object sender)
        {
            PictureBox pictureBox = sender as PictureBox;
            WebClient client = new WebClient();
            FileStream fs = new FileStream(@"master.jpg", FileMode.Open);

            ChangePictureBoxes(false);

            instruction_lbl.Text = "Processing selections...";
            client.DownloadFile(pictureBox.ImageLocation, "master.jpg");
            StoreHash(fs);
            fs.Close(); // Closes stream so the file can be deleted.
            File.Delete(fs.Name);

            for (int i = 0; i < 54; i++)
            {
                Bitmap image = new Steganography().EmbedText(GeneratePassword(), (Bitmap)Image.FromFile(Directory.GetFiles(@"Images\")[i]));
                image.Save(@"Render\Res\" + i + ".jpg");
            }
        }
        private void ChangePictureBoxes(bool enabled)
        {
            foreach (PictureBox control in this.Controls.OfType<PictureBox>())
            {
                if (control.Name.Contains("pictureBox"))
                {
                    control.Visible = enabled;
                    control.Enabled = enabled;
                }
            }
        }
        private void ChangeDisplayMode(int mode)
        {
            foreach (Control control in this.Controls.OfType<Control>().Where(t => t.Tag != null))
            {
                control.Enabled = control.Visible = Convert.ToInt32(control.Tag) == mode;
            }
        }
        private void StoreHash(FileStream fs)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(fs);
            string hashString = BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
            File.WriteAllText(@"SecurityData/key.md5", hashString);
        }

                /*************************
                        * EVENTS *
                *************************/

        private void Info_img_Click(object sender, EventArgs e)
        {
            Process.Start(@"readme.txt");
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            selectedImagePaths.Add(pictureBox.ImageLocation);
            PopulateImages();
            HandleSelection(sender);
        }
        private void Refresh_btn_Click(object sender, EventArgs e)
        {
            PopulateImages();
        }
        private void Reset_btn_Click(object sender, EventArgs e)
        {
            foreach (string file in Directory.GetFiles(@"Render/SelectedImages/"))
            {
                File.Delete(file);
            }
            foreach (string file in Directory.GetFiles(@"Images/"))
            {
                File.Delete(file);
            }
            foreach (string file in Directory.GetFiles(@"SecurityData/"))
            {
                File.Delete(file);
            }
            foreach (string file in Directory.GetFiles(@"Render/Res/"))
            {
                File.Delete(file);
            }
            start_btn.Text = "Register";
            reset_btn.Visible = false;
            reset_btn.Enabled = false;
            this.Refresh();
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
                start_btn.Enabled = false;
                reset_btn.Visible = false;
                reset_btn.Enabled = false;
                submit_btn.Visible = true;
                username_txt.Visible = true;
                instruction_lbl.Text = "Please enter a username or email";
            }
        }
        private void Submit_btn_Click(object sender, EventArgs e)
        {
            if (username_txt.Text == string.Empty)
            {
                MessageBox.Show("Username / email cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.Size = new Size(760, 660);
                instruction_lbl.Location = new Point(185, 539);
                ChangeDisplayMode(2);
                instruction_lbl.Text = "Please select 6 of the images from above or upload your own";
                ChangePictureBoxes(true);
                PopulateImages();
            }
        }
        private void Upload_lbl_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePaths.Add(openFileDialog.FileName);
            }
            HandleSelection(null);
        }
    }
}
