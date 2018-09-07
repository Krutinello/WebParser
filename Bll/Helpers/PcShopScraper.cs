using Bll.Chain;
using Bll.DTO;
using Bll.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace Bll.Helpers
{
    public class PcShopScraper : Interfaces.IScraper
    {      
        public List<ProductDTO> Scrap(string url)
        {
            HtmlWeb webDoc = new HtmlWeb();
            HtmlDocument doc = webDoc.Load(url);

            var allNodes = doc.DocumentNode.SelectNodes("//a[contains(@class,'product-thumb')]");

            List<ProductDTO> comps = new List<ProductDTO>();

            foreach (var mainNode in allNodes)
            {
                HtmlNode titleNode = mainNode.SelectSingleNode("*[contains(@class,'product-thumb__inner')]/*[contains(@class,'product-thumb__info')]/*[contains(@class,'product-thumb__name')]");
                HtmlNode descNode = mainNode.SelectSingleNode("*[contains(@class,'product-thumb__inner')]/*[contains(@class,'product-thumb__description')]");
                HtmlNode imgNode = mainNode.SelectSingleNode("*[contains(@class,'product-thumb__inner')]/*[contains(@class,'product-thumb__image-wrapper')]/img");
                HtmlNode priceNode = mainNode.SelectSingleNode("*[contains(@class,'product-thumb__inner')]/*[contains(@class,'product-thumb__prices')]/*[contains(@class,'product-thumb__price')]");

                ProductDTO comp = new ProductDTO();
                //comp.Link = titleNode.Attributes["href"].Value;
                comp.Name = titleNode.InnerText;
                comp.ImagePath = imgNode.Attributes["src"].Value;
                comp.Description = descNode.InnerText;

                ProductPriceDTO price = new ProductPriceDTO()
                {
                    Date = DateTime.Now,
                    Price = priceNode.InnerText
                };
                comp.Prices.Add(price);
                comps.Add(comp);
            }
            return comps;
        }        
    }
}
