using IMagazineProgramming.Models;
using IMagazineProgramming.Models.ExtendModel;
using Newtonsoft.Json;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace IMagazineProgramming.Controllers.ApiControllers
{
    public class PostContentController : ApiController
    {
        private SyntheticWebsiteEntities _db = new SyntheticWebsiteEntities();
        /// <summary>
        /// Get: Post Data Default
        /// Condition: Active = true
        /// </summary>
        /// <returns></returns>
        public IQueryable<PostCustom> GetPosts()
        {
            return _db.Posts.OrderByDescending(a => a.Id).Where(a => a.Active == true).Select(
                a => new PostCustom
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
                    Viewed =a.Viewed,
                }
            );
        }

        /// <summary>
        /// Get: Full ContentView has Post
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetPosts(int id)
        {
            var dataContent = (from ac in _db.Accounts
                               join cm in _db.Comments
                               on ac.Id equals cm.IdAccount
                               join ps in _db.Posts
                               on ac.Id equals ps.IdAccount
                               join sc in _db.SCategories
                               on ps.IdSCategory equals sc.Id
                               join xc in _db.XCategories
                               on sc.IdXCategory equals xc.Id
                               where ps.Id.Equals(id)
                               select new
                               {
                                   IdAccount = ac.Id,
                                   Title = ps.Title,
                                   Image = ps.Image,
                                   Viewed = ps.Viewed,
                                   DatePost = ps.DatePost,
                                   Summary = ps.Summary,
                                   ContentView = ps.ContentView,
                                   Name = ac.Name,
                                   IdSCategory = sc.Id,
                                   NameSCategory = sc.NameSCategory,
                                   IdXCategory = xc.Id,
                                   NameXCategory = xc.NameXCategory
                               }).ToList();
            /*Linq to Entity not suport ConvertToDateTime and ToString (fomat date) hix hix*/
            var postContent = new PostContent
            {
                IdAccount = dataContent[0].IdAccount,
                Title = dataContent[0].Title.Trim(),
                Image = dataContent[0].Image.Trim(),
                Viewed = dataContent[0].Viewed,
                DatePost = dataContent[0].DatePost.Value.ToShortDateString().Trim(),
                TimePost = dataContent[0].DatePost.Value.ToShortTimeString().Trim(),
                Summary = dataContent[0].Summary.Trim(),
                ContentView = dataContent[0].ContentView.Trim(),
                Name = dataContent[0].Name.Trim(),
                IdSCategory = dataContent[0].IdSCategory,
                NameSCategory = dataContent[0].NameSCategory.Trim(),
                IdXCategory = dataContent[0].IdXCategory,
                NameXCategory = dataContent[0].NameXCategory.Trim(),
            };
            /*Select All Comment Post*/
            if (postContent == null)
                return NotFound();//404
            return Ok(postContent);
        }
    }
}
