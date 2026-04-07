namespace Kamaradas.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string? Code {  get; set; }

        public string? CPF { get; set; }
        public string? Password { get; set; }
        public string? Username { get; set; }

        public int LicenceID { get; set; }

        public int Score { get; set; }
        public int ScoreToWithdraw { get; set; }

        public string? Dad_1 { get; set; }
        public string? Dad_2 { get; set; }
        public string? Dad_3 { get; set; }
        public string? Dad_4 { get; set; }
        public string? Dad_5 { get; set; }
        public string? Dad_6 { get; set; }
        public string? Dad_7 { get; set; }
    }
}
