using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.FinalTest.MF947.Core.Attributes;
using MISA.FinalTest.MF947.Core.Entity;
using MISA.FinalTest.MF947.Core.Interfaces;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.FinalTest.MF947.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseEntityController<Employee>
    {
        IEmployeeService _employeeService;
        IEmployeeRepository _employeeRepository;
        public EmployeesController(IBaseRepository<Employee> baseRepository, IBaseService<Employee> baseService,
                                    IEmployeeService employeeService, IEmployeeRepository employeeRepository): base(baseRepository,baseService)
        {
            _employeeService = employeeService;
            _employeeRepository = employeeRepository;
        }

        [HttpGet("NewCode")]
        public IActionResult GetNewCode()
        {
            try
            {
                var newEmployeeCode = _employeeService.GetNewEmployeeCode();
                return Ok(newEmployeeCode);
            }
            catch (Exception ex)
            {
                var obj = new
                {
                    devMsg = ex.Message,
                    userMsg = Core.Properties.Resources.MISAException_Error,
                    errorCode = Core.Properties.Resources.MISAErroCode,
                    moreInfor = Core.Properties.Resources.MISAErroMoreInfor,
                };
                return StatusCode(500, obj);
            }
        }

        [HttpGet("filterpaging")]
        public IActionResult GetEmployeeFilterPaging([FromQuery]string filter, [FromQuery] int offset, [FromQuery] int size)
        {
            try
            {
                var result = _employeeRepository.GetEmployeeFilterPagin(filter, offset, size,true);
                if(result != null)
                {
                    return StatusCode(200, result);
                }
                else
                {
                    return StatusCode(204);
                }
            }
            catch (Exception ex)
            {
                var obj = new
                {
                    devMsg = ex.Message,
                    userMsg = Core.Properties.Resources.MISAException_Error,
                    errorCode = Core.Properties.Resources.MISAErroCode,
                    moreInfor = Core.Properties.Resources.MISAErroMoreInfor,
                };
                return StatusCode(500, obj);
            }
        }

        [HttpGet("export")]
        public IActionResult Export([FromQuery] string filter, [FromQuery] int offset, [FromQuery] int size)
        {
             Task.Yield();

            var stream = new MemoryStream();
            var employees = new List<Employee>();
            var datas = _employeeRepository.GetEmployeeFilterPagin(filter, offset, size, false);
            foreach (var data in datas)
            {
                employees.Add(data);
            }
            var properties = typeof(Employee).GetProperties();

            using (var package = new ExcelPackage(stream))
            {

                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(employees, true);
                var column = 1;

                foreach (var prop in properties)
                {
                    var propMISAExport = prop.GetCustomAttributes(typeof(MISAPropExport), true);

                    workSheet.Cells.AutoFitColumns();

                    if (!(propMISAExport.Length == 1))
                    {
                        workSheet.Column(column).Hidden = true;
                    }

                    // dinh dang ngay thang nam
                    if (prop.PropertyType.Name.Contains(typeof(Nullable).Name) && prop.PropertyType.GetGenericArguments()[0] == typeof(DateTime))
                    {
                        workSheet.Column(column).Style.Numberformat.Format = "mm/dd/yyyy";
                    }

                    column++;
                }

                package.Save();
            }

            stream.Position = 0;
            string excelName = $"DanhSachNhanVien.xlsx";

            //return File(stream, "application/octet-stream", excelName);  
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
    }
}
