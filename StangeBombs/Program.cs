using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ModuleTwo
{
    public class ModuleTwoInvoker:IModuleTwoInvoker

    {
        public ModuleTwoInvoker()
        {
            _fileSaverService = new FileSaverService( );
        }

        private IFileSaverService _fileSaverService { get; }
        public bool SaveFile(string content, string location, string fileName )
        {
            var result = false;
            result = _fileSaverService.SaveFile(content, location, fileName);
            return result; 
        }

        internal class Program
        {

            private static void Main(string[] args)
            {
                IModuleTwoInvoker invoker = new ModuleTwoInvoker();
                invoker.SaveFile();               
                Console.ReadLine();

            }
        }
    }
}
