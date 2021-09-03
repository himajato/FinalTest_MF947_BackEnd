using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.FinalTest.MF947.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.FinalTest.MF947.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseEntityController<MISAEntity> : ControllerBase
    {
        IBaseRepository<MISAEntity> _baseRepository;
        IBaseService<MISAEntity> _baseService;
        public BaseEntityController(IBaseRepository<MISAEntity> baseRepository, IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
            _baseRepository = baseRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var list = _baseRepository.GetAll();
                if (list.Count > 0)
                {
                    return StatusCode(200, list);
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

        [HttpGet("{entityId}")]
        public IActionResult GetById(Guid entityId)
        {
            try
            {
                var employee = _baseRepository.GetById(entityId);
                if (employee != null)
                {
                    return StatusCode(200, employee);
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

        [HttpPost]
        public IActionResult Add(MISAEntity entity)
        {
            try
            {
                var serviceResult = _baseService.Add(entity);
                if (serviceResult.IsValid == true)
                {
                    return StatusCode(201, serviceResult);
                }
                else
                {
                    return StatusCode(400, serviceResult.Data);
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

        [HttpPut("{entityId}")]
        public IActionResult Update(MISAEntity entity,Guid entityId)
        {
            try
            {
                var serviceResult = _baseService.Update(entity, entityId);
                if (serviceResult.IsValid)
                {
                    return StatusCode(200, serviceResult.RowEffect);
                }
                else
                {
                    return StatusCode(400, serviceResult.Data);
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

        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            try
            {
                var result = _baseRepository.Delete(entityId);
                if(result > 0)
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
    }
}
