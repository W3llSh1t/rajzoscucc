using System.IO;

namespace rajzoscuccproject
{
    internal class Program
    {
        private static int winWidth = 0;
        private static int winHeight = 0;
        private static string saturation = "█";
        private static int currentRow = 13;
        private static int currentCol = 1;
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
        private static void writeColor()
        {
            Console.SetCursorPosition(0, 11);
            Console.WriteLine($"Current Color and Saturation: {saturation}");
            Console.SetCursorPosition(currentCol, currentRow);
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo input;
            int opt = 0;
            int back = 0;
            int proceed1 = 0;
            int proceed = 0;
            int first = 0;
            /*
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
                                if (!File.Exists($"{newFileName}.ldzs"))
                                {
                                    File.Create($"{newFileName}.ldzs");
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
                            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.ldzs");
                            int fileNum = 0;
                            foreach (string file in files)
                            {
                                
                                Console.WriteLine($"{fileNum + 1}:  {file}");
                                fileNum++;
                            }
                            Console.WriteLine("Choose a File:");
                            int fileChoice = int.Parse(Console.ReadLine());
                            if (fileChoice > fileNum)
                            {
                                Console.WriteLine("Invalid Choice");
                                System.Threading.Thread.Sleep(2000);
                                back = 1;
                                break;
                            }
                            else
                            {
                                string fileToOpen = files[fileChoice - 1];
                                Console.WriteLine($"Opening {fileToOpen}");
                                System.Threading.Thread.Sleep(2000);
                                proceed = 1;
                            }


                            break;
                        case 3:
                            //delete file
                            Line();
                            Console.WriteLine("Delete File");
                            Line();
                            Console.WriteLine("Existing Files:");
                            string[] files2 = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.ldzs");
                            int fileNum2 = 1;
                            foreach (string file in files2)
                            {

                                Console.WriteLine($"{fileNum2}:  {file}");
                                fileNum2++;
                            }
                            Console.WriteLine("Choose a File:");
                            int fileChoice2 = int.Parse(Console.ReadLine());
                            string fileToDelete = files2[fileChoice2 - 1];
                            Console.WriteLine($"Delete {fileToDelete}");
                            Console.WriteLine("1-Yes");
                            Console.WriteLine("Esc-No");
                            Line();
                            input = Console.ReadKey(true);
                            if (input.Key == ConsoleKey.D1)
                            {
                                File.Delete(fileToDelete);
                                Console.WriteLine("File Deleted");
                                System.Threading.Thread.Sleep(2000);
                                back = 1;
                            }

                            break;
                    }
                    input = Console.ReadKey(true);                
                } while (input.Key != ConsoleKey.Escape && back != 1 && proceed != 1);
                if(proceed == 1)
                {
                    proceed1 = 1;
                }
            } while (input.Key != ConsoleKey.Escape && proceed != 1);
            //█▓▒░*/
            do
            {
                Console.SetWindowSize(150, 50);
                winWidth = Console.WindowWidth;
                winHeight = Console.WindowHeight;
                Console.Clear();
                Line();
                Console.WriteLine("Console Paint");
                Line();
                Console.WriteLine("Options: Draw: Space");
                Console.WriteLine("Set Color: 1, 2, 3, 4 ...");
                Console.WriteLine("Set Saturation: F1, F2, F3, F4");
                Console.WriteLine("Continous Drawing: CS");
                Console.WriteLine("Clear Screen: Backspace");
                Console.WriteLine("Save File: F5");
                Console.WriteLine("Exit: Escape");
                Line();
                Console.WriteLine("Current Color and Saturation: █");
                Console.SetCursorPosition(0, 12);
                Console.Write("+");
                for (int i = 0; i < winWidth - 2; i++)
                {
                    Console.Write("-");
                }
                Console.Write("+");
                for (int i = 0; i < winHeight - 15; i++)
                {
                    Console.Write("|");
                    for (int j = 0; j < winWidth - 2; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write("|");
                }
                Console.Write("+");
                for (int i = 0; i < winWidth - 2; i++)
                {
                    Console.Write("-");
                }
                Console.Write("+");

                Console.SetCursorPosition(1, 13);

                

                string saturation = "█";

                do
                {
                    input = Console.ReadKey(true);
                    switch (input.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if(currentCol != 1)
                            {
                                Console.SetCursorPosition(currentCol - 1, currentRow);
                                currentCol--;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (currentCol != winWidth - 2)
                            {
                                Console.SetCursorPosition(currentCol + 1, currentRow);
                                currentCol++;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (currentRow != 13)
                            {
                                Console.SetCursorPosition(currentCol, currentRow - 1);
                                currentRow--;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (currentRow != winHeight - 3)
                            {
                                Console.SetCursorPosition(currentCol, currentRow + 1);
                                currentRow++;
                            }
                            break;
                        case ConsoleKey.D1:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            writeColor();
                            break;
                        case ConsoleKey.D2:
                            Console.ForegroundColor = ConsoleColor.Red;
                            writeColor();
                            break;
                        case ConsoleKey.D3:
                            Console.ForegroundColor = ConsoleColor.Green;
                            writeColor();
                            break;
                        case ConsoleKey.D4:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            writeColor();
                            break;
                        case ConsoleKey.D5:
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            writeColor();
                            break;
                        case ConsoleKey.D6:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            writeColor();
                            break;
                        case ConsoleKey.D7:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            writeColor();
                            break;
                        case ConsoleKey.D8:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            writeColor();
                            break;
                        case ConsoleKey.D9:
                            Console.ForegroundColor = ConsoleColor.White;
                            writeColor();
                            break;
                        case ConsoleKey.F1:
                            saturation = "█";
                            writeColor();
                            break;
                        case ConsoleKey.F2:
                            saturation = "▓";
                            writeColor();
                            break;
                        case ConsoleKey.F3:
                            saturation = "▒";
                            writeColor();
                            break;
                        case ConsoleKey.F4:
                            saturation = "░";
                            writeColor();
                            break;
                        case ConsoleKey.Spacebar:
                            Console.Write(saturation);
                            Console.SetCursorPosition(currentCol, currentRow);
                            break;
                        case ConsoleKey.Backspace:
                            Console.SetCursorPosition(1, 13);
                            Console.ResetColor();
                            for (int i = 0; i < winHeight; i++)
                            {
                                Console.Write("|");
                                for (int j = 0; j < winWidth - 2; j++)
                                {
                                    Console.Write(" ");
                                }
                                Console.Write("|");
                            }
                            Console.SetCursorPosition(1, 13);
                            currentCol = 1;
                            currentRow = 13;
                            writeColor();
                            break;
                    }

                } while (input.Key != ConsoleKey.Escape);
            } while (input.Key != ConsoleKey.Escape);
            
        }
    }
}
