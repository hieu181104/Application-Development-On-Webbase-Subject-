using System;

namespace Love_Compatibility
{
    public class CompatibilityCalculator
    {
        // Properties để nhận input
        public string Name1 { get; set; }
        public string Name2 { get; set; }

        // Method tính toán và trả về kết quả dưới dạng string "percentage|message"
        public string CalculateCompatibility()
        {
            if (string.IsNullOrEmpty(Name1) || string.IsNullOrEmpty(Name2))
            {
                return "0|Vui lòng nhập cả hai tên.";
            }

            // Normalize tên (chuyển uppercase để check easter egg)
            string upperName1 = Name1.ToUpper();
            string upperName2 = Name2.ToUpper();

            // Dấu ấn cá nhân: Nếu chứa "HIEU ", luôn 100% với message đặc biệt
            if (upperName1.Contains("HIEU") || upperName2.Contains("HIEU"))
            {
                return "100|Hoàn hảo như HIEU!";
            }

            // Công thức Tính tổng ASCII của tất cả ký tự trong hai tên
            int totalAscii = 0;
            foreach (char c in Name1.ToCharArray())
            {
                totalAscii += (int)c;
            }
            foreach (char c in Name2.ToCharArray())
            {
                totalAscii += (int)c;
            }

            // Percentage: Mod 101 để ra 0-100
            int percentage = totalAscii % 101;
            
            // Message dựa trên percentage
            string message;
            if (percentage > 90)
            {
                message = "Hai bạn là tình yêu đích thực.";
            }
            else if (percentage > 80)
            {
                message = "Độ tương thích cao.";
            }
            else if (percentage >= 50)
            {
                message = "Độ tương thích bình thường.";
            }
            else
            {
                message = "Độ tương thích thấp.";
            }

            return percentage.ToString() + "|" + message;
        }
    }
}
