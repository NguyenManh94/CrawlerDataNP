namespace SSWA_ExtractData.Entity
{
    /// <summary>
    ///     Create By: ManhNV1 -Date: 03/01/2016
    ///     Description: Feeds Entity
    /// </summary>
    internal class Feeds
    {
        /// <summary>
        ///     Id RssPage
        /// </summary>
        public int IdRssPage { get; set; }

        /// <summary>
        ///     Title RSS
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Link RSS
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        ///     PubDate RSS
        /// </summary>
        public string PubDate { get; set; }

        /// <summary>
        ///     Image RSS
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        ///     Description RSS
        /// </summary>
        public string Description { get; set; }
    }
}