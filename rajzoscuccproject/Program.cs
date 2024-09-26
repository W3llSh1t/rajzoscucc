using System.IO;

namespace rajzoscuccproject
{
    internal class Program
    {
        private static int winWidth = 0;
        private static int winHeight = 0;
        private static void Line()
        {
            winWidth = Console.WindowWidth;
            winHeight = Console.WindowHeight;
            for (int i = 0; i < winWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo input;
            int opt = 0;
            int back = 0;
            int proceed = 0;
            int first = 0;
            do
            {
                if (first == 0)
                {


                    do
                    {

                        Console.Clear();
                        Console.WriteLine("Press 1 to create a new file");
                        Console.WriteLine("Press 2 to open a file for editing");
                        Console.WriteLine("Press 3 to delete a file");
                        input = Console.ReadKey(true);
                        switch (input.Key)
                        {
                            case ConsoleKey.D1:
                                opt = 1;
                                break;
                            case ConsoleKey.D2:
                                opt = 2;
                                break;
                            case ConsoleKey.D3:
                                opt = 3;
                                break;
                        }
                    } while (input.Key != ConsoleKey.Escape && opt != 1 && opt != 2 && opt != 3);
                }
                if (back == 1)
                {
                    do
                    {

                        Console.Clear();
                        Console.WriteLine("Press 1 to create a new file");
                        Console.WriteLine("Press 2 to open a file for editing");
                        Console.WriteLine("Press 3 to delete a file");
                        input = Console.ReadKey(true);
                        switch (input.Key)
                        {
                            case ConsoleKey.D1:
                                opt = 1;
                                break;
                            case ConsoleKey.D2:
                                opt = 2;
                                break;
                            case ConsoleKey.D3:
                                opt = 3;
                                break;
                        }
                    } while (input.Key != ConsoleKey.Escape && opt != 1 && opt != 2 && opt != 3);
                }
                    Console.Clear();
                do
                {
                    switch (opt)
                    {
                        case 1:
                            Line();
                            Console.WriteLine("Create File");
                            Line();
                            Console.WriteLine();
                            string newFileName = Console.ReadLine();
                            Line();
                            Console.WriteLine($"Create File? {newFileName}");
                            Console.WriteLine("1-Yes");
                            Console.WriteLine("Esc-No");
                            Line();
                            input = Console.ReadKey(true);
                            if (input.Key == ConsoleKey.D1)
                            {
                                if (!File.Exists($"{newFileName}.txt"))
                                {
                                    File.Create($"{newFileName}.txt");
                                    Console.WriteLine("File created");
                                    Console.WriteLine("Opening File");
                                    System.Threading.Thread.Sleep(2000);
                                    proceed = 1;
                                }
                                else
                                {
                                    Console.WriteLine("File already exists");
                                    back = 1;
                                }
                            }
                            break;
                        case 2:
                            Line();
                            Console.WriteLine("Open File");
                            Line();
                            //list all existing files in the directory
                            Console.WriteLine("Existing Files:");
                            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
                            foreach (string file in files)
                            {
                                Console.WriteLine(file);
                            }
//innen kell folytatni
                            

                            break;
                        case 3:

                            break;
                    }
                    input = Console.ReadKey(true);
                } while (input.Key != ConsoleKey.Escape && back != 1 && proceed != 1);
            } while (input.Key != ConsoleKey.Escape && proceed != 1);
            do
                {
                    winWidth = Console.WindowWidth;
                    winHeight = Console.WindowHeight;
                    Console.Clear();
                    Line();
                    Console.WriteLine("Console Paint");
                    Line();
                    input = Console.ReadKey(true);
                    


                } while (input.Key != ConsoleKey.Escape);
            
        }
    }
}
