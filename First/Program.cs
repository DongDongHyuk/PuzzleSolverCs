// 24.05.01

int sy = 3, sx = 3;
int size = sy * sx;

int[,] m = new int [3,3]{
    {0, 0, 0},
    {0, 1, 0},
    {0, 0, 0}};

List<int[,]> exp(int[,] m){
    List<int[,]> res = new List<int[,]>();
    List<int> dy = new List<int>(){-1, 0, 1, 0}, dx = new List<int>(){0, -1, 0, 1};
    for (int i = 0; i < 3; i++){
        for (int j = 0; j < 3; j++){
            if (m[i,j] == 0){
                for (int k = 0; k < 4; k ++){
                    int ny = i + dy[k], nx = j + dx[k];
                    if (-1 < ny && ny < sy && -1 < nx && nx < sx && m[ny,nx] != 0){
                        List<int[,]> new_m = ;
                        Console.WriteLine("y,x : {0},{1} -> ny,nx : {2},{3}",i,j,ny,nx);
                    }
                }
            }
        }
    }
    return res;
}

exp(m);