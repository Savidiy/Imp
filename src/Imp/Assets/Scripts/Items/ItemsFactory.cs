namespace Imp
{
    internal class ItemsFactory
    {
        public Item Create(EItemId itemId)
        {
            return new Item(itemId, null);
        }
    }
}