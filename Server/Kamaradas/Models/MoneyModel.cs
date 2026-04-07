namespace Kamaradas.Models
{
    public class MoneyModel
    {
        public int ID { get; set; }
        public string? OwnerCPF { get; set; }
        public int Score { get; set; }
        public int Type { get; set; } //0 - deposito, 1 - saque
        public string? RequestDate { get; set; }
        public string? FinishDate { get; set; }
        public bool Finished { get; set; }
    }
}