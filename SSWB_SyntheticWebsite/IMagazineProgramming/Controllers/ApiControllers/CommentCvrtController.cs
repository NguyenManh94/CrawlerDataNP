using IMagazineProgramming.Models;
using IMagazineProgramming.Models.ExtendModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IMagazineProgramming.Controllers.ApiControllers
{
    public class CommentCvrtController : ApiController
    {
        private readonly SyntheticWebsiteEntities _db = new SyntheticWebsiteEntities();
        public IHttpActionResult GetComment(int id)
        {
            var comment = from cm in _db.Comments
                          join ac in _db.Accounts
                          on cm.IdAccount equals ac.Id
                          join ps in _db.Posts
                          on cm.IdPost equals ps.Id
                          where ps.Id == id
                          select new
                          {
                              IdAccount = ac.Id,
                              Name = ac.Name,
                              ac.Permission,
                              ac.Image,
                              ContentComment = cm.Content,
                              cm.TimeComent
                          };
            var lstCm = new List<CommentCvrt>();
            foreach (var cm in comment)
            {
                var permis = "";
                permis = cm.Permission.Equals(true) ? "Administrator" : "Member";
                lstCm.Add(new CommentCvrt
                {
                    IdAccount = cm.IdAccount,
                    Name = cm.Name,
                    Permission = permis,
                    Image = cm.Image,
                    ContentComment = cm.ContentComment,
                    TimeComment = cm.TimeComent.Value.ToShortTimeString(),
                    DateComment = cm.TimeComent.Value.ToShortDateString()
                });
            }
            if (lstCm.Count.Equals(0))
                return NotFound();
            return Ok(lstCm);
        }
    }
}
