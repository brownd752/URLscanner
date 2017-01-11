using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryScan
{
    class userInput
    {
        public string[] wordlist;
        public string url;
        public string[] extensions = new string[] { "", ".php", ".aspx", ".html" };
        public string wordlistPath;
        private string answer;
        private Boolean test;

        public void getDetails()
        {
            getURL();
            getWordlist();
            getExtensions();

        }

        private void getURL()
        {
            Boolean test;
            // Asks the user for the URL
            input:
            Console.WriteLine(" Please Enter the URL");
            answer = Console.ReadLine();
            answer.ToLower();

            //Check input
            test = checkAnswer(answer);
            if (test == true)
            {
                goto input;
            }

            if(!answer.Contains("http://"))
            {
                answer = "http://" + answer;
            }

            // Check that the URL is active
            httpRequests p = new httpRequests();
            test = p.pingURL(answer);
            if (test == false)
            {
                goto input;
            }
            url = answer;
        }

        private void getWordlist()
        {
            
        input:
            Console.WriteLine(" Please Enter the wordlist path");
            answer = Console.ReadLine();

            // check if answer is null
            test = checkAnswer(answer);
            if (test == true)
            {
                goto input;
            }

            // Attempt to read list from file
           test = readWordList(answer);
            if (test == false)
            {
                goto input;
            }
            wordlistPath = answer;
        }

        private void getExtensions()
        {
                Console.WriteLine(" Please enter file extensions you may be looking for");
                var output = "";
                foreach (string ext in extensions)
                {
                    output = output + ext + " ";
                }

                //console asks user if they would like to change the default.
                Console.WriteLine(" default: " + output);
                Console.WriteLine(" Would you like to change extensions");
                Console.WriteLine(" Y or N");
                answer = Console.ReadLine();

                if (answer.Contains("Y"))
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(" Please enter the extensions you would like to use");
                    Console.WriteLine(" For Example: .php,.aspx");
                    Console.WriteLine(" Note the comma between the extensions");
                    answer = Console.ReadLine();
                    //seperates the values to put into the extensions array.
                    string[] exts = answer.Split(',');

                    //clear current extensions
                    Array.Clear(extensions, 0, extensions.Length);

                    // push the user inputed extensions to array
                    var i = 0;
                    foreach (string s in exts)
                    {
                        extensions[i] = s;
                        i = i + 1;
                    }

                }

            }

        private Boolean checkAnswer(string url)
        {
            if (String.IsNullOrEmpty(answer))
            {
                return true;
            } else
            {
                return false;
            }
        }

        private Boolean readWordList(string wordlistPath)
        {
            wordlistPath = @"C:\Users\Dave\Documents\wordlists\small.txt";
            try
            {
                wordlist = System.IO.File.ReadAllLines(wordlistPath);
                return true;
            }
            catch
            {
                Console.WriteLine(" Unable to find the file, please try again");
                return false;
            }
        }
    }
}
