using MISA.FinalTest.MF947.Core.Attributes;
using MISA.FinalTest.MF947.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FinalTest.MF947.Core.Entity
{
    public class Employee: BaseEntity
    {
        public Guid EmployeeId { get; set; }

        [MISARequire("Mã nhân viên")]
        [MISAPropExport]
        [Description("Mã nhân viên")]
        public string EmployeeCode { get; set; }

        [MISARequire("Họ tên đầy đủ nhân viên")]
        [MISAPropExport]
        [Description("Họ và tên")]
        public string FullName { get; set; }
        [MISAPropExport]
        [Description("Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }

        public int? Gender { get; set; }
        public string Email { get; set; }
        [MISAPropExport]
        [Description("Điện thoại di động")]
        public string MobilePhoneNumber { get; set; }
        public string TelePhoneNumber { get; set; }
        [MISAPropExport]
        [Description("Số tài khoản")]
        public string BankAccountNumber { get; set; }
        [MISAPropExport]
        [Description("Tên ngân hàng")]
        public string BankName { get; set; }
        [MISAPropExport]
        [Description("Chi nhánh ngân hàng")]
        public string BankBranch { get; set; }
        [MISAPropExport]
        [Description("Địa chỉ")]
        public string Address { get; set; }
        public string IdentityPlace { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime? IdentityDate { get; set; }
        public Guid DepartmentId { get; set; }
        [MISANotMap]
        public string GenderName { get; set; }

        [MISANotMap]
        [MISAPropExport]
        [Description("Tên đơn vị")]
        public string DepartmentName { get; set; }
        [MISAPropExport]
        [Description("Chức danh")]
        public string PositionName { get; set; }
    }
}
