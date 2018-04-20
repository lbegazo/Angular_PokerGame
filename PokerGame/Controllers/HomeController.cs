using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PokerGame.Controllers.Resources;
using PokerGame.Models;

namespace PokerGame.Controllers
{
    public class HomeController : Controller
    {
        public string SessionIdentify
        {
            get { return "GameModelo"; }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }


        [HttpGet("/api/shuffleCards")]
        public IEnumerable<CardResource> shuffleCards()
        {
            return CardsInHand();
        }

        [HttpGet("/api/cards")]
        public IEnumerable<CardResource> CardsInHand()
        {
            Game game = new Game();
            return mapCards(game.CardsInHand);
        }

        private IEnumerable<CardResource> mapCards(IEnumerable<Card> cards)
        {
            List<CardResource> list = new List<CardResource>(); ;
            CardResource cardResource = null;
            foreach (var item in cards)
            {
                cardResource = new CardResource();
                cardResource.ImageName = item.ImageName;
                cardResource.ImagePath = item.ImagePath;
                cardResource.nRank = item.nRank;
                cardResource.nSuit = item.nSuit;
                list.Add(cardResource);
            }
            return list;
        }       
    }
}
