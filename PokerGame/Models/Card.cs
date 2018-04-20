using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Configuration;

namespace PokerGame.Models
{
    public class Card
    {
        public int nRank, nSuit;
        public string ImagePath;
        public string ImageName;        
        string customSetting = "./cards/";

        public Card(int suit, int rank)
        {
            nRank = rank;
            nSuit = suit;
            ImageName = getImageName();
            ImagePath = getImagePath();
        }


        public string getImageName()
        {
            string name = string.Empty;

            if (nRank < 11)
            {
                name = nRank + "_of_" + Enum.GetName(typeof(Suit), nSuit) + ".png";
            }
            else
            {
                if (nRank == 14)
                    name = Enum.GetName(typeof(Rank), nRank) + "_of_" +
                      Enum.GetName(typeof(Suit), nSuit) + ".png";
                else
                    name = Enum.GetName(typeof(Rank), nRank) + "_of_" +
                      Enum.GetName(typeof(Suit), nSuit) + "2.png";
            }
            return name;
        }

        public string getImagePath()
        {
            return customSetting + ImageName;
        }
    }
}