using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace StangeBombs
{
    public interface IFinderService
    {
        string FindFile(string locationToSearch, string fileName);
    }

    public class FinderService : IFinderService
    {

        public string FindFile(string locationToSearch, string fileName)
        {
            string result = string.Empty;
            string[] fileEntries = Directory.GetFiles(locationToSearch);
            foreach (string file in fileEntries)
            {
                if (file.Contains(fileName))
                {
                    result = file;
                    return result;
                }
            }
            string[] subdirectoryEntries = Directory.GetDirectories(locationToSearch);
                foreach (string subdirectory in subdirectoryEntries)
                {
                    string file = FindFile(subdirectory, fileName);
                    if (file.Contains(fileName))
                    {
                        result = file;
                        return result;
                    }
                }
            return result;
        }
    }
}