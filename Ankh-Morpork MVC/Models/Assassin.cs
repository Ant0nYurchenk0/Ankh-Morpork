namespace Ankh_Morpork_MVC.Models
{
    public class Assassin : Character
    {
        public double? MaxReward { get; set; }
        public double? MinReward { get; set; }
        public bool? IsBusy { get; set; }
        public string OfferMessage { get; set; }
    }
}