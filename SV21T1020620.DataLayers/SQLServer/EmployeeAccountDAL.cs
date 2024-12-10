﻿using Dapper;
using SV21T1020620.DomainModels;
using System.Data;

namespace SV21T1020620.DataLayers.SQLServer
{
    public class EmployeeAccountDAL : BaseDAL, IUserAccountDAL
    {
        public EmployeeAccountDAL(string connectionString) : base(connectionString)
        {
        }

        public bool ChangePassword(string username, string password)
        {
            using (var connection = OpenConnection())
            {
                // Query cập nhật mật khẩu
                var sql = @"
                    UPDATE Employees
                    SET Password = @Password
                    WHERE Email = @Email";

                var parameters = new
                {
                    Email = username,
                    Password = password
                };

                // Thực thi câu lệnh và kiểm tra kết quả
                int rowsAffected = connection.Execute(sql: sql, param: parameters, commandType: CommandType.Text);
                connection.Close();

                return rowsAffected > 0; // Trả về true nếu có dòng bị ảnh hưởng
            }
        }

        public UserAccount? Authorize(string username, string password)
        {
            UserAccount? data = null;
            using (var connection = OpenConnection())
            {
                var sql = @"
                            SELECT 
                                EmployeeID AS UserId, 
                                Email AS UserName, 
                                FullName AS DisplayName, 
                                Photo, 
                                RoleNames 
                            FROM Employees 
                            WHERE Email = @Email AND Password = @Password";

                var parameters = new
                {
                    Email = username,
                    Password = password
                };
                data = connection.QueryFirstOrDefault<UserAccount>(sql: sql, param: parameters, commandType: CommandType.Text);
                connection.Close();
            }
            return data;
        }
    }
}
