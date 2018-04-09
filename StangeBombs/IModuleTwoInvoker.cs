using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StangeBombs
{
    public interface IModuleTwoInvoker
    {
        string FindFile(string locationToSearch, string fileName);

        string GetFileContent(string location, string fileName);

        bool SaveFile(string content, string lcoation, string fileName);
    }
}