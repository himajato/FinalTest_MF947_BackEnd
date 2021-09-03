using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.FinalTest.MF947.Core.Entities;
using MISA.FinalTest.MF947.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.FinalTest.MF947.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DeparmentsController : BaseEntityController<Department>
    {
        public DeparmentsController(IBaseService<Department> baseService, IBaseRepository<Department> baseRepository) : base(baseRepository,baseService)
        {

        }
    }
}
