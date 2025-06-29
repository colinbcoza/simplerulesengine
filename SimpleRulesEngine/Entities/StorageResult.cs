namespace SimpleRulesEngine.Entities
{
    public class StorageResult<TId>
    {
        public TId Id { get; set; } = default(TId);
        public bool Success { get; set; } = false;
        public string Detail { get; set; } = string.Empty;
    }
}