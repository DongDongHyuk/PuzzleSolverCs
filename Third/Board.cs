namespace Third
{
    class Board
    {
        public int[,] Map { get; set; }

        public Board(int[,] m)
        {
            this.Map = m;
        }

        public bool isEquals(int[,] m)
        {
            for (int i = 0; i < 3; i ++)
                for (int j = 0; j < 3; j ++)
                    if (this.Map[i,j] != m[i,j])
                        return false;
            return true;
        }

        public override int GetHashCode()
        {
            int res = 0;
            int shift = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j ++)
                {
                    shift = (shift + 11) % 21;
                    res = (this.Map[i,j] + 1024) << shift;
                }
            return res;
        }

        public override bool Equals(object obj)
        {
            var other = (Board)obj;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j ++)
                    if (this.Map[i,j] != other.Map[i,j])
                        return false;
            return true;
        }

        public void printBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j ++)
                    Console.Write(Map[i,j] + " ");
                Console.WriteLine("");
            }
            Console.WriteLine("");

        }
    }
}