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
        //Guid Hakkında Not:
        //Guid.NewGuid().ToString() yazarsak sonuç : 00000000-0000-0000-0000-000000000000 şeklinde olur.
        //Guid.NewGuid().ToString("N") yazarsak sonuç : 00000000000000000000000000000000 şeklinde olur.
        //yani - (tire)'leri kaldırarak yazıyor.
        //bunun ToString("D"),ToString("B"),ToString("P"),ToString("X") gibi farklı formatlarda kullanımları var.
        //ToString("D") ile ToString() aynı aslında,
        //("B"): sonucu { } içine yazıyor, ("P"): sonucu ( ) içine yazıyor.
        //("X") ise {0x00000000, 0x0000, 0x0000 {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}} gibi bi sonuç dönderiyor.

        private static string _wwwRoot = "wwwroot";

        public static string SaveImageFile(string fileName, IFormFile extension)
        {
            string resimUzantisi = Path.GetExtension(extension.FileName);
            string yeniResimAdi = string.Format("{0:D}{1}", Guid.NewGuid(), resimUzantisi);
            string imageKlasoru = Path.Combine(_wwwRoot, fileName);
            string tamResimYolu = Path.Combine(imageKlasoru, yeniResimAdi);
            string webResimYolu = string.Format("/" + fileName + "/{0}", yeniResimAdi);
            if (!Directory.Exists(imageKlasoru))
                Directory.CreateDirectory(imageKlasoru);

            using (var fileStream = File.Create(tamResimYolu))
            {
                extension.CopyTo(fileStream);
                fileStream.Flush();
            }
            return webResimYolu;
        }

        public static bool DeleteImageFile(string fileName)
        {
            string fullPath = Path.Combine(fileName);
            if (File.Exists(_wwwRoot + fullPath))
            {
                File.Delete(_wwwRoot + fullPath);
                return true;
            }
            return false;
        }

        //static string directory = Directory.GetCurrentDirectory() + @"\wwwroot\";
        //static string path = @"Images\";
        //public static string Add(IFormFile file)
        //{
        //    string extension = Path.GetExtension(file.FileName).ToUpper();
        //    string newFileName = Guid.NewGuid().ToString("N") + extension;
        //    if (!Directory.Exists(directory + path))
        //    {
        //        Directory.CreateDirectory(directory + path);
        //    }
        //    using (FileStream fileStream = File.Create(directory + path + newFileName))
        //    {
        //        file.CopyTo(fileStream);
        //        fileStream.Flush();
        //    }
        //    return (path + newFileName).Replace("\\", "/");
        //}
        //public static string Update(IFormFile file, string oldImagePath)
        //{
        //    Delete(oldImagePath);
        //    return Add(file);
        //}
        //public static void Delete(string imagePath)
        //{
        //    if (File.Exists(directory + imagePath.Replace("/", "\\"))
        //        && Path.GetFileName(imagePath) != "default.png")
        //    {
        //        File.Delete(directory + imagePath.Replace("/", "\\"));
        //    }
        //}

        /*public static string CreateFilePath2(IFormFile file)
        {
            
            FileOperations fileOperations = new FileOperations();

            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            
            

            var newPath = Guid.NewGuid().ToString("N") + fileExtension + "T";

            string path = Environment.CurrentDirectory + @"\wwwroot\Images";

            string result = $@"{path}\{newPath}";
            return result;
        }*/
        /*
        public static (string newPath, string Path2) CreateFilePath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;

            var creatingUniqueFilename = Guid.NewGuid().ToString("N")
               + "_" + DateTime.Now.Month + "_"
               + DateTime.Now.Day + "_"
               + DateTime.Now.Year + fileExtension;


            string path = Environment.CurrentDirectory + @"\wwwroot\Images";

            string result = $@"{path}\{creatingUniqueFilename}";

            return (result, $"\\Images\\{creatingUniqueFilename}");
        }*/
        /*public static string CreateImageFile(IFormFile file)
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
        }*/
        /*public static string AddAsync(IFormFile file)
        {
            var result = CreateFilePath(file);
            try
            {
                var sourcepath = Path.GetTempFileName();
                if (file.Length > 0)
                    using (var stream = new FileStream(sourcepath, FileMode.Create))
                        file.CopyTo(stream);

                File.Move(sourcepath, result.newPath);
            }
            catch (Exception exception)
            {

                return exception.Message;
            }

            return result.Path2;
        }*/
        /*public static IResult Delete(string path)
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
        }*/

        /*
        public static IResult DeleteAsync(string path)
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
        /*public static string UpdateAsync2(string Path, IFormFile file)
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
        }*/
        /*
        public static string UpdateAsync(string sourcePath, IFormFile file)
        {
            var result = CreateFilePath(file);

            try
            {
                //File.Copy(sourcePath,result);

                if (sourcePath.Length > 0)
                {
                    using (var stream = new FileStream(result.newPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                File.Delete(sourcePath);
            }
            catch (Exception excepiton)
            {
                return excepiton.Message;
            }

            return result.Path2;
        }*/
    }
}
