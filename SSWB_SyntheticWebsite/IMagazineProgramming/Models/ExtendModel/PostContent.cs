using System;

namespace IMagazineProgramming.Models.ExtendModel
{
    public class PostContent
    {
        public int IdAccount { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int Viewed { get; set; }
        public string DatePost { get; set; }
        public string TimePost { get; set; }
        public string Summary { get; set; }
        public string ContentView { get; set; }
        public string Name { get; set; }
        public int IdSCategory { get; set; }
        public string NameSCategory { get; set; }
        public int IdXCategory { get; set; }
        public string NameXCategory { get; set; }
    }

    /// <summary>
    /// Custom DataPost
    /// </summary>
    public class PostCustom
    {
        public int Id { get; set; }
        public int IdAccount { get; set; }
        public int IdSCategory { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Summary { get; set; }
        public string ContentView { get; set; }
        public Nullable<System.DateTime> DatePost { get; set; }
        public Nullable<bool> Active { get; set; }
        public int Viewed { get; set; }
    }
}