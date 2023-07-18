using MISA.WebFresher052023.Domain;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DbConnection _connection;
        private DbTransaction? _transaction = null;

        public UnitOfWork(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
        }

        public DbConnection Connection => _connection;

        public DbTransaction? Transaction => _transaction;

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

        public void Commit()
        {
            _transaction?.Commit();
            Dispose();
        }

        public async Task CommitAsync()
        {
            if (_transaction != null)
            {

                await _transaction.CommitAsync();
            }

            await DisposeAsync();

        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _transaction = null;

            _connection.Close();
        }

        public async ValueTask DisposeAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
            }

            _transaction = null;

            await _connection.CloseAsync();
        }

        public void RollBack()
        {
            _transaction?.Rollback();
            Dispose();
        }

        public async Task RollBackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }

            await DisposeAsync();
        }
    }
}
