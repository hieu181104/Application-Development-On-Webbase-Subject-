using System;
using System.Text;
using Love_Compatibility;

namespace LoveCompatibilityConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // Nhập input từ console
                Console.OutputEncoding = Encoding.UTF8;
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("=== Love Compatibility Calculator ===");
                Console.Write("Enter your name (or exit to quit): ");
                string name1 = Console.ReadLine();

                if (name1.ToLower() == "exit")
                    break;

                Console.Write("Enter your crush name: ");
                string name2 = Console.ReadLine();

                // Tạo instance từ DLL và tính toán
                CompatibilityCalculator calc = new CompatibilityCalculator();
                calc.Name1 = name1;
                calc.Name2 = name2;
                string result = calc.CalculateCompatibility();

                // Phân tách kết quả (percentage|message)
                string[] parts = result.Split('|');
                int percentage = int.Parse(parts[0]);
                string message = parts[1];

                // Hiển thị kết quả
                Console.WriteLine("\nTheo LOVE COMPATIBILITY CALCULATOR:");
                Console.WriteLine($"Do tuong thich giua {name1} and {name2}: {percentage}%");
                Console.WriteLine(message);

                // Thêm hiệu ứng cá nhân: emoji đơn giản bằng ký tự
                if (percentage > 90)
                    Console.WriteLine("♥♥♥ Hai ban la dinh menh! ♥♥♥");
                else if (percentage > 80)
                    Console.WriteLine("♥♥ Tuyet voi lam! ♥♥");
                else if (percentage >= 50)
                    Console.WriteLine("♥ Co tiem nang day! ♥");
                else
                    Console.WriteLine("☹ Co len nhe! ☹");

                Console.WriteLine("\nNhan Enter de tiep tuc hoac nhap Exit de thoat...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
