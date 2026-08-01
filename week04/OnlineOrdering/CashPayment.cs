public class CashPayment : Payment
{
    public CashPayment(string transactionId) : base(transactionId)
    {
    }

    public override bool Process(decimal amount)
    {
        SetStatus(amount >= 0);
        return WasSuccessful;
    }
}
