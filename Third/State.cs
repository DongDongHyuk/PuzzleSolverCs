using System.Runtime.CompilerServices;

namespace Third
{
    class State
    {
        public Board Curborad;
        public State Parent;
        public int Depth;

        public State(Board curboard, State parent, int depth)
        {
            this.Curborad = curboard;
            this.Parent = parent;
            this.Depth = depth;
        }

        public List<State> expand(State state)
        {
            var res = new List<State>();

            for (int i = 0; i < 3; i ++)
            {
                for (int j = 0; j < 3; j ++)
                {
                    if (state.Curborad.Map[i,j] == 0)
                    {
                        
                    }
                }
            }

            return res;
        }

    }


}