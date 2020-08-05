namespace MarketList_Model
{
    public class CommandResult
    {
        public CommandResult(bool success)
        {
            IsSuccess = success;
        }
        public bool IsSuccess { get; }
    }
}