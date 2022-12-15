using System;
using System.IO;
using System.Linq;


namespace Modul8_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до папки:");
            string path = Console.ReadLine();
            DirectoryInfo di = new DirectoryInfo(path);
            if (di.Exists)
            {
                DeleteFolder(path);
            }
            else
            {
                Console.WriteLine("Папка не найдена. Проверьте правильность указанного пути");
            }

        }
        private static void DeleteFolder(string folder)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(folder);
                DirectoryInfo[] diA = di.GetDirectories();
                FileInfo[] fi = di.GetFiles();
                foreach (FileInfo f in fi)
                {
                    if (DateTime.Now - f.LastAccessTime > TimeSpan.FromMinutes(30) && f.Exists)
                    {
                        f.Delete();
                    }
                }
                foreach (DirectoryInfo df in diA)
                {
                    if (df.Exists)
                    {
                        DeleteFolder(df.FullName);
                    }
                    else
                    {
                        Console.WriteLine("Папка не существует");
                    }

                }
                if (di.GetDirectories().Length == 0 && di.GetFiles().Length == 0) di.Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
