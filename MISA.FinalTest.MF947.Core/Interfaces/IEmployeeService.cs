using MISA.FinalTest.MF947.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FinalTest.MF947.Core.Interfaces
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        /// <summary>
        /// Tự sinh mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        public string GetNewEmployeeCode();
    }
}
