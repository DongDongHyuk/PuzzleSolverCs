using static System.Console;

namespace Second
{
    class Node
    {
        public List<Node> childrun = new List<Node>();      // 자식 노드
        public Node parent = null;                          // 부모 노드
        public int[] map = new int[9];                      // 맵
        public int sy = 3, sx = 3;                          // 맵 크기

        public Node(int[] m)
        {
            setMap(m);
        }

        // 맵 초기화
        void setMap(int[] m)
        {
            for (int i = 0; i < m.Length; i ++)
            {
                this.map[i] = m[i];
            }
        }
        
        // 자식노드 확장
        public void expandMap()
        {
            int[] dy = new int[]{-1, 0, 1, 0}, dx = new int[]{0, 1, 0, -1};
            for (int pos = 0; pos < 9; pos ++)
            {
                if (map[pos] == 0)
                {
                    int y = pos / 3, x = pos % 3;
                    for (int i = 0; i < 4; i ++)
                    {
                        int ny = y + dy[i], nx = x + dx[i];
                        int posOther = ny * sx + nx;
                        if (-1 < ny && ny < sy && -1 < nx && nx < sx && map[posOther] != 0)
                        {
                            var mc = new int[9];
                            copyMap(mc, map);
                            (mc[pos],mc[posOther]) = (mc[posOther],mc[pos]);

                            Node child = new Node(mc);      // 자식 노드
                            childrun.Add(child);            // 자식 노드 리스트에 추가
                            child.parent = this;            // 자식 노드의 부모를 현재 노드로 설정
                        }
                    }
                }
            }

        }

        // 맵 출력
        public void printMap()
        {
            for (int y = 0; y < sy; y ++)
            {
                for (int x = 0; x < sx; x ++)
                {
                    Write(map[y * sx + x] + " ");
                }
                WriteLine();
            }
            WriteLine();
        }

        // 맵 비교
        public bool isSame(int[] m)
        {
            bool b = true;

            for (int i = 0; i < m.Length; i ++)
            {
                if (map[i] != m[i])
                    b = false;
            }
            return b;
        }
        
        // 맵 복사
        public void copyMap(int[] a, int[] b)
        {
            for (int i = 0; i < a.Length; i ++)
            {
                a[i] = b[i];
            }
        }

        // 현재 맵과 목표 맵 비교
        public bool isGoal()
        {
            var b = true;
            var GoalMap = new int[]
            {
                1, 2, 3,
                4, 0, 0,
                0, 0, 0
            };

            for (int i = 0; i < map.Length; i ++)
            {
                if (map[i] != GoalMap[i])
                    b = false;
            }
            return b;
        }

    }
}