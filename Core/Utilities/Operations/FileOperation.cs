using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Operations
{
    public class FileOperations
    {
        public static string CreateFilePath(IFormFile file)
        {
            FileOperations fileOperations = new FileOperations();

            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            
            //Guid.NewGuid().ToString() yazarsak sonuç : 00000000-0000-0000-0000-000000000000 şeklinde olur.
            //Guid.NewGuid().ToString("N") yazarsak sonuç : 00000000000000000000000000000000 şeklinde olur.
            //yani - (tire)'leri kaldırarak yazıyor.
            //bunun ToString("D"),ToString("B"),ToString("P"),ToString("X") gibi farklı formatlarda kullanımları var.
            //ToString("D") ile ToString() aynı aslında,
            //("B"): sonucu { } içine yazıyor, ("P"): sonucu ( ) içine yazıyor.
            //("X") ise {0x00000000, 0x0000, 0x0000 {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}} gibi bi sonuç dönderiyor.
            var newPath = Guid.NewGuid().ToString("N") + fileExtension + "T";

            string path = Environment.CurrentDirectory + @"\wwwroot\Images";

            string result = $@"{path}\{newPath}";
            return result;
        }
        public static string CreateImageFile(IFormFile file)
        {
            var filePath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var uploading = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(uploading);
                }
            }
            var result = CreateFilePath(file);
            File.Move(filePath, result);
            return result;
        }
        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        public static string Update(string Path, IFormFile file)
        {
            var result = CreateFilePath(file).ToString();
            if (Path.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(Path);
            return result;
        }
    }
}
