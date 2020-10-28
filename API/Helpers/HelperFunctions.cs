using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace API.Helpers
{
    public class HelperFunctions
    {
        public HelperFunctions(IConfiguration config)
        {
            _config = config;
        }
        public static IConfiguration _config;
        private static Random random = new Random();
        public static string GenerateCode(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        public static string SaveImage(string base64, string FilePath, string strFileName)
        {
            //Get the file type to save in
            var FilePathWithExtension = "";
            string localBase64 = "";

            if (base64.Contains("data:image/jpeg;base64,"))
            {
                FilePathWithExtension = FilePath + strFileName + ".jpg";
                localBase64 = base64.Replace("data:image/jpeg;base64,", "");
            }
            else if (base64.Contains("data:image/png;base64,"))
            {
                FilePathWithExtension = FilePath + strFileName + ".png";
                localBase64 = base64.Replace("data:image/png;base64,", "");
            }
            else if (base64.Contains("data:image/bmp;base64"))
            {
                FilePathWithExtension = FilePath + strFileName + ".bmp";
                localBase64 = base64.Replace("data:image/bmp;base64", "");
            }
            else if (base64.Contains("data:application/msword;base64,"))
            {
                FilePathWithExtension = FilePath + strFileName + ".doc";
                localBase64 = base64.Replace("data:application/msword;base64,", "");
            }
            else if (base64.Contains("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64,"))
            {
                FilePathWithExtension = FilePath + strFileName + ".docx";
                localBase64 = base64.Replace("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document;base64,", "");
            }
            else if (base64.Contains("data:application/pdf;base64,"))
            {
                FilePathWithExtension = FilePath + strFileName + ".pdf";
                localBase64 = base64.Replace("data:application/pdf;base64,", "");
            }

            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(localBase64)))
            {
                using (FileStream fs = new FileStream(FilePathWithExtension, FileMode.Create, FileAccess.Write))
                {
                    //Create the specified directory if it does not exist
                    var photofolder = System.IO.Path.GetDirectoryName(FilePathWithExtension);
                    if (!Directory.Exists(photofolder))
                    {
                        Directory.CreateDirectory(photofolder);
                    }

                    ms.WriteTo(fs);
                    fs.Close();
                    ms.Close();
                }
            }

            return FilePathWithExtension;
        }


        public static string ConvImage(string img)
        {
            var servername = _config["AppSettings:FolderForTccDocx"];
            var path = servername + img;

            byte[] imageBytes = System.IO.File.ReadAllBytes(path);
            string base64String = Convert.ToBase64String(imageBytes);
            string strpath = Path.GetExtension(path);
            String fileExtension = Path.GetExtension(path);
            string imageDataURL = "";

            if (fileExtension == ".pdf")

            {
                imageDataURL = string.Format("data:application/pdf;base64,{0}", base64String);
            }
            else if (fileExtension == ".png")
            {
                imageDataURL = string.Format("data:image/png;base64,{0}", base64String);
            }

            else if (fileExtension == ".jpg" || fileExtension == ".jpeg")
            {
                imageDataURL = string.Format("data:image/jpeg;base64,{0}", base64String);
            }
            return imageDataURL;
        }
        public static string CreateDirectory(string DirectoryName)
        {
            if (!Directory.Exists(@"C:/test/" + DirectoryName))
            {
                Directory.CreateDirectory(@"C:/test/" + DirectoryName);
            }

            return Path.GetDirectoryName(DirectoryName);
        }
    }
}
