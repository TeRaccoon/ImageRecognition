﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ImageRecognition
{
    public partial class Start : Form
    {
        private readonly List<string> selectedImagePaths = new List<string>();
        private int clickCount = 0;
        public Start()
        {
            InitializeComponent();
            openFileDialog.Title = "Browse Image Files";
            openFileDialog.Filter = "Images(*.BMP; *.JPG; *.PNG;)| *.BMP; *.JPG; *.GIF; *.PNG;";
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
        private void PopulateImages()
        {
            string[] fileNames = new string[6];
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                fileNames[i] = Directory.GetFiles(@"DataFiles")[random.Next(0, Directory.GetFiles(@"DataFiles").Length - 1)];
            }
            int counter = 0;
            foreach (PictureBox pictureBox in this.Controls.OfType<PictureBox>())
            {
                if (pictureBox.Name.Contains("pictureBox"))
                {
                    FileStream fs = new FileStream(fileNames[counter], FileMode.Open);
                    pictureBox.Image = Image.FromStream(fs);
                    pictureBox.ImageLocation = fileNames[counter];
                    fs.Close();
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
        private void ProcessImages()
        {
            for (int i = 0; i < 6; i++)
            {
                selectedImagePaths.AddRange(new ImageComparison().ProcessImage(selectedImagePaths[i]));
            }
            for (int i = 0; i < selectedImagePaths.Count; i++)
            {
                File.Copy(selectedImagePaths[i], @"C:\xampp\htdocs\Res\" + i + ".jpg", true);
            }
        }
        private void Start_btn_Click(object sender, EventArgs e)
        {
            start_btn.Visible = false;
            submit_btn.Visible = true;
            username_txt.Visible = true;
            instruction_lbl.Text = "Please enter a username or email";
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
            if (clickCount == 6)
            {
                instruction_lbl.Text = "Processing selection...";
                ProcessImages();
                instruction_lbl.Text = "Select a master image";
            }
            if (clickCount == 7)
            {
                MD5 md5 = MD5.Create();
                PictureBox pictureBox = sender as PictureBox;
                byte[] hash = md5.ComputeHash(new FileStream(pictureBox.ImageLocation, FileMode.Open));
                string hashString = BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
                File.WriteAllText(@"SecurityData/master.data", hashString);

                GeneratePasswords();
            }
        }
    }
}
