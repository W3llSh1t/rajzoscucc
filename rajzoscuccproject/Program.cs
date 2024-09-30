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
        private static int menuOpt = 0;
        private static string arrow = "-->";
        private static void deleteArrow(int start, int end, int commPos)
        {
            string empty = "   ";
            int length = (end - start);
            for (int i = 0; i < length; i++)
            {
                Console.SetCursorPosition(0, start + i);
                Console.Write(empty);
                Console.SetCursorPosition(0, commPos);
            }
        }
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
        private static void paintInterface()
        {
            Console.Clear();
            Line();
            Console.WriteLine("Console Paint");
            Line();
            Console.WriteLine("Options: Draw: Space");
            Console.WriteLine("Set Color: 1, 2, 3, 4 ...");
            Console.WriteLine("Set Saturation: F1, F2, F3, F4");
            Console.WriteLine("Continous Drawing: C");
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
        }
        private static void menu(int start, int length, int commPos)
        {
            menuOpt = 0;
            ConsoleKeyInfo input;
            int proceed = 0;
            
            do
            {
                input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (menuOpt < length)
                        {
                            menuOpt++;
                            deleteArrow(start, start + length, commPos);
                            Console.SetCursorPosition(0, (start + menuOpt) - 1);
                            Console.Write(arrow);
                            Console.SetCursorPosition(0, commPos);
                            

                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (menuOpt != 0)
                        {
                            menuOpt--;
                            deleteArrow(start, start + length, commPos);
                            Console.SetCursorPosition(0, (start + menuOpt) - 1);
                            Console.Write(arrow);
                            Console.SetCursorPosition(0, commPos);
                            

                        }
                        break;
                    case ConsoleKey.Enter:
                        if (menuOpt == 0)
                        {
                            Console.WriteLine("Choose an option!");
                        }
                        else
                        {
                            proceed = 1;
                            return;
                        }
                        break;
                }
            } while (input.Key != ConsoleKey.Escape && proceed == 0);

        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo input;
            int opt = 0;
            int back = 0;
            int proceed = 0;
            int proceed1= 0;
            int proceed2 = 0;
            int first = 0;
            int toggleDraw = 0;
            

            Console.Clear();
            Line();
            Console.WriteLine("Console Paint");
            Line();
            Console.WriteLine("    Create File");
            Console.WriteLine("    Open File");
            Console.WriteLine("    Delete File");
            Console.WriteLine("    Exit");
            Line();
            menu(3, 4, 8);
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.ldzs");
            do
            {
                switch (proceed)
                {
                    case 1:
                        Console.Clear();
                        Line();
                        Console.WriteLine("Create File");
                        Line();
                        Console.WriteLine("File name:");
                        string createFileName = Console.ReadLine();
                        string createFile = createFileName + ".ldzs";
                        if (File.Exists(createFile))
                        {
                            Console.WriteLine("File already exists!");
                            Thread.Sleep(2500);
                        }
                        else
                        {
                            File.Create(createFile).Close();
                            Console.WriteLine("File created!");
                            Line();
                            Console.WriteLine("Open File?");
                            Console.WriteLine("    Yes");
                            Console.WriteLine("    No");
                            Line();
                            menu(8, 2, 11);
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Line();
                        Console.WriteLine("Open File");
                        Line();
                        if (files.Length == 0)
                        {
                            Console.WriteLine("No files found!");
                            Thread.Sleep(2500);
                        }
                        else
                        {
                            Console.WriteLine("Choose a file:");
                            for (int i = 0; i < files.Length; i++)
                            {
                                Console.WriteLine($"    {files[i].Substring(Directory.GetCurrentDirectory().Length + 1)}");
                            }
                            Console.WriteLine("    Back");
                            Line();
                            menu(4, files.Length, files.Length + 2);
                        }
                        break;
                    case 3:
                        break;
                }
            } while (proceed1 == 0);

            /*do
            {
                Console.SetWindowSize(150, 50);
                winWidth = Console.WindowWidth;
                winHeight = Console.WindowHeight;
                paintInterface();
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
                                if (toggleDraw == 1)
                                {
                                    Console.Write(saturation);
                                }
                                currentCol--;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (currentCol != winWidth - 2)
                            {
                                Console.SetCursorPosition(currentCol + 1, currentRow);
                                if (toggleDraw == 1)
                                {
                                    Console.Write(saturation);
                                }
                                currentCol++;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (currentRow != 13)
                            {
                                Console.SetCursorPosition(currentCol, currentRow - 1);
                                if (toggleDraw == 1)
                                {
                                    Console.Write(saturation);
                                }
                                currentRow--;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (currentRow != winHeight - 3)
                            {
                                Console.SetCursorPosition(currentCol, currentRow + 1);
                                if (toggleDraw == 1)
                                {
                                    Console.Write(saturation);
                                }
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
                            paintInterface();
                            Console.SetCursorPosition(1, 13);
                            currentCol = 1;
                            currentRow = 13;
                            writeColor();
                            break;
                        case ConsoleKey.C:
                            if (toggleDraw == 0)
                            {
                                toggleDraw = 1;
                            }
                            else
                            {
                                toggleDraw = 0;
                            }
                            break;
                        case ConsoleKey.F5:
                            saveFile();
                            break;
                    }

                } while (input.Key != ConsoleKey.Escape);
            } while (input.Key != ConsoleKey.Escape);
            */
        }
    }
}
