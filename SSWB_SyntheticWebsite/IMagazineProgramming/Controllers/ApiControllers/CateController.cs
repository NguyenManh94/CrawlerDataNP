using IMagazineProgramming.Models.ExtendModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace IMagazineProgramming.Controllers.ApiControllers
{
    public class CateController: ApiController
    {
        /*Lấy ra toàn bộ ảnh trong danh sách*/
        public IEnumerable<Cate> GetAll()
        {
            string s = File.ReadAllText(HttpContext.Current.Server.MapPath(@"~/App_Data/DramaImage.json"));
            var drama = JsonConvert.DeserializeObject<Drama>(s);
            var lstCate = drama.LstCate;
            return lstCate;
        }

        [ResponseType(typeof(Cate))]  /*Hiện tại cái này chưa cần cũng được*/
        public IHttpActionResult GetByTitleCase(string id)
        {
            #region MyRegion
            /*Demo tìm kiếm 1 tầng với dữ liệu trả về là 1 chuyên mục*/
            //var lstCate = GetAll();
            //var image = lstCate.FirstOrDefault(_ => _.TitleCate == id);
            //if (image != null)
            //    return Ok(image);   /*Result 200*/
            //return NotFound();      /*Lỗi 404*/
            #endregion
            /*Demo tìm kiếm 2 tầng với tầng thứ 2 là chi tiết ảnh*/
            var lstCate = GetAll().ToList();
            var lstBikini = lstCate.FirstOrDefault(_ => _.CateId == Convert.ToInt32(id));
            //var itemGirl = lstBikini.Find(_ => _.TitleItem == id);
            if (lstBikini != null)
                return Ok(lstBikini);
            return NotFound();

        }
    }
}
