using IMagazineProgramming.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Linq.SqlClient;
using System.Web.Http;/*Use add ref Assemblie*/

namespace IMagazineProgramming.Controllers.ApiControllers
{
    public class PrImzController : Controller
    {
        /// <summary>
        /// Get All Post in Database
        /// </summary>
        /// <returns></returns>
        /// 
        public string GetPosts()
        {
            using (var db = new SyntheticWebsiteEntities())
            {
                var post = db.Posts.Select(a => new
                {
                    a.Id,
                    a.IdAccount,
                    a.IdSCategory,
                    a.Title,
                    a.Image,
                    a.Summary,
                    a.DatePost,
                    a.Active,
                    a.Viewed
                });
                return JsonConvert.SerializeObject(post);
            }
        }

        /// <summary>
        /// GetNewPost : 5 Post New condtion have Active
        /// </summary>
        /// <returns></returns>
        public string GetNewPosts()
        {
            //Top5 new Condition: New and Active
            using (var db = new SyntheticWebsiteEntities())
            {
                var newPost = (from ps in db.Posts
                               join ac in db.Accounts
                               on ps.IdAccount equals ac.Id
                               orderby ps.Id descending
                               where ps.Active == true
                               select new { ps.Id, IdAccount = ac.Id, ps.Image, ps.Title, ac.Name, ps.DatePost, ps.Active }).Take(5);
                //.TakeWhile((a, b) => a.Active.Equals(true) && b < 5);
                return JsonConvert.SerializeObject(newPost);
            }
        }

        /// <summary>
        /// GetTopPost- Condition: 5 Post have Trafict max
        /// </summary>
        /// <returns></returns>
        public string GetTopPost()
        {
            using (var db = new SyntheticWebsiteEntities())
            {
                var topPost = (from ps in db.Posts
                               join ac in db.Accounts
                               on ps.IdAccount equals ac.Id
                               orderby ps.Viewed descending
                               where ac.Active == true
                               select new { ps.Id, IdAccount = ac.Id, ps.Image, ps.Title, ac.Name, ps.DatePost, ps.Active }).Take(5);
                return JsonConvert.SerializeObject(topPost);
            }
        }

        /// <summary>
        /// Select FormBody then canot use querystring destop
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public string GetSearchPost([FromBody]string id)
        {
            using (var db = new SyntheticWebsiteEntities())
            {
                var data = db.Posts.Where(a => a.Active == true && a.Title.Contains(id)).Select(a => new { a.Id, a.Image, a.Title, a.Viewed, a.Account.Name, a.ContentView });
                return JsonConvert.SerializeObject(data);
            }
        }

        /// <summary>
        /// Select list information
        /// </summary>
        /// <returns></returns>
        public string GetInforDev()
        {
            using (var db = new SyntheticWebsiteEntities())
            {
                var d = db.Accounts.Select(a => a).Count();
                var cateSum = db.SCategories.Select(a => a).Count();
                var postSum = db.Posts.Select(a => a).Count();
                var memberSum = db.Accounts.Select(a => a).Count();
                var memberNew = db.Accounts.Select(a => a.Name).ToList()[d - 1];
                var viewSum = db.Posts.Select(a => a.Viewed).Sum();
                var datainfor = new
                {
                    CateSum = cateSum,
                    PostSum = postSum,
                    MemberSum = memberSum,
                    MemberNew = memberNew,
                    ViewSum = viewSum
                };
                return JsonConvert.SerializeObject(datainfor);
            }
        }

        /// <summary>
        /// Select Top3 member
        /// condition: Active = true
        /// </summary>
        /// <returns></returns>
        public string GetTopMember()
        {
            using (var db = new SyntheticWebsiteEntities())
            {
                var topMember = db.Posts.Where(a => a.Active == true)
                    .GroupBy(ps => new { ps.IdAccount, ps.Account.Name, ps.Account.Active,ps.Account.Image })
                    .Where(z => z.Key.Active == true)
                                        .Select(g => new
                                        {
                                            IdAccount = g.Key.IdAccount,
                                            Name = g.Key.Name,
                                            Active=g.Key.Active,
                                            Image=g.Key.Image,
                                            SumViewed = g.Sum(x => x.Viewed)
                                        }).Take(3).OrderByDescending(x => x.SumViewed);
                return JsonConvert.SerializeObject(topMember);
            }
        }
    }
}