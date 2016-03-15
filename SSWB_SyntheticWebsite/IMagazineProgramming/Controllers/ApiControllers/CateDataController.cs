using IMagazineProgramming.Models;
using IMagazineProgramming.Models.ExtendModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMagazineProgramming.Controllers.ApiControllers
{
    public class CateDataController : Controller
    {
        /// <summary>
        /// GET: CateData
        /// </summary>
        /// <returns></returns>
        public string GetCate()
        {
            using (var db = new SyntheticWebsiteEntities())
            {
                var cateData = db.XCategories.Select(x => new
                {
                    IdXcate = x.Id,
                    x.NameXCategory,
                    lstScate = db.SCategories.Where(f => f.IdXCategory == x.Id)
                                 .Select(t => new
                                 {
                                     IdScate = t.Id,
                                     t.NameSCategory
                                 })
                });
                return JsonConvert.SerializeObject(cateData);
            }
        }

        /// <summary>
        /// Get Post is XCategories and SCategories ==> Show List Post drug Cate Choice
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// GetCateCdt/5
        public string GetCateCdt(int id)
        {
            using (var db = new SyntheticWebsiteEntities())
            {
                var cateData = db.Posts.OrderByDescending(a => a.Id).Where(a => a.Active == true && a.SCategory.Id == id)
                    .Select(a => new PostCustom
                    {
                        Id = a.Id,
                        IdAccount = a.IdAccount,
                        IdSCategory = a.IdSCategory,
                        Title = a.Title,
                        Image = a.Image,
                        Summary = a.Summary,
                        ContentView = a.ContentView,
                        Name = a.Account.Name,
                        DatePost = a.DatePost,
                        Active = a.Active,
                        Viewed = a.Viewed,
                    }
                );
                return JsonConvert.SerializeObject(cateData);
            }
        }
    }
}