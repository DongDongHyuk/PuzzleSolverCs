using static System.Console;
using System.Diagnostics;
using System.Net.NetworkInformation;


namespace Second
{
    class Program
    {
        static void Main(string[] args)
        {
            // Root Map
            int[] map = 
            {
                1, 2, 4,
                3, 0, 5,
                7, 6, 8
            };

            Stopwatch sw = new Stopwatch();

            var init = new Node(map);
            Search ui = new Search();

            sw.Start();

            List<Node> res = ui.BreadthFirstSearch(init);

            sw.Stop();
            
            WriteLine("Runtime : " + sw.ElapsedMilliseconds + "ms");
            Write("Printing Path. yes or no : ");
            string enter = ReadLine();
            if (enter == "yes")
            {   
                WriteLine();
                foreach (Node m in res)
                {
                    m.printMap();
                }
                ReadKey();
            }
        }
    }
}
