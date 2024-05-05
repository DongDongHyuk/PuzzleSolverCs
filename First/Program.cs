
using static System.Console;
using static Printer.Main;

void printf(int[] m)
{
    for (int y = 0; y < 3; y++)
    {
        for (int x = 0; x < 3; x++)
        {
            Console.Write(m[y * 3 + x] + " ");
        }
        Console.WriteLine("");
    } 
    Console.WriteLine("");
}

int sy = 3, sx = 3;
int size = sy * sx;

var Root = new int[]
{
    0,0,0,
    0,0,0,
    0,0,1
};

var Leaf = new int[]
{
    1,0,0,
    0,0,0,
    0,0,0
};

List<int> around(int pos)
{
    var res = new List<int>();
    int y = pos / sx, x = pos % sx;
    var dy = new List<int>(){-1, 0, 1, 0};
    var dx = new List<int>(){0, 1, 0, -1};
    for (int i=0; i < 4; i++)
    {
        int ny = y + dy[i], nx = x + dx[i];
        if (-1 < ny && ny < sy && -1 < nx && nx < sx)
        {
            res.Add(ny * 3 + nx);
        }
    }
    return res;
}

List<int[]> expand(int[] m)
{
    var res = new List<int[]>();
    for (int i = 0; i < size; i++)
    {
        if (m[i] == 0)
        {
            foreach (int j in around(i))
            {
                if (m[j] != 0)
                {
                    int[] mCopy = m.ToArray();
                    (mCopy[i],mCopy[j]) = (mCopy[j],mCopy[i]);
                    res.Add(mCopy);
                }
            }
        }
    }
    return res;
}

bool isInMkd(Dictionary<int[], int[]> dict, int[] m)
{
    return true;
}

void bfs(int[] root, int[] leaf)
{
    // Current
    var Current = root.ToArray();

    // Queue
    var que = new Queue<int[]>();
    que.Enqueue(Current);

    //mkd
    var mkd = new Dictionary<int[], int[]>();
    mkd.Add(Current, new int[]{-1,-1,-1,-1,-1,-1,-1,-1,-1});

    while (!Enumerable.SequenceEqual(Current, leaf))
    {
        Current = que.Dequeue();
        foreach (int[] i in expand(Current))
        {
            if (!mkd.ContainsKey(i))
            {
                mkd.Add(i, Current);
                que.Enqueue(i);
            }
        }
    }

    Console.WriteLine("Leaf Serached... visited : " + mkd.Count() + "\n");
    Console.WriteLine("Current");
    printf(Root);

    var path = new List<int[]>(){Leaf};
    while (true)
    {
        Current = mkd[Current];
        path.Add(Current);
        if (Enumerable.SequenceEqual(Current, root))
            break;
    }

    foreach (int[] i in Enumerable.Reverse(path))
        printf(i);
}

// bfs(Root, Leaf);

B O O O O O O M !

// wait before closing
Console.ReadKey();