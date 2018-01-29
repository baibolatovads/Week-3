using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAR1
{
    class Program
    {
        static void ShowDirectoryInfo(DirectoryInfo directory, int cursor)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            FileSystemInfo[] fileSystemInfos = directory.GetFileSystemInfos();

            for (int index = 0; index < fileSystemInfos.Length; index++)
            {
                FileSystemInfo fileSystemInfo = fileSystemInfos[index];
                if (index == cursor)
                    Console.BackgroundColor = ConsoleColor.Gray;
                else
                    Console.BackgroundColor = ConsoleColor.White;

                if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                Console.WriteLine(fileSystemInfo.Name);
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Users\User_PC\Documents\PP2\Student");
            int cursor = 0;
            int n = directoryInfo.GetFileSystemInfos().Length;
            ShowDirectoryInfo(directoryInfo, cursor);

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor == n)
                        cursor = 0;
                }
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor == -1)
                        cursor = n - 1;
                }
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (directoryInfo.GetFileSystemInfos()[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        directoryInfo = new DirectoryInfo(directoryInfo.GetFileSystemInfos()[cursor].FullName);
                        cursor = 0;
                        n = directoryInfo.GetFileSystemInfos().Length;
                    }
                    else
                    {
                        StreamReader sr = new StreamReader(directoryInfo.GetFileSystemInfos()[cursor].FullName);
                        string s = sr.ReadToEnd();
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(s);
                        Console.ReadKey();
                    }
                }
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    if (directoryInfo.Parent != null)
                    {
                        directoryInfo = directoryInfo.Parent;
                        cursor = 0;
                        n = directoryInfo.GetFileSystemInfos().Length;
                    }
                    else
                        break;
                }
                ShowDirectoryInfo(directoryInfo, cursor);
            }
        }
    }
}
