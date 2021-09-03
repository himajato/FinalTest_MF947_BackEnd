using MISA.FinalTest.MF947.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FinalTest.MF947.Core.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        public dynamic GetEmployeeFilterPagin(string filter, int? offSet, int? size, bool check);
    }
}
