
namespace ImageRecognition
{
    partial class GRABLOCK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GRABLOCK));
            this.label1 = new System.Windows.Forms.Label();
            this.category_slct = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.select_btn = new System.Windows.Forms.Button();
            this.selected_lbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.upload_lbl = new System.Windows.Forms.Label();
            this.view_pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "GRABLOCK";
            // 
            // category_slct
            // 
            this.category_slct.BackColor = System.Drawing.Color.Black;
            this.category_slct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.category_slct.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_slct.ForeColor = System.Drawing.Color.White;
            this.category_slct.FormattingEnabled = true;
            this.category_slct.Items.AddRange(new object[] {
            "Universe",
            "Plant",
            "Dog",
            "Cat",
            "Moose",
            "Earth",
            "Flower",
            "Forest",
            "Field",
            "Beach",
            "Mountain",
            "Car"});
            this.category_slct.Location = new System.Drawing.Point(21, 136);
            this.category_slct.Name = "category_slct";
            this.category_slct.Size = new System.Drawing.Size(231, 21);
            this.category_slct.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Preselected Image Categories (Pick 6)";
            // 
            // select_btn
            // 
            this.select_btn.BackColor = System.Drawing.Color.Black;
            this.select_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select_btn.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select_btn.ForeColor = System.Drawing.Color.White;
            this.select_btn.Location = new System.Drawing.Point(258, 136);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(75, 21);
            this.select_btn.TabIndex = 3;
            this.select_btn.Text = "Select";
            this.select_btn.UseVisualStyleBackColor = false;
            this.select_btn.Click += new System.EventHandler(this.select_btn_Click);
            // 
            // selected_lbl
            // 
            this.selected_lbl.AutoSize = true;
            this.selected_lbl.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selected_lbl.ForeColor = System.Drawing.Color.White;
            this.selected_lbl.Location = new System.Drawing.Point(359, 140);
            this.selected_lbl.Name = "selected_lbl";
            this.selected_lbl.Size = new System.Drawing.Size(95, 13);
            this.selected_lbl.TabIndex = 4;
            this.selected_lbl.Text = "Selected: 0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::ImageRecognition.Properties.Resources.shortcut_script_app;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::ImageRecognition.Properties.Resources.shortcut_script_app;
            this.pictureBox1.InitialImage = global::ImageRecognition.Properties.Resources.shortcut_script_app;
            this.pictureBox1.Location = new System.Drawing.Point(421, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 92);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // upload_lbl
            // 
            this.upload_lbl.AutoSize = true;
            this.upload_lbl.Font = new System.Drawing.Font("Lucida Console", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upload_lbl.ForeColor = System.Drawing.Color.White;
            this.upload_lbl.Location = new System.Drawing.Point(12, 333);
            this.upload_lbl.Name = "upload_lbl";
            this.upload_lbl.Size = new System.Drawing.Size(151, 13);
            this.upload_lbl.TabIndex = 6;
            this.upload_lbl.Text = "Or upload your own";
            this.upload_lbl.Click += new System.EventHandler(this.upload_lbl_Click);
            // 
            // view_pic
            // 
            this.view_pic.Location = new System.Drawing.Point(361, 188);
            this.view_pic.Name = "view_pic";
            this.view_pic.Size = new System.Drawing.Size(160, 160);
            this.view_pic.TabIndex = 7;
            this.view_pic.TabStop = false;
            // 
            // GRABLOCK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(533, 360);
            this.Controls.Add(this.view_pic);
            this.Controls.Add(this.upload_lbl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.selected_lbl);
            this.Controls.Add(this.select_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.category_slct);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GRABLOCK";
            this.Text = "GRABLOCK";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox category_slct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button select_btn;
        private System.Windows.Forms.Label selected_lbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label upload_lbl;
        public System.Windows.Forms.PictureBox view_pic;
    }
}

