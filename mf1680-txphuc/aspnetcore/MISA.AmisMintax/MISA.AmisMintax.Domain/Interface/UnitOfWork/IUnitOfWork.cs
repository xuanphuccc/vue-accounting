using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Domain
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        DbConnection Connection { get; }
        DbTransaction? Transaction { get; }

        /// <summary>
        /// Bắt đầu một transaction
        /// </summary>
        /// CreatedBy: txphuc (18/07/2023)
        void BeginTransaction();

        /// <summary>
        /// Bắt đầu một transaction bất đồng bộ
        /// </summary>
        /// CreatedBy: txphuc (18/07/2023)
        Task BeginTransactionAsync();

        /// <summary>
        /// Xác nhận và thực thi
        /// </summary>
        /// CreatedBy: txphuc (18/07/2023)
        void Commit();

        /// <summary>
        /// Xác nhận và thực thi bất đồng bộ
        /// </summary>
        /// CreatedBy: txphuc (18/07/2023)
        Task CommitAsync();

        /// <summary>
        /// Hoàn tác transaction
        /// </summary>
        /// CreatedBy: txphuc (18/07/2023)
        void RollBack();

        /// <summary>
        /// Hoàn tác transaction bất đồng bộ
        /// </summary>
        /// CreatedBy: txphuc (18/07/2023)
        Task RollBackAsync();
    }
}
