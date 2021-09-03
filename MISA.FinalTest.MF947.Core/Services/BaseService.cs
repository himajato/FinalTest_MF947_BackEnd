using MISA.FinalTest.MF947.Core.Attributes;
using MISA.FinalTest.MF947.Core.Entities;
using MISA.FinalTest.MF947.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FinalTest.MF947.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        protected ServiceResult _serviceResult;
        IBaseRepository<MISAEntity> _baseRepository;
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
        }
        public ServiceResult Add(MISAEntity entity)
        {
            var className = typeof(MISAEntity).Name;
            var classNameCode = $"{className}Code";
            //Validate chung các trường bắt buộc của thực thể
            _serviceResult.IsValid = ValidateEntity(entity);
            //Validate riêng đối với các thực thể 
            if ((_serviceResult.IsValid == true) && (CustomValidate(entity) == false))
            {
                _serviceResult.IsValid = false;
            }

            //Validate trùng mã 
            if (_serviceResult.IsValid)
            {
                var code = typeof(MISAEntity).GetProperty(classNameCode).GetValue(entity);
                _serviceResult.IsValid = _baseRepository.CheckPropDuplicate((string)code, $"{className}Code");
                _serviceResult.Data = new
                {
                    devMsg = Properties.Resources.MISABadrequest_400_CodeDuplicate,
                    userMsg = Properties.Resources.MISABadrequest_400_CodeDuplicate,
                    errCode = Properties.Resources.MISAErroCode,
                    moreInfo = Properties.Resources.MISAErroMoreInfor
                };
            }
            //Thực hiện thêm mới sau khi validate
            if (_serviceResult.IsValid == true)
            {
                //Thực hiện thêm mới
                _serviceResult.Data = _baseRepository.Add(entity);
            }
            return _serviceResult;
        }

        public ServiceResult Update(MISAEntity entity, Guid entityId)
        {
            _serviceResult.IsValid = true;
            //Validate chung các trường bắt buộc của thực thể

            //Validate riêng đối với các thực thể   

            //Thực hiện thêm mới sau khi validate
            if(_serviceResult.IsValid)
            {
                _serviceResult.RowEffect = _baseRepository.Update(entity, entityId);
            }
            return _serviceResult;
        }

        /// <summary>
        /// Validate dữ liệu chung 
        /// </summary>
        /// <typeparam name="MISAEntity">Kiểu của thực thể</typeparam>
        /// <param name="entity">thực thể</param>
        /// <returns>kết quả validate (true - đúng định dạng ; false - sai định dạng)</returns>
        public bool ValidateEntity(MISAEntity entity)
        {
            var isValid = true;
            //Lấy ra các properties của thực thể
            var properties = typeof(MISAEntity).GetProperties();

            //Lấy giá trị của các properties
            foreach (var prop in properties)
            {
                var propName = prop.Name;
                var propValue = prop.GetValue(entity);

                var misaRequires = prop.GetCustomAttributes(typeof(MISARequire), true);
                if (misaRequires.Length > 0)
                {
                    var fieldName = ((MISARequire)misaRequires[0])._fieldName;
                    if ((prop.PropertyType == typeof(string)) && (propValue.ToString() == string.Empty))
                    {
                        isValid = false;
                        _serviceResult.Data = new
                        {
                            devMsg = $"{Properties.Resources.MISARequireFieldEmpty}" + " : " + $"{fieldName}",
                            userMsg = $"{Properties.Resources.MISARequireFieldEmpty}" + " : " + $"{fieldName}",
                            errorCode = Properties.Resources.MISAErroCode,
                            moreInfo = Properties.Resources.MISAErroMoreInfor
                        };
                        return false;
                    }
                }
            }
            return isValid;
        }

        /// <summary>
        /// Hàm validate dữ liệu riêng của mỗi thực thể,sẽ được override
        /// </summary>
        /// <param name="entity">Thực thể muốn validate dữ liệu</param>
        /// <returns>True: Đã được validate; False: Chưa đúng định dạng</returns>
        public virtual bool CustomValidate(MISAEntity entity)
        {
            return true;
        }
    }
}
