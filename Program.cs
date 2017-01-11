using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryScan
{
    class Program
    {
        


        static void Main(string[] args)
        {

            string[] wordlist;
            string url;
            string[] extensions;
            string wordlistPath = @"C:\Users\Dave\Documents\wordlists\small.txt";
            List<string> directorys = new List<string>();

            userInput ui = new userInput();
            ui.getDetails();
            wordlist = ui.wordlist;
            wordlistPath = ui.wordlistPath;
            url = ui.url;
            extensions = ui.extensions;

            scan s = new scan();
            s.scanURL(wordlist, wordlistPath, url, extensions);

            Console.ReadKey();


            


        }
    }
}
