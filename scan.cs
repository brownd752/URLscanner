using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryScan
{
    class scan

    {
        public List<string> directorys = new List<string>();
       
        private Boolean test;

        // Main method used to loop through the wordlist. If a large wordlist is used it may be more efficient to read from the file as it is used.
        public void scanURL(string[] wordlist, string wordlistPath, string url, string[] extensions)
        {
            //Confirms users inputs
            displayDetails(url, wordlistPath);

            // Loops through the wordlist string array.
            foreach (string word in wordlist)
            {
                var temp = url + "/" + word;
                Console.WriteLine(temp);

                //uses the connection method to check the status code of the page.
                httpRequests c = new httpRequests();
                c.connection(temp);
                test = c.statusOK();

                // If status.OK then adds the url to the directorys list.
                if (test == true)
                {
                    directorys.Add(temp);
                }

            }
            // Displays the results of the scan.
            displayResults();

        }

        // Confirms the inputs to the user.
        private void displayDetails(string url, string wordlistPath)
        {
            var timeStarted = DateTime.Now;

            Console.WriteLine("Time Started - {0}", timeStarted.ToString(), "scanning ", url);
            Console.WriteLine(" Using wordlist {0}", wordlistPath);
        }

        // Displays the results of the scan
        private void displayResults()
        {
            var timeFinshed = DateTime.Now;
            Console.WriteLine("Time Finshed - {0}", timeFinshed);
            Console.WriteLine("We had", directorys.Count, "hits.");
            Console.WriteLine(" URL contained the folllowing");

            if (directorys.Count > 0)
            {
                foreach (string hit in directorys)
                {
                    Console.WriteLine(hit);
                }
            } else
            {
                Console.WriteLine("No Results found");
            }
            
        }
    }
}
