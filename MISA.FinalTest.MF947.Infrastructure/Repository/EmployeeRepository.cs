using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.FinalTest.MF947.Core.Entity;
using MISA.FinalTest.MF947.Core.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FinalTest.MF947.Infrastructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public dynamic GetEmployeeFilterPagin(string filter, int? offSet, int? size, bool check)
        {
            //Xử lí tham số đầu vào
           
            var employeeFilter = filter != null ? filter : string.Empty ;
            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeFilter", employeeFilter, DbType.String);
            parameters.Add("@Offset", offSet);
            parameters.Add("@Size", size);
            parameters.Add("@TotalRecord", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@TotalPage", dbType: DbType.Int32, direction: ParameterDirection.Output);
           using(IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                var employees = dbConnection.Query<Employee>("Proc_GetEmployeeFilterPaging", param: parameters, commandType: CommandType.StoredProcedure);
                var totRecord = parameters.Get<int>("TotalRecord");
                var totPage = parameters.Get<int>("TotalPage");
                var result = new
                {
                    employeeList = employees,
                    totalRecord = totRecord,
                    totalPage = totPage,
                };
                if (check)
                {
                    return result;
                }
                else
                {
                    return employees.ToList();
                }
            }
        }
    }
}
