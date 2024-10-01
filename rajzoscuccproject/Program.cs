using System.IO;

namespace rajzoscuccproject
{
    internal class Program
    {
        private static int winWidth = 150;
        private static int winHeight = 50;
        private static string saturation = "█";
        private static int currentRow = 13;
        private static int currentCol = 1;
        private static int menuOpt = 0;
        private static string arrow = "-->";
        private static int writeRow = 0;
        private static int writeCol = 0;
        private static int color = 0;
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
                        if (menuOpt != 1)
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
            int proceed = 0;
            int proceed1= 0;
            int toggleDraw = 0;
            int l = 0;
            int openedSaturation = 0;
            int openedColor = 0;
            string openedFile = "";
            string[,] currentFile = new string[winHeight - 15, winWidth - 2];
            Console.ResetColor();

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
            if (menuOpt == 1)
            {
                proceed = 1;
            }
            else if (menuOpt == 2)
            {
                proceed = 2;
            }
            else if (menuOpt == 3)
            {
                proceed = 3;
            }
            else if (menuOpt == 4)
            {
                proceed = 4;
            }
            
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
                            string newFileString = "";
                            for (int i = 0; i < 35; i++)
                            {
                                for (int j = 0; j < 147; j++)
                                {
                                    newFileString += "0,0;";
                                }
                                newFileString += "0,0";
                                if (i != 34)
                                {
                                    newFileString += "\n";
                                }
                            }
                            File.WriteAllText(createFile, newFileString);
                            Console.WriteLine("Open File?");
                            Console.WriteLine("    Yes");
                            Console.WriteLine("    No");
                            Line();
                            menu(8, 2, 11);

