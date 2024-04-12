using System.Collections;

void printm(int[,] m, int x, int y)
{
    for (int i = 0; i < y; i ++)
    {
        for (int j = 0; j < x; j ++)
        {
            Console.Write(m[i , j] + " ");
        }
        Console.WriteLine(' ');
    }
    Console.WriteLine(' ');
}

int sy = 3, sx = 3, size = sy * sx;

int[,] exc(int[,] m, int y1, int x1, int y2, int x2)
{   
    int[,]mCopy = m.Clone() as int[,];
    (mCopy[y1 , x1], mCopy[y2 , x2]) = (mCopy[y2 , x2],mCopy[y1 , x1]);
    return mCopy;
}

List<int[,]> expand(int[,] m)
{   
    List<int[,]> res = new List<int[,]>();      // res
    List<int> dy = new List<int>() {-1, 0 , 1, 0}, dx = new List<int>() {0, 1, 0, -1};

    for(int y = 0; y < sy; y ++)
    {
        for(int x = 0; x < sx; x ++)
        {
            if(m[y, x] == 0)
            {   
                for(int i = 0; i < 4; i ++)
                {
                    int ny = y + dy[i], nx = x + dx[i];
                    if(-1 < ny  && ny < sy && -1 < nx  && nx < sx && m[ny , nx] != 0){
                        res.Add(exc(m, y, x, ny, nx));
                        Console.WriteLine("Swap to (y,x) -> {0},{1} | (ny,nx) -> {2},{3}",y,x,ny,nx);
                    } 
                }
            }
        }
    }
    return res;
}

int[,] m = {{0, 0, 0}, 
            {3, 0, 1}, 
            {0, 2, 0}};
Console.WriteLine("\nNowMapState");
printm(m, sx, sx);


List<int[,]>res = expand(m);
Console.WriteLine("");

foreach(int[,] i in res){
    printm(i, 3, 3);
}

