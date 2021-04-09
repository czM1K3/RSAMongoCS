namespace Mongo
{
    public class EncryptedItem
    {
        public EncryptedItem(string text, string privateKey, string alias)
        {
            Text = text;
            PrivateKey = privateKey;
            Alias = alias;
        }
        public string Text { get; }
        public string PrivateKey { get; }
        public string Alias { get; }
    }
}