using System.Threading.Tasks.Dataflow;
using Microsoft.VisualBasic;

namespace Third
{
    class State
    {
        public Board Curborad;
        public State Parent = null;
        public List<State> childrun = new List<State>();
        public int Depth = 0;

        public State(Board curboard)
        {
            this.Curborad = curboard;
        }

        public List<State> expand()
        {
            var res = new List<State>();
            int[] dy = new int[] {-1, 0, 1, 0}, dx = new int[] { 0, 1, 0, -1};

            for (int y = 0; y < 3; y ++)
                for (int x = 0; x < 3; x ++)
                    if (Curborad.Map[y,x] == 0)
                    {
                        for (int i = 0; i < 4; i ++)
                        {
                            int ny = y + dy[i], nx = x + dx[i];
                            if (-1 < ny && ny < 3 && -1 < nx && nx < 3 && Curborad.Map[ny,nx] != 0)
                            {
                                Console.WriteLine("{0} {1} {2} {3}",y,x,ny,nx);
                                var mc = (int[,])Curborad.Map;
                                (mc[y,x],mc[ny,nx]) = (mc[ny,nx],mc[y,x]);
                                var child = new State(new Board(mc));
                                child.Depth = this.Depth + 1;
                                child.Parent = this;
                                childrun.Add(child);
                            }

                        }

                    }

            return res;
        }

    }


}
