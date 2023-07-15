﻿using MISA.WebFresher052023.Domain;
using Dapper;
using System.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher052023.Infrastructure
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DbConnection _connection;

        public DepartmentRepository(DbConnection connection)
        {
            _connection = connection;
        }



        /// <summary>
        /// Lấy toàn bộ danh sách đơn vị
        /// </summary>
        /// <returns>Danh sách đơn vị</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            var sql = "Proc_Department_GetAll";

            var departments = await _connection.QueryAsync<Department>(sql, commandType: CommandType.StoredProcedure);

            return departments;
        }

        /// <summary>
        /// Lấy đơn vị theo Id
        /// </summary>
        /// <param name="departmentId">Id của đơn vị</param>
        /// <returns>Thông tin đơn vị</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<Department> GetByIdAsync(Guid departmentId)
        {
            var sql = "Proc_Department_GetById";

            var parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", departmentId);

            var department = await _connection.QueryFirstOrDefaultAsync<Department>(sql, parameters, commandType: CommandType.StoredProcedure);

            if (department == null)
            {
                throw new NotFoundException("Đơn vị không tồn tại");
            }

            return department;
        }

        /// <summary>
        /// Tạo đơn vị mới
        /// </summary>
        /// <param name="department">Thông tin đơn vị</param>
        /// <returns>Số bản ghi được thêm</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<int> InsertAsync(Department department)
        {
            var sql = "Proc_Deparment_Create";

            var parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", department.DepartmentId);
            parameters.Add("@DepartmentCode", department.DepartmentCode);
            parameters.Add("@DepartmentName", department.DepartmentName);
            parameters.Add("@Description", department.Description);
            parameters.Add("@CreatedDate", department.CreatedDate);
            parameters.Add("@CreatedBy", department.CreatedBy);
            parameters.Add("@ModifiedDate", department.ModifiedDate);
            parameters.Add("@ModifiedBy", department.ModifiedBy);

            var result = await _connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// Cập nhật đơn vị
        /// </summary>
        /// <param name="department">Thông tin đơn vị</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<int> UpdateAsync(Department department)
        {
            var sql = "Proc_Deparment_Update";

            var parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", department.DepartmentId);
            parameters.Add("@DepartmentCode", department.DepartmentCode);
            parameters.Add("@DepartmentName", department.DepartmentName);
            parameters.Add("@Description", department.Description);
            parameters.Add("@ModifiedDate", department.ModifiedDate);
            parameters.Add("@ModifiedBy", department.ModifiedBy);

            var result = await _connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// Xoá một đơn vị
        /// </summary>
        /// <param name="department">Thông tin đơn vị</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: txphuc (15/07/2023)
        public async Task<int> DeleteAsync(Department department)
        {
            var sql = "Proc_Deparment_Delete";

            var parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", department.DepartmentId);

            var result = await _connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
