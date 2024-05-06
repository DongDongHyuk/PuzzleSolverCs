using static System.Console;

namespace Second
{
    class Program
    {
        static void Main(string[] args)
        {
            // Root Map
            int[] map = 
            {
                3, 2, 1,
                4, 0, 0,
                0, 0, 0
            };

            var init = new Node(map);
            Search ui = new Search();
            List<Node> res = ui.BreadthFirstSearch(init);
            
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
