using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Domain
{
    public interface IHasKey
    {
        /// <summary>
        /// Lấy Id của đối tượng
        /// </summary>
        /// <returns>Id của đối tượng</returns>
        /// CreatedBy: txphuc (18/07/2023)
        Guid GetKey();
    }
}
