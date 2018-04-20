using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerGame.Controllers.Resources
{
    public class CardResource
    {
        public int nRank { get; set; }

        public int nSuit { get; set; }

        public string ImagePath { get; set; }

        public string ImageName { get; set; }

        string customSetting = "~/Content/cards/";

        public CardResource()
        {
        }


        
    }
}
