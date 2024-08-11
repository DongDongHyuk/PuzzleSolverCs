using System.Diagnostics;

namespace Third
{
    class Program
    {
        public static void Main()
        {
            var m1 = new int[,]
            { 
                {1, 2, 4}, 
                {3, 0, 5}, 
                {7, 6, 8}
            };

            var m2 = new int[,]
            { 
                {0, 1, 2}, 
                {3, 4, 5}, 
                {6, 7, 8}
            };

            var root = new State(m1);
            var leaf = new State(m2);

            Search sol = new Search();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            List<State> res = sol.BFS(root,leaf);

            sw.Stop();
            
            foreach (var i in res)
            {
                i.printMap();
            }
    
            Console.WriteLine("Searched Leaf !!!");
            Console.WriteLine("visited : " + sol.mkd.Count());
            Console.WriteLine("Runtime : " + (double)sw.ElapsedMilliseconds/1000 + "s");
            Console.ReadKey();
        }
    }
}