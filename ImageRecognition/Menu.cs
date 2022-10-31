using System;
using System.Windows.Forms;

namespace ImageRecognition
{
    public partial class GRABLOCK : Form
    {
        GetImage getImage = new GetImage();
        int selectionCounter = 0;
        public GRABLOCK()
        {
            InitializeComponent();
            openFileDialog.Title = "Browse Image Files";
            openFileDialog.Filter = "Images(*.BMP; *.JPG; *.PNG;)| *.BMP; *.JPG; *.GIF; *.PNG;";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            if (category_slct.SelectedIndex != -1)
            {
                selectionCounter++;
                selected_lbl.Text = "Selected: " + selectionCounter;
                getImage.GetLinks(category_slct.Text);
            }
            if (selectionCounter == 6)
            {
                System.Diagnostics.Process.Start("http://localhost/GRABLOCK/");
            }
        }

        private void upload_lbl_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //new ImageComparison(openFileDialog.FileName);
            }
        }
    }
}
