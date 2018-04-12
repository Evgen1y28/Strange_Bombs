using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace StangeBombs
{

    class Program
    {

        public static void Main(string[] args)
        {
            GetPath(out string path);
            GetName(out string name);
            ModuleTwoInvoker prog = new ModuleTwoInvoker();
            string findFile = prog.FindFile(path, name);
            string getFile = prog.GetFileContent(findFile, name);
            bool saveFile = prog.SaveFile(getFile, findFile, name);

            Console.ReadLine();
        }
        public static void GetPath(out string path)
        {
            Console.Write("Please enter the directory where is the file (like D:\\ ):");
            path = Console.ReadLine();
        }
        public static void GetName(out string name)
        {
            Console.Write("Please enter the file name (like vunshpunsh.txt):");
            name = Console.ReadLine();
        }
    }

}
