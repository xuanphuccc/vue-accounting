using System.ComponentModel.DataAnnotations;

namespace MISA.WebFresher052023.Domain
{
    public class Position : BaseAuditEntity, IHasKey, IHasCode
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required]
        public Guid PositionId { get; set; }

        /// <summary>
        /// Mã vị trí
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required]
        [StringLength(20)]
        public string PositionCode { get; set; } = string.Empty;

        /// <summary>
        /// Tên vị trí
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [Required]
        [StringLength(255)]
        public string PositionName { get; set; } = string.Empty;

        /// <summary>
        /// Mô tả
        /// </summary>
        /// CreatedBy: txphuc (14/07/2023)
        [StringLength(255)]
        public string? Description { get; set; }

        /// <summary>
        /// Lấy id của vị trí
        /// </summary>
        /// <returns>Id của vị trí</returns>
        /// CreatedBy: txphuc (19/07/2023)
        public Guid GetKey()
        {
            return PositionId;
        }

        /// <summary>
        /// Lấy mã của vị trí
        /// </summary>
        /// <returns>Mã của vị trí</returns>
        /// CreatedBy: txphuc (18/07/2023)
        public string GetCode()
        {
            return PositionCode;
        }
    }
}
