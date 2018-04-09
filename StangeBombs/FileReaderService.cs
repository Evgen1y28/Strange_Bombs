using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StangeBombs
{
    public interface IFileReaderService
    {
        string GetFileContent(string location, string fileName);

    }

    public class FileReaderService : IFileReaderService
    {
        public string GetFileContent(string location, string fileName)
        {
            try
            {
                fileName = String.Empty;
               using (StreamReader sr = new StreamReader(location))
               {
                    fileName = sr.ReadToEnd();
               }
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return fileName;
        }
    }
}
