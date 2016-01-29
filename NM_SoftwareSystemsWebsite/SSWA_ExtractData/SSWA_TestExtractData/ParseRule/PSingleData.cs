using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using HtmlAgilityPack;
using System.Diagnostics;
using System;

namespace SSWA_TestExtractData.ParseRule
{
    /// <summary>
    /// Single Parse Data
    /// Parse each unit web
    /// </summary>
    class PSingleData
    {
        /*Web Result Data*/
        public HtmlDocument ResultWeb(string url)
        {
            var hw = new HtmlWeb
            {
                UserAgent =
                "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36",
                OverrideEncoding = Encoding.UTF8
            };
            return hw.Load(url);
        }

        /*Rule Parse Menu data*/
        public List<HtmlNode> MenuParse(List<string> lstRemove, string url, string xpathOrSelector)
        {
            var menuHtml = ResultWeb(url);
            /*Delete Multiple Menu data invalid*/
            MtpDelete(lstRemove, menuHtml);
            /*Result web menu data*/
            if (xpathOrSelector.Contains("//"))
                return menuHtml.DocumentNode.SelectNodes(xpathOrSelector).ToList();
            return menuHtml.DocumentNode.QuerySelectorAll(xpathOrSelector).ToList();
        }

        /*Rule Multiple Delete Menu Data*/
        public void MtpDelete(List<string> lstRemove, HtmlDocument htmlDocument)
        {
            for (int i = 0; i < lstRemove.Count; i++)
            {
                var nodeRemove = htmlDocument.DocumentNode.SelectSingleNode(lstRemove[i].ToString());
                nodeRemove.ParentNode.RemoveChild(nodeRemove);
            }
        }

        /*Rule Parse Multipe Post Sumary Data
         *** Title- Post
         *** Link Image
         *** Summary content
         */
        public void PostSummaryMtp()
        {

        }

        /*Rule Parse Single Post Sumary Data
         *** Title- Post
         *** Link Image
         *** Summary content
         *allow 4 xpath for Null
         */
        public void ParsePostSummary(string urlMenu, List<string> lstXpath)
        {
            var listPost = ResultWeb(urlMenu);
            try
            {
                var htmlListPost = listPost.DocumentNode.SelectNodes(lstXpath[0])
                                    ?? listPost.DocumentNode.SelectNodes(lstXpath[1])
                                    ?? listPost.DocumentNode.SelectNodes(lstXpath[2])
                                    ?? listPost.DocumentNode.SelectNodes(lstXpath[3]);
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (IndexOutOfRangeException ex)
            {
                throw ex;
            }
        }



        /*Rule Parse Content Post Sumary Data
         *** Content Data
         */
        public string ContentPost(string urlPostSingle, string sourceWeb, string fontSize, List<string> lstXpath)
        {
            var sourceHtml = string
                .Format(@"<div><p style='font-style:italic;font-weight:bold;font-size:{0}px;'>Nguồn {1}</p></div>"
                , fontSize, sourceWeb);
            //Select Content Data
            var postSummary = ResultWeb(urlPostSingle);
            var sbdContent = new StringBuilder();
            try
            {
                var htmlContent = postSummary.DocumentNode.SelectSingleNode(lstXpath[0]) ??
                                            (postSummary.DocumentNode.SelectSingleNode(lstXpath[1]) ??
                                                (postSummary.DocumentNode.SelectSingleNode(lstXpath[2]) ??
                                                    postSummary.DocumentNode.SelectSingleNode(lstXpath[3])));
                sbdContent.Append(htmlContent).Append(sourceHtml);
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            catch (IndexOutOfRangeException ex)
            {
                throw ex;
            }
            return sbdContent.ToString();
        }
    }
}
