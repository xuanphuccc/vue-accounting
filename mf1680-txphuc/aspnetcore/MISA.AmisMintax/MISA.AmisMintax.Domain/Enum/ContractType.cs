using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Domain
{
    public enum ContractType
    {
        /// <summary>
        /// Không cư trú
        /// </summary>
        /// CreatedBy: txhphuc (21/08/2023)
        NonResident = 0,

        /// <summary>
        /// Cư trú và có HĐLD từ 3 tháng trở lên
        /// </summary>
        /// CreatedBy: txhphuc (21/08/2023)
        ResidenceWithContract = 1,

        /// <summary>
        /// Cư trú và không đăng ký HĐLĐ/HĐLĐ dưới 3 tháng
        /// </summary>
        /// CreatedBy: txhphuc (21/08/2023)
        ResidenceWithoutContract = 2,
    }
}
