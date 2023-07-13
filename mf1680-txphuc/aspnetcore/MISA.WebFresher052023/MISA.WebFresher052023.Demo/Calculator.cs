namespace MISA.WebFresher052023.Demo
{
    public class Calculator
    {

        /// <summary>
        /// Hàm cộng hai số
        /// </summary>
        /// <param name="x">Số thứ nhất</param>
        /// <param name="y">Số thứ hai</param>
        /// <returns>Tổng hai số</returns>
        /// CreatedBy: txphuc (13/07/2023)
        public long Add(int x, int y)
        {
            return x + (long)y;
        }

        /// <summary>
        /// Tính tổng một chuỗi các số nguyên
        /// </summary>
        /// <param name="str">Chuỗi số nguyên phân tách nhau bởi dấu `,`</param>
        /// <returns>
        /// - Trả về 0 nếu là chuỗi rỗng
        /// - Trả về Exception nếu trong chuỗi có số âm
        /// - Trả về tổng của các số trong chuỗi nếu hợp lệ
        /// </returns>
        /// CreatedBy: txphuc (13/07/2023)
        public int Add(string str)
        {
            try
            {
                if (str == "")
                {
                    // Trường hợp chuỗi rỗng
                    return 0;
                }
                else if (str.Contains('-'))
                {
                    // Trường hợp chứa số âm
                    var negativeNumbers = str.Split(',')
                                            .Where(number => number.Contains('-'))
                                            .Select(number => number.Trim());
                    var errorMessage = $"Không chấp nhận toán tử âm: {string.Join(", ", negativeNumbers)}";

                    throw new Exception(errorMessage);
                }
                else
                {
                    // Trường hợp là một hoặc nhiều số KHÔNG âm cách nhau bởi dấu `,`
                    var result = str.Split(',').Select(number => Int32.Parse(number)).Sum();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Đối số truyền vào không phải là chuỗi các số");
            }
        }

        /// <summary>
        /// Hàm trừ hai số
        /// </summary>
        /// <param name="x">Số thứ nhất</param>
        /// <param name="y">Số thứ hai</param>
        /// <returns>Hiệu hai số</returns>
        /// CreatedBy: txphuc (13/07/2023)
        public long Sub(int x, int y)
        {
            return x - (long)y;
        }

        /// <summary>
        /// Hàm nhân hai số
        /// </summary>
        /// <param name="x">Số thứ nhất</param>
        /// <param name="y">Số thứ hai</param>
        /// <returns>Tích hai số</returns>
        /// CreatedBy: txphuc (13/07/2023)
        public long Mul(int x, int y)
        {
            return x * (long)y;
        }

        /// <summary>
        /// Hàm chia hai số
        /// </summary>
        /// <param name="x">Số thứ nhất</param>
        /// <param name="y">Số thứ hai</param>
        /// <returns>Thương hai số</returns>
        /// <exception cref="Exception"></exception>
        /// CreatedBy: txphuc (13/07/2023)
        public double Div(int x, int y)
        {
            if (y == 0)
            {
                throw new Exception("Không chia được cho 0");
            }

            return x / (double)y;
        }
    }
}
