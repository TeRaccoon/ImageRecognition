namespace ImageRecognition
{
    partial class Start
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.label1 = new System.Windows.Forms.Label();
            this.instruction_lbl = new System.Windows.Forms.Label();
            this.username_txt = new System.Windows.Forms.TextBox();
            this.submit_btn = new System.Windows.Forms.Button();
            this.start_btn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.upload_lbl = new System.Windows.Forms.Label();
            this.counter_lbl = new System.Windows.Forms.Label();
            this.reset_btn = new System.Windows.Forms.Button();
            this.refresh_btn = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.info_img = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.refresh_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.info_img)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 65);
            this.label1.TabIndex = 1;
            this.label1.Text = "GRABLOCK";
            // 
            // instruction_lbl
            // 
            this.instruction_lbl.BackColor = System.Drawing.Color.Transparent;
            this.instruction_lbl.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instruction_lbl.ForeColor = System.Drawing.Color.White;
            this.instruction_lbl.Location = new System.Drawing.Point(32, 161);
            this.instruction_lbl.Name = "instruction_lbl";
            this.instruction_lbl.Size = new System.Drawing.Size(384, 35);
            this.instruction_lbl.TabIndex = 1;
            this.instruction_lbl.UseMnemonic = false;
            // 
            // username_txt
            // 
            this.username_txt.BackColor = System.Drawing.Color.Black;
            this.username_txt.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_txt.ForeColor = System.Drawing.Color.White;
            this.username_txt.Location = new System.Drawing.Point(35, 110);
            this.username_txt.Multiline = true;
            this.username_txt.Name = "username_txt";
            this.username_txt.Size = new System.Drawing.Size(236, 27);
            this.username_txt.TabIndex = 11;
            this.username_txt.Tag = "1";
            this.username_txt.Visible = false;
            // 
            // submit_btn
            // 
            this.submit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submit_btn.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit_btn.ForeColor = System.Drawing.Color.White;
            this.submit_btn.Location = new System.Drawing.Point(277, 110);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(75, 27);
            this.submit_btn.TabIndex = 12;
            this.submit_btn.Tag = "1";
            this.submit_btn.Text = "Submit";
            this.submit_btn.UseVisualStyleBackColor = true;
            this.submit_btn.Visible = false;
            this.submit_btn.Click += new System.EventHandler(this.Submit_btn_Click);
            // 
            // start_btn
            // 
            this.start_btn.BackColor = System.Drawing.Color.Black;
            this.start_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_btn.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_btn.ForeColor = System.Drawing.Color.White;
            this.start_btn.Location = new System.Drawing.Point(32, 109);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(110, 29);
            this.start_btn.TabIndex = 13;
            this.start_btn.Tag = "1";
            this.start_btn.UseVisualStyleBackColor = false;
            this.start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // upload_lbl
            // 
            this.upload_lbl.AutoSize = true;
            this.upload_lbl.BackColor = System.Drawing.Color.Transparent;
            this.upload_lbl.Enabled = false;
            this.upload_lbl.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upload_lbl.ForeColor = System.Drawing.Color.White;
            this.upload_lbl.Location = new System.Drawing.Point(597, 539);
            this.upload_lbl.Name = "upload_lbl";
            this.upload_lbl.Size = new System.Drawing.Size(67, 16);
            this.upload_lbl.TabIndex = 14;
            this.upload_lbl.Tag = "2";
            this.upload_lbl.Text = "Upload";
            this.upload_lbl.Visible = false;
            this.upload_lbl.Click += new System.EventHandler(this.Upload_lbl_Click);
            // 
            // counter_lbl
            // 
            this.counter_lbl.AutoSize = true;
            this.counter_lbl.BackColor = System.Drawing.Color.Transparent;
            this.counter_lbl.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counter_lbl.ForeColor = System.Drawing.Color.White;
            this.counter_lbl.Location = new System.Drawing.Point(12, 543);
            this.counter_lbl.Name = "counter_lbl";
            this.counter_lbl.Size = new System.Drawing.Size(37, 16);
            this.counter_lbl.TabIndex = 15;
            this.counter_lbl.Tag = "2";
            this.counter_lbl.Text = "0/6";
            this.counter_lbl.Visible = false;
            // 
            // reset_btn
            // 
            this.reset_btn.BackColor = System.Drawing.Color.Black;
            this.reset_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reset_btn.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset_btn.ForeColor = System.Drawing.Color.White;
            this.reset_btn.Location = new System.Drawing.Point(32, 156);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(82, 29);
            this.reset_btn.TabIndex = 16;
            this.reset_btn.Tag = "1";
            this.reset_btn.Text = "Reset";
            this.reset_btn.UseVisualStyleBackColor = false;
            this.reset_btn.Click += new System.EventHandler(this.Reset_btn_Click);
            // 
            // refresh_btn
            // 
            this.refresh_btn.BackColor = System.Drawing.Color.Transparent;
            this.refresh_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refresh_btn.BackgroundImage")));
            this.refresh_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.refresh_btn.Enabled = false;
            this.refresh_btn.ErrorImage = global::ImageRecognition.Properties.Resources.pin;
            this.refresh_btn.InitialImage = global::ImageRecognition.Properties.Resources.pin;
            this.refresh_btn.Location = new System.Drawing.Point(681, 281);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(44, 48);
            this.refresh_btn.TabIndex = 17;
            this.refresh_btn.TabStop = false;
            this.refresh_btn.Tag = "2";
            this.refresh_btn.Visible = false;
            this.refresh_btn.Click += new System.EventHandler(this.Refresh_btn_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Enabled = false;
            this.pictureBox6.Location = new System.Drawing.Point(463, 330);
            this.pictureBox6.MaximumSize = new System.Drawing.Size(200, 200);
            this.pictureBox6.MinimumSize = new System.Drawing.Size(200, 200);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(200, 200);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 9;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Tag = "2";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Enabled = false;
            this.pictureBox5.Location = new System.Drawing.Point(248, 330);
            this.pictureBox5.MaximumSize = new System.Drawing.Size(200, 200);
            this.pictureBox5.MinimumSize = new System.Drawing.Size(200, 200);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(200, 200);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Tag = "2";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Enabled = false;
            this.pictureBox4.Location = new System.Drawing.Point(32, 330);
            this.pictureBox4.MaximumSize = new System.Drawing.Size(200, 200);
            this.pictureBox4.MinimumSize = new System.Drawing.Size(200, 200);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(200, 200);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Tag = "2";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Enabled = false;
            this.pictureBox3.Location = new System.Drawing.Point(463, 109);
            this.pictureBox3.MaximumSize = new System.Drawing.Size(200, 200);
            this.pictureBox3.MinimumSize = new System.Drawing.Size(200, 200);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(200, 200);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "2";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Location = new System.Drawing.Point(248, 109);
            this.pictureBox2.MaximumSize = new System.Drawing.Size(200, 200);
            this.pictureBox2.MinimumSize = new System.Drawing.Size(200, 200);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 200);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(32, 109);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(200, 200);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(200, 200);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "2";
            // 
            // info_img
            // 
            this.info_img.BackColor = System.Drawing.Color.Transparent;
            this.info_img.BackgroundImage = global::ImageRecognition.Properties.Resources.pin;
            this.info_img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.info_img.ErrorImage = global::ImageRecognition.Properties.Resources.pin;
            this.info_img.Image = global::ImageRecognition.Properties.Resources.pin;
            this.info_img.InitialImage = global::ImageRecognition.Properties.Resources.pin;
            this.info_img.Location = new System.Drawing.Point(351, 12);
            this.info_img.Name = "info_img";
            this.info_img.Size = new System.Drawing.Size(35, 35);
            this.info_img.TabIndex = 2;
            this.info_img.TabStop = false;
            this.info_img.Click += new System.EventHandler(this.Info_img_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::ImageRecognition.Properties.Resources.black_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(450, 207);
            this.Controls.Add(this.refresh_btn);
            this.Controls.Add(this.reset_btn);
            this.Controls.Add(this.counter_lbl);
            this.Controls.Add(this.upload_lbl);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.submit_btn);
            this.Controls.Add(this.username_txt);
            this.Controls.Add(this.instruction_lbl);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.info_img);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Start";
            this.Tag = "";
            this.Text = "GRABLOCK";
            ((System.ComponentModel.ISupportInitialize)(this.refresh_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.info_img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label instruction_lbl;
        private System.Windows.Forms.TextBox username_txt;
        private System.Windows.Forms.Button submit_btn;
        private System.Windows.Forms.PictureBox info_img;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label upload_lbl;
        private System.Windows.Forms.Label counter_lbl;
        private System.Windows.Forms.Button reset_btn;
        private System.Windows.Forms.PictureBox refresh_btn;
    }
}