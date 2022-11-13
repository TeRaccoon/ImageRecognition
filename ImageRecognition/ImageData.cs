using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognition
{
    internal class ImageData
    {
        string localPath, serverPath;
        public ImageData(string localPath, string serverPath)
        {
            this.localPath = localPath;
            this.serverPath = serverPath;
        }
        public string GetLocalPath()
        {
            return localPath;
        }
        public void SetLocalPath(string localPath)
        {
            this.localPath = localPath;
        }
        public string GetServerPath()
        {
            return serverPath;
        }
        public void SetServerPath(string serverPath)
        {
            this.serverPath = serverPath;
        }
    }
}
