using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.FinalTest.MF947.Core.Interfaces
{
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu bản ghi
        /// </summary>
        /// <returns>Mảng chứa tất cả các dữ liệu</returns>
        ///createdby: NHNGHIA(26/08/2021)
        List<MISAEntity> GetAll();

        /// <summary>
        /// Lấy dữ liệu thực thể theo Id 
        /// </summary>
        /// <param name="entittyId">Id của thực thể</param>
        /// <returns>Dữ liệu thực thể</returns>
        object GetById(Guid entittyId);

        /// <summary>
        /// Sửa thông tin một bản ghi theo Id
        /// </summary>
        /// <param name="entity">Thông tin đã sửa</param>
        /// <param name="entityId">Id của thực thể muốn sửa</param>
        /// <returns>Số hàng bị thay đổi</returns>
        /// createdby: NHNGHIA (26/08/2021)
        int Update(MISAEntity entity, Guid entityId);

        /// <summary>
        /// Thêm mới dữ liệu bản ghi
        /// </summary>
        /// <param name="entity">Thực thể</param>
        /// <returns>Số hàng được thêm vào</returns>
        int Add(MISAEntity entity);

        /// <summary>
        /// Xóa dữ liệu theo Id
        /// </summary>
        /// <param name="entityId">Id của thực thể</param>
        /// <returns>số hàng bị xóa</returns>
        int Delete(Guid entityId);
        /// <summary>
        /// Lấy toàn bộ giá trị của prop
        /// </summary>
        /// <param name="propName">Tên của prop muốn lấy giá trị</param>
        /// <returns>danh sách tất cả các giá trị của prop</returns>
        public List<string> GetAllPropValueByName(string propName);

        /// <summary>
        /// Check trùng value của prop đã tồn tại hay chưa
        /// </summary>
        /// <param name="propValue">giá trị muốn check</param>
        /// <param name="propName">tên của prop</param>
        /// <returns></returns>
        bool CheckPropDuplicate(string propValue, string propName);
    }
}
