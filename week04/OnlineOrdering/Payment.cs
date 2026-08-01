public abstract class Payment
{
    private string _transactionId;
    private bool _wasSuccessful;

    protected Payment(string transactionId)
    {
        _transactionId = transactionId;
        _wasSuccessful = false;
    }

    public string TransactionId => _transactionId;
    public bool WasSuccessful => _wasSuccessful;

    public abstract bool Process(decimal amount);

    protected void SetStatus(bool success)
    {
        _wasSuccessful = success;
    }
}
