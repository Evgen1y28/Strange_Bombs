using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace StangeBombs
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
            string content_reverse = new string(content.ToCharArray().Reverse().ToArray());           
            string location_reverse = new string(location.ToCharArray().Reverse().ToArray());
            string [] words=location_reverse.Split(new char[] {'\\'});
            string reverse_name = words[0];            
            string new_name2= new string(reverse_name.ToCharArray().Reverse().ToArray());
            string[]w = new_name2.Split(new char[] { '.'});
            string new_name= w[0];
            string new_path = location.Substring(0, location.Length - new_name2.Length);           
            string fileName2 = new_name + "_reverse" + ".txt";            
            if (!File.Exists(new_path + @"\" + fileName2))
            {
                StreamWriter textfileName2 = new StreamWriter(new_path + @"\" + fileName2);
                textfileName2.Write(content_reverse);
                textfileName2.Close();
                string [] s = File.ReadAllLines(new_path + @"\" + fileName2);
                string s1 = String.Concat<string>(s);
                if (File.Exists(new_path + @"\" + fileName2) && s1 == content_reverse)
                { result = true;
                    Console.WriteLine("Reverse file has been successfully saved to the " + new_path);
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
                        StreamWriter textfileName2 = new StreamWriter(new_path + @"\" + fileName2);
                        textfileName2.Write(content_reverse);
                        textfileName2.Close();
                        string[] s = File.ReadAllLines(new_path + @"\" + fileName2);
                        string s1 = String.Concat<string>(s);
                        if (File.Exists(new_path + @"\" + fileName2) && s1 == content_reverse)
                        {
                            result = true;
                            Console.WriteLine("Reverse file has been successfully saved to the "+new_path);
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