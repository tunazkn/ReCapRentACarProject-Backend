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
    }
}
