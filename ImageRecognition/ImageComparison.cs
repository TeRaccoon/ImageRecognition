using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net;

namespace ImageRecognition
{
    internal class ImageComparison
    {

        public string[] Start(string path)
        {
            LoadData();
            string[] data = ProcessImage(path);
            RemoveData();
            return data;
        }
        private void LoadData()
        {
            WebClient client = new WebClient();
            client.DownloadFile(@"http://127.0.0.1/data/image_names.data", "image_names.data");
            client.DownloadFile(@"http://127.0.0.1/data/codes.data", "codes.data");
        }
        private void RemoveData()
        {
            File.Delete(@"image_names.data");
            File.Delete(@"codes_data");
        }
        private string[] ProcessImage(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            Bitmap target = new Bitmap(Image.FromStream(fs), new Size(32, 32)); // Downscaled image. Any larger resolution has a minimal impact.
            fs.Close();
            int redCount = 0, greenCount = 0, blueCount = 0, blackWhiteCount = 0;
            for (int y = 0; y < target.Width; y++)
            {
                for (int x = 0; x < target.Height; x++)
                {
                    Color pixel = target.GetPixel(x, y);
                    if (pixel.R > pixel.G && pixel.R > pixel.B && pixel.R > 20) // Any value less than 20 can still be considered still gray.
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
            string[] colourData = File.ReadAllLines(@"codes.data");
            string[] results = new string[8];
            // Finds the colour value difference between the original and to compare images and adds it to the scores list.
            for (int imageIndex = 0; imageIndex < colourData.Length; imageIndex++)
            {
                string currentData = Regex.Replace(colourData[imageIndex], "[^. .0-9]", ""); // Removes redundant data.
                string[] currentColourValue = currentData.Split(' ');
                scores.Add(Math.Abs(colourValues[0] - Convert.ToInt32(currentColourValue[0])) + Math.Abs(colourValues[1] - Convert.ToInt32(currentColourValue[1])) + Math.Abs(colourValues[2] - Convert.ToInt32(currentColourValue[2])) + Math.Abs(colourValues[3] - Convert.ToInt32(currentColourValue[3])));
            }

            for (int i = 0; i < 8; i++)
            {
                if (scores.Min() == 0) // Prevents the same image from being used twice.
                {
                    scores.RemoveAt(scores.IndexOf(scores.Min()));
                    i--;
                }
                else
                {
                    results[i] = File.ReadAllLines(@"image_names.data")[scores.IndexOf(scores.Min())];
                    scores.RemoveAt(scores.IndexOf(scores.Min()));
                }
            }
            return results;
        }

        public void UpdateDateFile() // Used to make sure the image directory and the data file are synced.
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