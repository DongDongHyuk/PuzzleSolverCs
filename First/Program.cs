void printf(int[,] m)
{
    for (int y = 0; y < 3; y++)
    {
        for (int x = 0; x < 3; x++)
        {
            Console.Write(m[y,x] + " ");
        }
        Console.WriteLine("");
    } 
    Console.WriteLine("");
}

int sy = 3, sx = 3;
int size = sy * sx;

int[,] m1 = new int [3,3]
{
    {0, 0, 0},
    {0, 1, 0},
    {0, 0, 0}
};

int[,] m2 = new int [3,3]
{
    {0, 0, 0},
    {0, 1, 0},
    {0, 0, 0}
};

List<int[,]> exp(int[,] m){

    var res = new List<int[,]>();
    List<int> dy = new List<int>(){-1, 0, 1, 0}, dx = new List<int>(){0, -1, 0, 1};

    for (int y = 0; y < 3; y++)
    {
        for (int x = 0; x < 3; x++)
        {
            if (m[y,x] == 0)
            {
                for (int i = 0; i < 4; i ++)
                {
                    int ny = y + dy[i], nx = x + dx[i];
                    if (-1 < ny && ny < sy && -1 < nx && nx < sx && m[ny,nx] != 0)
                    {
                        int[,] mCopy = (int[,])m.Clone();       // 맵 복사 
                        (mCopy[y,x],mCopy[ny,nx]) = (mCopy[ny,nx],mCopy[y,x]);      // 값 자리 변경
                        res.Add(mCopy);
                    }
                }
            }
        }

    }
    return res;
}

// 2차원 배열 비교
bool isSame(int[,] a, int[,] b)
{
    for (int i = 0; i<3; i++)
        for (int j = 0; j<3; j++)
            if (a[i,j] != b[i,j])
                return false;
    return true;
}

Dictionary<int[,], int[,]> bfs(int[,] root, int[,] leaf)
{
    // queue 선언
    var que = new Queue<int[,]>();
    que.Enqueue(root);

    // mkd 선언
    var mkd = new Dictionary<int[,], int[,]>(); 
    mkd.Add(root, new int[3, 3]{{-1,-1,-1},{-1,-1,-1},{-1,-1,-1}});
    
    // cur 선언
    int[,] cur = (int[,])root.Clone();

    while (isSame(cur,leaf))
    {
        cur = que.Dequeue();

        foreach (int[,] i in exp(cur))
        {
            if (!mkd.ContainsKey(i))
            {
                mkd.Add(i,cur);
                que.Enqueue(i);
            }
        }
    }   
    return mkd; 
}



// wait before closing
Console.ReadKey();