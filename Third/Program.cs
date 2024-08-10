namespace Third
{
    class Program
    {
        public static void Main()
        {
            var m = new int[,]
            { 
                {0, 1, 0}, 
                {0, 0, 0}, 
                {0, 0, 0}
            };

            var m1 = new int[,]
            { 
                {0, 1, 0}, 
                {0, 0, 0}, 
                {0, 0, 0}
            };

            

            var board = new Board(m);
            var boardOther = new Board(m1);
            
            var root = new State(board);
            root.expand();
            foreach (var i in root.childrun)
            {
                i.Curborad.printBoard();
            }

            // var mkd = new HashSet<Board>();
            // mkd.Add(board);
            // Console.WriteLine(mkd.Contains(boardOther));

            Console.ReadKey();
        }
    }
}