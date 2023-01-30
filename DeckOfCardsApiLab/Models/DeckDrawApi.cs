namespace DeckOfCardsApiLab.Models
{
    public class DeckDrawApi
    {
        public bool success { get; set; }
        public string deck_id { get; set; }
        public List<DeckCardsApi> cards { get; set; }
        public int remaining { get; set; }
    }
}
