using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Xml.Linq;

namespace File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //ShowListFolder("C:\\Users\\MY PC\\Downloads");
            //D:\\NTQ_Solution\\dev23\\TestFile
            //Console.WriteLine("THAO TÁC VỚI FILE\n");
            //Console.WriteLine("Nhập đường dẫn:");
            //string path = Console.ReadLine();

            //if (!CheckExists(path))
            //{
            //    do
            //    {
            //        Console.WriteLine("Đường link không tồn tại! \nNhập hành động tiếp theo:");
            //        Console.WriteLine("0.Thoát chương trình.");
            //        Console.WriteLine("1.Nhập lại đường link.");
            //        int hd1 = Convert.ToInt32(Console.ReadLine());
            //        switch (hd1)
            //        {
            //            case 0:
            //                return;
            //            case 1:
            //                Console.WriteLine("Nhập đường dẫn:");
            //                path = Console.ReadLine();
            //                break;
            //            default:
            //                break;
            //        }
            //    } while (!CheckExists(path));
            //}
            //ShowListFolder(path);
            //ShowListFile(path);

            //int hd2;
            //Console.WriteLine("-----------------------------");
            //Console.WriteLine("\nCác thao tác:");
            //Console.WriteLine("0.Thoát chương trình.");
            //Console.WriteLine("1.Thao tác với File.");
            //Console.WriteLine("2.Thao tác với Folder.");
            //hd2 = Convert.ToInt32(Console.ReadLine());

            //if (hd2 < 0 || hd2 > 2)
            //{
            //    do
            //    {
            //        Console.WriteLine("\nBạn đã nhập sai!\nMời nhập lại:");
            //        Console.WriteLine("0.Thoát chương trình.");
            //        Console.WriteLine("1.Thao tác với File.");
            //        Console.WriteLine("2.Thao tác với Folder.");
            //        hd2 = Convert.ToInt32(Console.ReadLine());
            //    } while (hd2 < 0 || hd2 > 2);
            //}

            //switch (hd2)
            //{
            //    case 0:
            //        return;
            //    case 1:
            //        WorkWithFile(path);
            //        break;
            //    case 2:
            //        WorkWithFolder(path);
            //        break;
            //    default:
            //        break;
            //}
            DateTime date1 = DateTime.Now;
            Console.WriteLine(date1.ToString());

            // Get date-only portion of date, without its time.
            DateTime dateOnly = date1.Date;
            // Display date using short date string.
            Console.WriteLine(dateOnly.ToString("d"));
            // Display date using 24-hour clock.
            Console.WriteLine(dateOnly.ToString("g"));
            Console.WriteLine(dateOnly.ToString("MM/dd/yyyy HH:mm"));
            Console.ReadKey();
        }

        static bool CheckExists(string path)
        {
            if (Directory.Exists(path) || System.IO.File.Exists(path))
            {
                return true;
            }
            return false;
        }

        static string GetFileName(string path)
        {
            return path.Substring(0, path.IndexOf("."));
        }

        static string GetFileType(string path)
        {
            return path.Substring(path.IndexOf("."));
        }

        static void ShowListFile(string path)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("\nDanh sách các file:\n");
            var files = Directory.GetFiles(path);
            for (int i = 0; i < files.Count(); i++)
            {
                Console.WriteLine(i + 1 + "." + files[i].Trim().Substring(path.Length + 1));
            }
        }

        static void ShowListFolder(string path)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("\nDanh sách các thư mục:\n");
            var folders = Directory.GetDirectories(path);
            for (int i = 0; i < folders.Count(); i++)
            {
                Console.WriteLine(i + 1 + "." + folders[i].Trim().Substring(path.Length + 1));
            }
        }

        static List<string> GetListFile(string path)
        {
            List<string> list = new List<string>(Directory.GetFiles(path));
            return list;
        }

        static List<string> GetListFolder(string path)
        {
            List<string> list = new List<string>(Directory.GetDirectories(path));
            return list;
        }

        static void WorkWithFile(string path)
        {
            ShowListFile(path);
            List<string> listFile = new List<string>(Directory.GetFiles(path));
            // Các biến phục vụ cho việc thao tác với file
            int fileIndex;
            string f_Name;
            string f_Type;
            string f_CoppyName;

            int workWithFile;

            Console.WriteLine("-----------------------------");
            Console.WriteLine("\nCác thao tác:");
            Console.WriteLine("0.Thoát chương trình.");
            Console.WriteLine("1.Tạo file.");
            Console.WriteLine("2.Xóa file.");
            Console.WriteLine("3.Coppy file.");
            Console.WriteLine("4.Đổi tên file.");

            workWithFile = Convert.ToInt32(Console.ReadLine());

            if (workWithFile < 0 || workWithFile > 4)
            {
                do
                {
                    Console.WriteLine("\nBạn đã nhập sai!\nMời nhập lại:");
                    Console.WriteLine("0.Thoát chương trình.");
                    Console.WriteLine("1.Tạo file.");
                    Console.WriteLine("2.Xóa file.");
                    Console.WriteLine("3.Coppy file.");
                    Console.WriteLine("4.Đổi tên file.");
                    workWithFile = Convert.ToInt32(Console.ReadLine());
                } while (workWithFile < 0 || workWithFile > 4);
            }

            switch (workWithFile)
            {
                case 0:
                    return;
                case 1:
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Nhập tên file mới:");
                    string fileName = Console.ReadLine();
                    string filePath = path + "\\" + fileName;
                    try
                    {
                        if (CheckExists(filePath))
                        {
                            do
                            {
                                Console.WriteLine("\nFile đã tồn tại!");
                                Console.WriteLine("Nhập tên file mới:");
                                fileName = Console.ReadLine();
                                filePath = path + "\\" + fileName;
                            } while (CheckExists(filePath));
                        }
                        System.IO.File.Create(filePath);
                        Console.WriteLine("Tạo file thành công!");
                    }
                    catch
                    {
                        Console.WriteLine("Lỗi tạo file!");
                    }
                    break;
                case 2:
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Nhập số thứ tự file muốn xóa:");
                    fileIndex = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        System.IO.File.Delete(listFile[fileIndex - 1]);
                        Console.WriteLine("Xóa file thành công!");
                    }
                    catch
                    {
                        Console.WriteLine("Có lỗi xảy ra!");
                    }
                    break;
                case 3:
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Nhập số thứ tự file muốn copy:");
                    fileIndex = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        f_Name = GetFileName(listFile[fileIndex - 1]);
                        f_Type = GetFileType(listFile[fileIndex - 1]);
                        f_CoppyName = f_Name + "_copy" + f_Type;
                        if (CheckExists(f_CoppyName))
                        {
                            int i = 1;
                            do
                            {
                                f_CoppyName = f_Name + "_copy" + $"({i})" + f_Type;
                            } while (CheckExists(f_CoppyName));
                            System.IO.File.Copy(listFile[fileIndex - 1], f_CoppyName);
                        }
                        else
                        {
                            System.IO.File.Copy(path + "" + listFile[fileIndex - 1], f_Name + "_copy" + f_Type);
                        }
                        Console.WriteLine("Copy thành công!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Có lỗi xảy ra!\n" + e.Message);
                    }
                    break;
                case 4:
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Nhập số thứ tự file muốn đổi tên:");
                    fileIndex = Convert.ToInt32(Console.ReadLine());
                    f_Type = GetFileType(listFile[fileIndex - 1]);

                    Console.WriteLine("Nhập tên file mới:");
                    string newFileName = Console.ReadLine();
                    try
                    {
                        while (CheckExists(newFileName + f_Type))
                        {
                            Console.WriteLine("Tên file vừa nhập đã tồn tại!");
                            Console.WriteLine("Nhập tên file mới:");
                            newFileName = Console.ReadLine();
                        }
                        System.IO.File.Move(listFile[fileIndex - 1], path + "\\" + newFileName + f_Type);
                        Console.WriteLine("Sửa tên file thành công!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Có lỗi xảy ra!\n" + e.Message);
                    }
                    break;
                default:
                    break;
            }

        }

        static void WorkWithFolder(string path)
        {
            //D:\\NTQ_Solution\\dev23\\TestFile
            ShowListFolder(path);
            List<string> listFolder = new List<string>(Directory.GetDirectories(path));
            //Các biến phục vụ cho việc thao tác với folder
            int folderIndex;
            string f_CoppyName;
            string f_Name;

            int workWithFolder;

            Console.WriteLine("-----------------------------");
            Console.WriteLine("\nCác thao tác:");
            Console.WriteLine("0.Thoát chương trình.");
            Console.WriteLine("1.Tạo folder.");
            Console.WriteLine("2.Xóa folder.");
            Console.WriteLine("3.Coppy folder.");
            Console.WriteLine("4.Đổi tên folder.");

            workWithFolder = Convert.ToInt32(Console.ReadLine());

            if (workWithFolder < 0 || workWithFolder > 4)
            {
                do
                {
                    Console.WriteLine("\nBạn đã nhập sai!\nMời nhập lại:");
                    Console.WriteLine("0.Thoát chương trình.");
                    Console.WriteLine("1.Tạo folder.");
                    Console.WriteLine("2.Xóa folder.");
                    Console.WriteLine("3.Coppy folder.");
                    Console.WriteLine("4.Đổi tên folder.");
                    workWithFolder = Convert.ToInt32(Console.ReadLine());
                } while (workWithFolder < 0 || workWithFolder > 4);
            }

            switch (workWithFolder)
            {
                case 0:
                    return;
                case 1:
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Nhập tên folder mới:");
                    string folderName = Console.ReadLine();
                    string folderPath = path + "\\" + folderName;
                    try
                    {
                        if (CheckExists(folderPath))
                        {
                            do
                            {
                                Console.WriteLine("\nFolder đã tồn tại!");
                                Console.WriteLine("Nhập tên folder mới:");
                                folderName = Console.ReadLine();
                                folderPath = path + "\\" + folderName;
                            } while (CheckExists(folderPath));
                        }
                        Directory.CreateDirectory(folderPath);
                        Console.WriteLine("Tạo folder thành công!");
                    }
                    catch
                    {
                        Console.WriteLine("Lỗi tạo folder!");
                    }
                    break;
                case 2:
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Nhập số thứ tự folder muốn xóa:");
                    folderIndex = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        Directory.Delete(listFolder[folderIndex - 1]);
                        Console.WriteLine("Xóa folder thành công!");
                    }
                    catch
                    {
                        Console.WriteLine("Có lỗi xảy ra!");
                    }
                    break;
                case 3:
                    //Console.WriteLine("-----------------------------");
                    //Console.WriteLine("Nhập số thứ tự file muốn copy:");
                    //folderIndex = Convert.ToInt32(Console.ReadLine());
                    //try
                    //{
                    //    f_Name = listFolder[folderIndex - 1];
                    //    f_CoppyName = f_Name + "(copy)";
                    //    if (CheckExists(path + "\\" + f_CoppyName))
                    //    {
                    //        int i = 1;
                    //        do
                    //        {
                    //            f_CoppyName = f_Name + "(copy)" + $"({i})";
                    //        } while (CheckExists(f_CoppyName));
                    //        System.IO.File.Copy(listFile[fileIndex - 1], f_CoppyName);
                    //    }
                    //    else
                    //    {
                    //        System.IO.File.Copy(path + "" + listFile[fileIndex - 1], f_Name + "_copy" + f_Type);
                    //    }
                    //    Console.WriteLine("Copy thành công!");
                    //}
                    //catch (Exception e)
                    //{
                    //    Console.WriteLine("Có lỗi xảy ra!\n" + e.Message);
                    //}
                    break;
                case 4:
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Nhập số thứ tự folder muốn đổi tên:");
                    folderIndex = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Nhập tên folder mới:");
                    string newFolderName = Console.ReadLine();
                    try
                    {
                        while (CheckExists(path + "\\" + newFolderName))
                        {
                            Console.WriteLine("Folder vừa nhập đã tồn tại!");
                            Console.WriteLine("Nhập tên folder mới:");
                            newFolderName = Console.ReadLine();
                        }
                        Directory.Move(listFolder[folderIndex - 1], path + "\\" + newFolderName);
                        Console.WriteLine("Sửa tên folder thành công!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Có lỗi xảy ra!\n" + e.Message);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
