using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StangeBombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the directory where is the file (like D:'\' ):");
            string path = Console.ReadLine();
            Console.Write("Please enter the file name (like vunshpunsh.txt):");
            string name = Console.ReadLine();

            ModuleTwoInvoker prog = new ModuleTwoInvoker();
            string findFile = prog.FindFile(path, name);
            string getFile = prog.GetFileContent(findFile, name);
            bool saveFile = prog.SaveFile(getFile, path, name);
        }
    }
}
