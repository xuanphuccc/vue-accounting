using MISA.AmisMintax.Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AmisMintax.Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly DbConnection _connection;
        private DbTransaction? _transaction = null;
        #endregion

        #region Constructors
        public UnitOfWork(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
        }
        #endregion

        #region Properties
        public DbConnection Connection => _connection;

        public DbTransaction? Transaction => _transaction;
        #endregion

        #region Methods
        /// <summary>
        /// Bắt đầu một transaction
        /// </summary>
        /// CreatedBy: txphuc (18/07/2023)
        public void BeginTransaction()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _transaction = _connection.BeginTransaction();
            }
            else
            {
                _connection.Open();
                _transaction = _connection.BeginTransaction();
            }

        }

        /// <summary>
        /// Bắt đầu một transaction bất đồng bộ
        /// </summary>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task BeginTransactionAsync()
        {
            if (_connection.State == ConnectionState.Open)
            {

                _transaction = _connection.BeginTransaction();
            }
            else
            {
                await _connection.OpenAsync();
                _transaction = await _connection.BeginTransactionAsync();
            }
        }

        /// <summary>
        /// Xác nhận và thực thi
        /// </summary>
        /// CreatedBy: txphuc (18/07/2023)
        public void Commit()
        {
            _transaction?.Commit();
            Dispose();
        }

        /// <summary>
        /// Xác nhận và thực thi bất đồng bộ
        /// </summary>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task CommitAsync()
        {
            if (_transaction != null)
            {

                await _transaction.CommitAsync();
            }

            await DisposeAsync();

        }

        /// <summary>
        /// Đóng kết nối
        /// </summary>
        /// CreatedBy: txphuc (18/07/2023)
        public void Dispose()
        {
            _transaction?.Dispose();
            _transaction = null;

            _connection.Close();
        }

        /// <summary>
        /// Đóng kết nối bất đồng bộ
        /// </summary>
        /// CreatedBy: txphuc (18/07/2023)
        public async ValueTask DisposeAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
            }

            _transaction = null;

            await _connection.CloseAsync();
        }

        /// <summary>
        /// Hoàn tác transaction
        /// </summary>
        /// CreatedBy: txphuc (18/07/2023)
        public void RollBack()
        {
            _transaction?.Rollback();
            Dispose();
        }

        /// <summary>
        /// Hoàn tác transaction bất đồng bộ
        /// </summary>
        /// CreatedBy: txphuc (18/07/2023)
        public async Task RollBackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }

            await DisposeAsync();
        } 
        #endregion
    }
}
