namespace TicketReservation.Models.AccountViewModels
{
    public class DepositMoneyViewModel
    {
        public decimal AmountToDeposit { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardVerificationCode { get; set; }
    }
}
