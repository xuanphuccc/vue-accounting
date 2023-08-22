using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Domain
{
    public interface IHasCode
    {
        /// <summary>
        /// Lấy mã của đối tượng
        /// </summary>
        /// <returns>Mã của đối tượng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        string GetCode();
    }
}
