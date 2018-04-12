using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.AccessControl;

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
            if (!locationToSearch.EndsWith("\\"))
            {
                locationToSearch += '\\';
            }

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
                var subDirs = Directory.GetAccessControl(subdirectory);
                if (!subDirs.AreAccessRulesProtected)
                {
                    string file = FindFile(subdirectory, fileName);
                    if (file.Contains(fileName))
                    {
                        result = file;
                        return result;
                    }
                }
            }
            return result;
        }
       

    }
}