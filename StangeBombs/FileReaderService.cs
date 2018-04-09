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
           string result = String.Empty;
                
               using (StreamReader sr = new StreamReader(location))
               {
                    result = sr.ReadToEnd();
               }
           

            return result;
        }
    }
}
