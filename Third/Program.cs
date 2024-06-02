namespace Third
{
    class Program
    {
        public static void Main()
        {
            var m = new int[,]
            { 
                {0, 0, 0}, 
                {0, 0, 0}, 
                {0, 0, 0}
            };

            var m1 = new int[,]
            { 
                {0, 0, 0}, 
                {0, 0, 0}, 
                {0, 0, 0}
            };

            var board = new Board(m);
            Console.WriteLine(board.isEquals(m1));

            Console.ReadKey();
        }
    }
}