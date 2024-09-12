using System;
using System.IO;
using System.Windows.Forms;

namespace AutoService
{
    internal class FSWork
    {
        static public bool IsFileExist(string path)
        {
            bool result = false;
            if (File.Exists(path))
            {
                result = true;
            }
            return result;
        }

        static public byte[] GetImage() 
        {
            byte[] result = null;
            OpenFileDialog ofd = new OpenFileDialog();
            string filename = string.Empty;
            ofd.Filter = "JPG files(*.JPG)|*.jpg|All files(*.*)|(*.*)";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
            }
            else return result;
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                result= new byte[fs.Length];
                fs.Read(result, 0, result.Length);
            }
            return result;
        }
    }
}
