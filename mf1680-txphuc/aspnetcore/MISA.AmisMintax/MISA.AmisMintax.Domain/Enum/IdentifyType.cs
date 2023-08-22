using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Domain
{
    public enum IdentifyType
    {
        /// <summary>
        /// Chứng minh nhân dân
        /// </summary>
        /// CreatedBy: txphuc (21/08/2023)
        NationalIdentityCard = 0,

        /// <summary>
        /// Căn cước công dân
        /// </summary>
        /// CreatedBy: txphuc (21/08/2023)
        CitizenCard = 1,

        /// <summary>
        /// Hộ chiếu
        /// </summary>
        /// CreatedBy: txphuc (21/08/2023)
        Passport = 2,
    }
}
