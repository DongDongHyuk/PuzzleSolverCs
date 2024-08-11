
namespace Third
{
    class Search
    {
        public HashSet<State> mkd = new HashSet<State>(){};

        public List<State> BFS(State root, State leaf)
        {
            var que = new Queue<State>(){};
            var path = new List<State>();

            mkd.Add(root);
            que.Enqueue(root);

            while (que.Count > 0)
            {
                var cur = que.Dequeue();
                if (cur.isEquals(leaf.Map))
                {
                    path = pathTracking(cur);
                    break;
                }

                cur.expand();
                foreach (var i in cur.childrun)
                {
                    if (!mkd.Contains(i))
                    {
                        mkd.Add(i);
                        que.Enqueue(i);
                    }
                }
            }

            return path;
        }

        List<State> pathTracking(State leaf)
        {
            var res = new List<State>(){leaf};
            var cur = leaf; 

            while (cur.Parent != null)
            {
                cur = cur.Parent;
                res.Add(cur);
            }
            res.Reverse();
            return res;
        }
    }
}