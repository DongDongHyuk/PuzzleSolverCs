using static System.Console;

namespace Second
{
    class Search
    {
        // BFS
        public List<Node> BreadthFirstSearch(Node Root)
        {
            List<Node> path = new List<Node>();
            List<Node> que = new List<Node>();      // Queue
            List<Node> mkd = new List<Node>();      // Visited(Marked)

            que.Add(Root);
            bool isGoal = false;

            while (que.Count > 0 && !isGoal)
            {

                // Queue pop 
                Node current = que[0];      
                que.RemoveAt(0);

                if (current.isGoal())       // 현재노드 == 목표노드
                {
                    WriteLine("Goal Find.");
                    WriteLine("visited : " + mkd.Count);

                    isGoal = true;
                    path = pathTrace(current);
                }

                current.expandMap();        // 현재노드 확장
                foreach (Node child in current.childrun)
                {
                    if (!Constains(mkd, child))
                    {
                        mkd.Add(child);
                        que.Add(child);
                    }
                }
            }

            return path;
        }

        // Tracing
        public List<Node> pathTrace(Node n)
        {
            WriteLine("Tracing Path...");
            List<Node> li = new List<Node>();
            Node current = n;
            li.Add(current);

            while (current.parent != null)
            {
                current = current.parent;
                li.Add(current);
            }

            li.Reverse();
            return li;
        }

        // List<Node> li가 Node n를 포함하는가
        public bool Constains(List<Node> li, Node n)
        {   
            bool isConstain = false;
            for (int i = 0; i < li.Count; i++)
            {
                if (li[i].isSame(n.map))
                    isConstain = true;
            }
            return isConstain;
        }
    }
}