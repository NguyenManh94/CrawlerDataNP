using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSWA_TestExtractData.Entity
{
    class EPatternRule
    {
        public string MenuCate { get; set; }
        /*Size Mak = unlimited*/
        public List<string> LstMenuRemove { get; set; }

        public string UrlImage { get; set; }
        /*Size Mak = 4*/
        public List<string> LstUrlXpath { get; set; }

        public string Title { get; set; }
        /*Size Mak = 4*/
        public List<string> LstTitleXpath { get; set; }

        public string Summary { get; set; }
        /*Size Mak = 4*/
        public List<string> LstSummaryXpath { get; set; }

        public string ContentPost { get; set; }
        /*Size Mak = 4*/
        public List<string> LstContentXpath { get; set; }
    }
}
