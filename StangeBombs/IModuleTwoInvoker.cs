using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTwo
{
    public interface IModuleTwoInvoker
    {
        bool SaveFile(string content,string location, string fileName);
    }
}