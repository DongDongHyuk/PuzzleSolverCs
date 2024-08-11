namespace Third
{
    class State
    {
        public int[,] Map { get; set; }
        public State Parent = null;
        public List<State> childrun = new List<State>();
        public int Depth = 0;

        public State(int[,] m)
        {
            this.Map = m;
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
            var other = (State)obj;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j ++)
                    if (this.Map[i,j] != other.Map[i,j])
                        return false;
            return true;
        }

        public List<State> expand()
        {
            var res = new List<State>();
            int[] dy = new int[] {-1, 0, 1, 0}, dx = new int[] {0, 1, 0, -1};

            for (int y = 0; y < 3; y ++)
                for (int x = 0; x < 3; x ++)
                    if (Map[y,x] == 0)
                        for (int i = 0; i < 4; i ++)
                        {
                            int ny = y + dy[i], nx = x + dx[i];
                            if (-1 < ny && ny < 3 && -1 < nx && nx < 3 && Map[ny,nx] != 0)
                            {
                                var mc = Map.Clone() as int[,];
                                (mc[y,x],mc[ny,nx]) = (mc[ny,nx],mc[y,x]);
                                var child = new State(mc);
                                child.Depth = this.Depth + 1;
                                child.Parent = this;
                                childrun.Add(child);
                                
                            }

                        }
            return res;
        }

        public bool isEquals(int[,] m)
        {
            for (int i = 0; i < 3; i ++)
                for (int j = 0; j < 3; j ++)
                    if (this.Map[i,j] != m[i,j])
                        return false;
            return true;
        }

        public void printMap()
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