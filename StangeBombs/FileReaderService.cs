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
            try
            {

                using (StreamReader sr = new StreamReader(location))

                {
                    result = sr.ReadToEnd();
                    if (!File.Exists(location))
                    {
                        result = File.ReadAllText(location);
                    }

                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"The file in {location} not found.");
            }
            catch (IOException)
            {
                Console.WriteLine("Error opening file");
            }

            return result;
        }
    }
}
