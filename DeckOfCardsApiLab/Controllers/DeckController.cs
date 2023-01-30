using Microsoft.AspNetCore.Mvc;
using DeckOfCardsApiLab.Models;
using Flurl.Http;

namespace DeckOfCardsApiLab.Controllers
{
    public class DeckController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Draw5(DeckDrawApi transfer)
        {
            string apiUri = $"https://deckofcardsapi.com/api/deck/{transfer.deck_id}/draw/?count=5";
            var apiTask = apiUri.GetJsonAsync<DeckDrawApi>();
            apiTask.Wait();
            DeckDrawApi draw = apiTask.Result;
            return View(draw);
        }
        public ActionResult GenerateDeck() 
        {
            string apiUri = "https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1";
            var apiTask = apiUri.GetJsonAsync<DeckApi>();
            apiTask.Wait();
            DeckApi result = apiTask.Result;
            DeckDrawApi transfer = new DeckDrawApi();
            transfer.deck_id = result.deck_id;
            return RedirectToAction("Draw5", transfer);
        }
        public ActionResult Reshuffle(DeckDrawApi transfer)
        {
            string apiUri = $"https://deckofcardsapi.com/api/deck/{transfer.deck_id}/shuffle/";
            var apiTask = apiUri.GetJsonAsync<DeckDrawApi>();
            apiTask.Wait();
            DeckDrawApi newDeck = apiTask.Result;
            return RedirectToAction("Draw5", newDeck);
        }
    }
}
