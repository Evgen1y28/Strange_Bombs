using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StangeBombs
{
    public class ModuleTwoInvoker : IModuleTwoInvoker
    {
        public ModuleTwoInvoker()
        {
            _finderService = new FinderService();
            _fileReaderService = new FileReaderService();
            _fileSaverService = new FileSaverService();
        }

        private FinderService _finderService { get; }
        private FileReaderService _fileReaderService { get; }
        private FileSaverService _fileSaverService { get; }



        public string FindFile(string locationToSearch, string fileName)
        {
            var result = string.Empty;
                try
                {
                    if (String.IsNullOrEmpty(locationToSearch))
                    {
                        Program.GetPath(out locationToSearch);
                    }
                    if (String.IsNullOrEmpty(fileName))
                    {
                        Program.GetName(out fileName);
                    }
                    result = _finderService.FindFile(locationToSearch, fileName);
                    if (String.IsNullOrEmpty(result))
                    {
                        Program.GetName(out fileName);
                        result = FindFile(locationToSearch, fileName);
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Please enter the real file, what you want to search");
                    Program.GetPath(out locationToSearch);
                    Program.GetName(out fileName);
                    FindFile(locationToSearch,fileName);
                }

                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("Please enter the real directory(path)");
                    Program.GetPath(out locationToSearch);
                    FindFile(locationToSearch, fileName);
                }
                catch (UnauthorizedAccessException)
                {
                    
                }
                catch (Exception)
                {
                    ;
                }


            return result;
        }

        public string GetFileContent(string location, string fileName)
        {
            var result = string.Empty;

            try
            {
                result = _fileReaderService.GetFileContent(location, fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }

        public bool SaveFile(string content, string location, string fileName)
        {
            var result = false;

            try
            {
                result = _fileSaverService.SaveFile(content, location, fileName);
            }
            catch (Exception e)
            {
                // your code here
            }

            return result;
        }
    }
}