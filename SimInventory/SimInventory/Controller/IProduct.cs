namespace SimInventory
{
    public interface IProduct
    {
        int Id { get; }
        string Name { get; }
        decimal Price { get; }
        int Stock { get; }
        void Update(string name, decimal price, int stock);
    }
}