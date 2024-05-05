namespace Printer
{
    public class Main{
        public void printf(int[] m)
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
    }
}