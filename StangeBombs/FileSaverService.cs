using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ModuleTwo
{
    public interface IFileSaverService
    {
        bool SaveFile(string content, string location, string fileName);
    }    

    public class FileSaverService : IFileSaverService
    {
        public bool SaveFile(string content, string location, string fileName)
        {
            var result = false;             
            string fileName2 = fileName + "_reverse" + ".txt";
            string content_reverse = new string(content.ToCharArray().Reverse().ToArray());           
            if(!File.Exists(location + @"\" + fileName2))
            {
                StreamWriter textfileName2 = new StreamWriter(location + @"\" + fileName2);
                textfileName2.Write(content_reverse);
                textfileName2.Close();
                string [] s = File.ReadAllLines(location + @"\" + fileName2);
                string s1 = String.Concat<string>(s);
                if (File.Exists(location + @"\" + fileName2) && s1 == content_reverse)
                { result = true;
                    Console.WriteLine("Reverse file has been successfully saved");
                }
                else
                {
                    Console.WriteLine("Something is wrong.Please try again");
                    result = false;
                }                

            }
            else
            {
                Console.WriteLine("The file with such name already exist");
                Console.WriteLine("Do you really want to resave the file with the changes? Y/N");
                string save = Console.ReadLine();      
                             
                while (save !="Y" && save !="N")
                {
                    Console.WriteLine("Please choose Y(if yes)/N(if no)");
                    save = Console.ReadLine();
                }                
               
                switch (save)
                {
                    case "Y":
                        StreamWriter textfileName2 = new StreamWriter(location + @"\" + fileName2);
                        textfileName2.Write(content_reverse);
                        textfileName2.Close();
                        string[] s = File.ReadAllLines(location + @"\" + fileName2);
                        string s1 = String.Concat<string>(s);
                        if (File.Exists(location + @"\" + fileName2) && s1 == content_reverse)
                        {
                            result = true;
                            Console.WriteLine("Reverse file has been successfully saved");
                        }
                        else
                        {
                            Console.WriteLine("Something is wrong.Please try again");
                            result = false;
                        }
                        break;
                    case "N":
                        Console.WriteLine("Reverse file has not been saved");
                        result = false;
                        break;                    
                }
            }                                                            
           
            return result;
          

        }
    }

}