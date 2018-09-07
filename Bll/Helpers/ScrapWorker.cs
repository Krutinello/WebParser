using Bll.DTO;
using Bll.Interfaces;
using System;
using System.Collections.Generic;

namespace Bll.Helpers
{
    public class ScrapWorker
    {
        private Dictionary<string, Func<IScraper>> Scrapers;

        public ScrapWorker()
        {
            Scrapers = new Dictionary<string, Func<IScraper>>();
            Scrapers.Add("https://pcshop.ua/noutbuki-i-aksessuari/noutbuki", new Func<IScraper>(() => { return new PcShopScraper(); }));
        }
        public List<ProductDTO> Scrap(string url)
        {
            return Scrapers[url]().Scrap(url);
            //return Scrapers[url].BeginInvoke(url, null,null).Scrap(url);
        }
    }
}
