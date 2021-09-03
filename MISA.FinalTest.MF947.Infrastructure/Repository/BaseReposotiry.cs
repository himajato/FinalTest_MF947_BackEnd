using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.FinalTest.MF947.Core.Attributes;
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
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>
    {
        public readonly string _connectionString;
        public readonly string _className;
        public BaseRepository(IConfiguration configuration)
        {
            _className = typeof(MISAEntity).Name;
            _connectionString = configuration.GetConnectionString("MISA_FinalTest_DB");
        }

        public List<MISAEntity> GetAll()
        {
            var className = typeof(MISAEntity).Name;

            //Truy cập vào database
            // Khởi tạo đối tượng kết nối với db
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                
                //3. Lấy dữ liệu: (thêm try catch)
                var sqlCommand = $"SELECT * FROM view_{className}";
                var entity = dbConnection.Query<MISAEntity>(sqlCommand);
                return (List<MISAEntity>)entity;
            }
        }

        public int Update(MISAEntity entity, Guid entityId)
        {
            var className = typeof(MISAEntity).Name;
            //Truy cập vào database  
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                // Khai báo dynamicParam: 
                DynamicParameters parameters = new DynamicParameters();


                // Lấy prop name và prop type: 
                //var columsName = string.Empty;
                var columsParam = string.Empty;

                var props = entity.GetType().GetProperties();

                //Duyệt từng properties
                foreach (var prop in props)
                {
                    if (prop.GetCustomAttributes(typeof(MISANotMap), true).Length == 0)
                    {
                        //Lấy tên của prop
                        var propName = prop.Name;

                        //Lấy value của prop
                        var propValue = prop.GetValue(entity);

                        //Lấy kiểu dữ liệu
                        var propType = prop.PropertyType;

                        //Thêm param tương ứng với mỗi propName của đối tượng
                        parameters.Add($"@{propName}", propValue);

                        // columsName += $"{propName},";
                        columsParam += $"{propName}=@{propName},";
                    }
                }

                ////Với CustomerCode
                ////Kiểm tra rỗng
                //if (customer.CustomerCode == "")
                //{
                //    var obj = new
                //    {
                //        devMsg = Properties.Resources.MISABadrequest_400_CustomerCode_Empty,
                //        userMsg = Properties.Resources.MISABadrequest_400_CustomerCode_Empty,
                //        errorCode = "Misa001",
                //        moreInfor = "google.com"
                //    };
                //    return StatusCode(400, obj);
                //}

                ////Kiểm tra trùng
                //var sqlComman1 = "SELECT CustomerCode FROM Customer WHERE CustomerCode = @CustomerCode";
                //var check = dbConnection.QueryFirstOrDefault(sqlComman1, param: parameters);
                //if (check != null)
                //{
                //    var obj = new
                //    {
                //        devMsg = Properties.Resources.MISABadrequest_400_CustomerCode_Duplicate,
                //        userMsg = Properties.Resources.MISABadrequest_400_CustomerCode_Duplicate,
                //        errorCode = "Misa001",
                //        moreInfor = "google.com"
                //    };
                //    return BadRequest(400, obj);
                //}

                // columsName = columsName.Remove(columsName.Length - 1, 1);
                parameters.Add($"@{className}Id", entityId);
                columsParam = columsParam.Remove(columsParam.Length - 1, 1);

                var sqlComman = $"UPDATE {className} SET {columsParam} WHERE {className}Id=@{className}Id";
                var rowEffect = dbConnection.Execute(sqlComman, param: parameters);
                return rowEffect;
            }
        }
        public object GetById(Guid entityId)
        {
            var className = typeof(MISAEntity).Name;
            //Truy cập vào database
            // Khởi tạo đối tượng kết nối với db 
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                // Lấy dữ liệu:
                var sqlCommand = $"SELECT * FROM view_{className} WHERE {className}Id = @{className}IdParam";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{className}IdParam", entityId);

                var entity = dbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: parameters);

                return entity;
            }
        }

        public int Add(MISAEntity entity)
        {
            //// Khởi tạo ID mới cho nhân viên
            var className = typeof(MISAEntity).Name;

            //Truy cập vào database
            //Khởi tạo đối tượng kết nối với db
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                // Khai báo dynamicParam: 
                DynamicParameters parameters = new DynamicParameters();

                //Lấy prop name và prop type: 
                var columsName = string.Empty;
                var columsParam = string.Empty;
                var props = entity.GetType().GetProperties();

                //Duyệt từng properties
                foreach (var prop in props)
                {
                    if (prop.GetCustomAttributes(typeof(MISANotMap), true).Length == 0)
                    {   
                        //Lấy tên của prop
                        var propName = prop.Name;

                        //Lấy value của prop
                        var propValue = prop.GetValue(entity);
                        // Nếu là  Id thì tự sinh ra Id mới
                        if (prop.Name == $"{className}Id" && prop.PropertyType == typeof(Guid))
                        {
                            propValue = Guid.NewGuid();
                        }

                        //Lấy kiểu dữ liệu
                        var propType = prop.PropertyType;

                        //Thêm param tương ứng với mỗi propName của đối tượng
                        parameters.Add($"@{propName}", propValue);
                        columsName += $"{propName},";
                        columsParam += $"@{propName},";
                    }
                }

                columsName = columsName.Remove(columsName.Length - 1, 1);
                columsParam = columsParam.Remove(columsParam.Length - 1, 1);

                var sqlComman = $"INSERT INTO {className}({columsName}) VALUES({columsParam})";

                var rowEffect = dbConnection.Execute(sqlComman, param: parameters);

                return rowEffect;
            }
        }

        public int Delete(Guid entityId)
        {
            var className = typeof(MISAEntity).Name;

            //Truy cập vào database
            // Khởi tạo đối tượng kết nối với db
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                // Khai báo dynamicParam: 
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{className}", entityId);

                var sqlComman = $"DELETE FROM {className} WHERE {className}Id = @{className}";

                var rowEffect = dbConnection.Execute(sqlComman, parameters);

                return rowEffect;
            }
        }


        /// <summary>
        /// Lấy hết dữ liệu của prop 
        /// </summary>
        /// <param name="propName">Tên prop</param>
        /// <returns>Một list prop</returns>
        public List<string> GetAllPropValueByName(string propName)
        {
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                var sqlComman = $"SELECT {propName} FROM {_className}";
                var listProp = dbConnection.Query<string>(sqlComman);

                return (List<string>)listProp;
            }
        }


        /// <summary>
        /// Kiểm tra trùng một prop của thực thể
        /// </summary>
        /// <param name="propValue">Giá trị của prop của thực thể</param>
        /// <param name="propName">Tên prop muốn check trùng của thực thể</param>
        /// <returns>kết quả kiểm tra: true - Không có mã trùng, false có mã trùng</returns>
        public bool CheckPropDuplicate(string propValue, string propName)
        {
            // Nên check theo CustomAtrribute
            var className = typeof(MISAEntity).Name;

            //Truy cập vào database MF947_NHNGHIA_CukCuk
            //1.Khai báo thông tin kết nối database: 

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ClassName", className);
            parameters.Add("@PropName", propName);
            parameters.Add("@PropValue", $"{propValue}");

            //2. Khởi tạo đối tượng kết nối với db
            using (IDbConnection dbConnection = new MySqlConnection(_connectionString))
            {
                var sqlComman = $"SELECT {propName} FROM {className} WHERE {propName} = @PropValue";
                var isExsist = dbConnection.QueryFirstOrDefault<string>(sqlComman, parameters);

                if (isExsist != null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
