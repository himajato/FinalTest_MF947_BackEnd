using MISA.FinalTest.MF947.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FinalTest.MF947.Core.Interfaces
{
    public interface IBaseService<MISAEntity> 
    {
        /// <summary>
        /// Thực hiện kiểm tra dữ liệu và thêm mới 
        /// </summary>
        /// <param name="entity">Thực thể</param>
        /// <returns>Kết quả xử lí nghiệp vụ</returns>
        ServiceResult Add(MISAEntity entity);

        /// <summary>
        /// Thực hiện kiểm tra dữ liệu và sửa thông tin dữ liệu
        /// </summary>
        /// <param name="entity">thông tin thực thể được sửa</param>
        /// <param name="entityId">Id của thực thể</param>
        /// <returns>Kết quả sử lí nghiệp vụ</returns>
        ServiceResult Update(MISAEntity entity, Guid entityId);
    }
}
