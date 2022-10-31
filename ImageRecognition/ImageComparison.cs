using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace ImageRecognition
{
    class ImageComparison
    {

        public string[] ProcessImage(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            Bitmap target = new Bitmap(Image.FromStream(fs), new Size(32, 32));
            fs.Close();
            int redCount = 0, greenCount = 0, blueCount = 0, blackWhiteCount = 0;

            for (int y = 0; y < target.Width; y++)
            {
                for (int x = 0; x < target.Height; x++)
                {
                    Color pixel = target.GetPixel(x, y);
                    if (pixel.R > pixel.G && pixel.R > pixel.B && pixel.R > 20)
                    {
                        redCount++;
                    }
                    else if (pixel.G > pixel.R && pixel.G > pixel.B && pixel.G > 20)
                    {
                        greenCount++;
                    }
                    else if (pixel.B > pixel.R && pixel.B > pixel.G && pixel.B > 20)
                    {
                        blueCount++;
                    }
                    else
                    {
                        blackWhiteCount++;
                    }
                }
            }
            return CompareImages(new int[] { redCount, greenCount, blueCount, blackWhiteCount });
        }
        private string[] CompareImages(int[] colourValues)
        {
            List<int> scores = new List<int>();
            string[] colourData = File.ReadAllLines(@"Data/codes.data");
            string[] results = new string[8];
            for (int imageIndex = 0; imageIndex < colourData.Length; imageIndex++)
            {
                string currentData = Regex.Replace(colourData[imageIndex], "[^. .0-9]", "");
                string[] currentColourValue = currentData.Split(' ');
                scores.Add(Math.Abs(colourValues[0] - Convert.ToInt32(currentColourValue[0])) + Math.Abs(colourValues[1] - Convert.ToInt32(currentColourValue[1])) + Math.Abs(colourValues[2] - Convert.ToInt32(currentColourValue[2])) + Math.Abs(colourValues[3] - Convert.ToInt32(currentColourValue[3])));
            }
 
            for (int i = 0; i < 8; i++)
            {
                if (scores.Min() == 0)
                {
                    scores.RemoveAt(scores.IndexOf(scores.Min()));
                    i--;
                }
                else
                {
                    results[i] = Directory.GetFiles(@"DataFiles")[scores.IndexOf(scores.Min())];
                    scores.RemoveAt(scores.IndexOf(scores.Min()));
                }
            }
            return results;
        }

        public void UpdateDateFile()
        {
            for (int imageIndex = 0; imageIndex < Directory.GetFiles(@"DataFiles").Length; imageIndex++)
            {
                Bitmap target = new Bitmap(Image.FromFile(Directory.GetFiles(@"DataFiles")[imageIndex]), new Size(32, 32));
                int redCount = 0, greenCount = 0, blueCount = 0, blackWhiteCount = 0;

                for (int y = 0; y < target.Width; y++)
                {
                    for (int x = 0; x < target.Height; x++)
                    {
                        Color pixel = target.GetPixel(x, y);
                        if (pixel.R > pixel.G && pixel.R > pixel.B && pixel.R > 20)
                        {
                            redCount++;
                        }
                        else if (pixel.G > pixel.R && pixel.G > pixel.B && pixel.G > 20)
                        {
                            greenCount++;
                        }
                        else if (pixel.B > pixel.R && pixel.B > pixel.G && pixel.B > 20)
                        {
                            blueCount++;
                        }
                        else
                        {
                            blackWhiteCount++;
                        }
                    }
                }
                File.AppendAllText(@"Data/codes.data", "R:" + redCount + " G:" + greenCount + " B:" + blueCount + " BW:" + blackWhiteCount + "\n");
            }
            
        }
    }
}