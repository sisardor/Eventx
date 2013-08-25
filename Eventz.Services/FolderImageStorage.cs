using Eventz.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventz.Services
{
    public class FolderImageStorage
    {
        public void AddImage(Image image, byte[] data)
        {
            string path = @"Images/";
            path += image.Event.StartTime.ToString("MM-dd-yyyy") + @"/";
            path += image.Id + ".png";

            using (var stream = File.Create(path))
            {
                stream.Write(data, 0, data.Length);
            }
        }

        public void GetImage(Image image)
        {
            string path = @"Images/";
            path += image.FilePath + @"/" + image.Id + ".png";

            File.Open(path, FileMode.Open);
        }
    }
}
