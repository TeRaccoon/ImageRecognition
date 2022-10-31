using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System;

namespace ImageRecognition
{
    class GetImage
    {
        string url;
        int totalCounter = 0;
        public void GetLinks(string topic)
        {
            url = "https://www.google.com/search?q=" + topic + "&tbm=isch";
            string data = new WebClient().DownloadString(url);
            List<string> links = data.Split(new string[] { "src" }, StringSplitOptions.None).ToList();
            links.RemoveRange(0, 2);
            for (int i = 0; i < 9; i++)
            {
                links[i] = links[i].Substring(2, links[i].IndexOf('>') - 4);
                byte[] image = ReadImage(links[i]);
                using (var ms = new MemoryStream(image))
                {
                    Image img = Image.FromStream(ms);
                    img.Save(@"C:\xampp\htdocs\Res\" + totalCounter + @".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    totalCounter++;
                }
            }
        }
        private byte[] ReadImage(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                    return null;
                using (var sr = new BinaryReader(dataStream))
                {
                    byte[] bytes = sr.ReadBytes(100000);

                    return bytes;
                }
            }
        }
    }
}