                            if (menuOpt == 1)
                            {
                                proceed = 2;
                            }
                            else if (menuOpt == 2)
                            {
                                Environment.Exit(0);
                            }
                        }
                        break;
                    case 2:
                        string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.ldzs");
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
                            Console.WriteLine("    Exit");
                            Line();
                            menu(4, files.Length + 1, files.Length + 6);
                            if (menuOpt == files.Length + 1)
                            {
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.SetCursorPosition(0, 13);
                                openedFile = files[menuOpt - 1];
                                string[] fileContent = File.ReadAllLines(openedFile);
                                for (int i = 0; i < fileContent.Length; i++)
                                {
                                    string[] line = fileContent[i].Split("\n");
                                    for (int j = 0; j < line.Length; j++)
                                    {
                                        string[] cell = line[j].Split(";");
                                        for (int k = 0; k < cell.Length; k++)
                                        {
                                            string[] data = cell[k].Split(",");
                                            currentFile[i, k] = $"{data[0]},{data[1]};";
                                        }
                                    }                                 
                                }
                                proceed1 = 1;
                            }
                        }
                        break;
                    case 3:
                        string[] files1 = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.ldzs");
                        Console.Clear();
                        Line();
                        Console.WriteLine("Delete File");
                        Line();
                        if (files1.Length == 0)
                        {
                            Console.WriteLine("No files found!");
                            Thread.Sleep(2500);
                        }
                        else
                        {
                            Console.WriteLine("Choose a file:");
                            for (int i = 0; i < files1.Length; i++)
                            {
                                Console.WriteLine($"    {files1[i].Substring(Directory.GetCurrentDirectory().Length + 1)}");
                            }
                            Console.WriteLine("    Exit");
                            Line();
                            menu(4, files1.Length + 1, files1.Length + 6);
                            if (menuOpt == files1.Length + 1)
                            {
                                Environment.Exit(0);
                            }
                            else
                            {
                                File.Delete(files1[menuOpt - 1]);
                                Console.WriteLine("File deleted!");
                                Thread.Sleep(2500);
                            }
                        }
                        break;
                }
            } while (proceed1 == 0);
            

            Console.SetWindowSize(150, 50);
            winWidth = Console.WindowWidth;
            winHeight = Console.WindowHeight;
            
            do
            {

                winWidth = Console.WindowWidth;
                winHeight = Console.WindowHeight;
                paintInterface();
                
                do
                {
                    for (int i = 0; i < winHeight - 15; i++)
                    {
                        for (int j = 0; j < winWidth - 2; j++)
                        {
                            string[] data = currentFile[i, j].Split(",");
                            int ok = 0;
                            string saturation1 = "";
                            int color = 0;
                            if (data[0] != "0")
                            {
                                ok = 1;
                                saturation1 = data[0];
                                data[1] = data[1].Substring(0, data[1].Length - 1);
                                color = int.Parse(data[1]);
                            }
                            switch (color)
                            {
                                case 0:
                                    Console.ResetColor();
                                    break;
                                case 1:
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                                case 2:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;
                                case 3:
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    break;
                                case 4:
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    break;
                                case 5:
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    break;
                                case 6:
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    break;
                                case 7:
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    break;
                                case 8:
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    break;
                                case 9:
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                            }
                            Console.SetCursorPosition(j + 1, i + 13);
                            if (ok == 1)
                            {
                                Console.Write(saturation1);
                            }
                            l++;
                        }
                    }

                } while (l < currentFile.Length);
                string saturation = "█";
                Console.SetCursorPosition(1, 13);
                do
                {
                    Console.SetWindowSize(150, 50);
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
                                    currentFile[writeRow, writeCol] = $"{saturation},{color};";
                                }
                                currentCol--;
                                writeCol--;
                                
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (currentCol != winWidth - 2)
                            {
                                Console.SetCursorPosition(currentCol + 1, currentRow);
                                if (toggleDraw == 1)
                                {
                                    Console.Write(saturation);
                                    currentFile[writeRow, writeCol] = $"{saturation},{color};";
                                }
                                currentCol++;
                                writeCol++;
                                
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (currentRow != 13)
                            {
                                Console.SetCursorPosition(currentCol, currentRow - 1);
                                if (toggleDraw == 1)
                                {
                                    Console.Write(saturation);
                                    currentFile[writeRow, writeCol] = $"{saturation},{color};";
                                }
                                currentRow--;
                                writeRow--;
                                
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (currentRow != winHeight - 3)
                            {
                                Console.SetCursorPosition(currentCol, currentRow + 1);
                                if (toggleDraw == 1)
                                {
                                    Console.Write(saturation);
                                    currentFile[writeRow, writeCol] = $"{saturation},{color};";
                                }
                                currentRow++;
                                writeRow++;
                                
                            }
                            break;
                        case ConsoleKey.D1:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            writeColor();
                            color = 1;
                            break;
                        case ConsoleKey.D2:
                            Console.ForegroundColor = ConsoleColor.Red;
                            writeColor();
                            color = 2;
                            break;
                        case ConsoleKey.D3:
                            Console.ForegroundColor = ConsoleColor.Green;
                            writeColor();
                            color = 3;
                            break;
                        case ConsoleKey.D4:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            writeColor();
                            color = 4;
                            break;
                        case ConsoleKey.D5:
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            writeColor();
                            color = 5;
                            break;
                        case ConsoleKey.D6:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            writeColor();
                            color = 6;
                            break;
                        case ConsoleKey.D7:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            writeColor();
                            color = 7;
                            break;
                        case ConsoleKey.D8:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            writeColor();
                            color = 8;
                            break;
                        case ConsoleKey.D9:
                            Console.ForegroundColor = ConsoleColor.White;
                            writeColor();
                            color = 9;
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
                            currentFile[writeRow, writeCol] = $"{saturation},{color};";
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
                            
                            File.Delete(openedFile);
                            File.Create(openedFile).Close();
                            string currentFileString = "";
                            for (int i = 0; i < winHeight - 15; i++)
                            {
                                for (int j = 0; j < 147; j++)
                                {
                                    currentFileString += currentFile[i, j];
                                }
                                currentFileString += currentFile[i, 147].Substring(0,3);
                                if (i != winHeight - 16)
                                {
                                    currentFileString += "\n";
                                }
                            }
                            File.WriteAllText(openedFile, currentFileString);
                            Console.SetCursorPosition(11, 33);
                            Console.Write("File saved!");
                            Thread.Sleep(2500);
                            Environment.Exit(0);
                            break;

                    }

                } while (input.Key != ConsoleKey.Escape);
            } while (input.Key != ConsoleKey.Escape);
            
        }
    }
}