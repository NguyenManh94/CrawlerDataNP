using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMagazineProgramming.Models.ExtendModel
{
    public class Drama
    {
        public List<Cate> LstCate { get; set; }
    }

    public class Cate
    {
        public int CateId { get; set; }
        public string TitleCate { get; set; }
        public string UrlCate { get; set; }
        public List<Item> ItemInfor { get; set; }
    }

    public class Item
    {
        public string TitleItem { get; set; }
        public List<string> UrlImage { get; set; }
    }
}