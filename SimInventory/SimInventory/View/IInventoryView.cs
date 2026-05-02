using System.Collections.Generic;

namespace SimInventory
{
    public interface IInventoryView
    {
        void DisplayProducts(List<Product> products);
        void ShowSuccess(string message);
        void ShowError(string message);
        void ClearInputs();
    }
}
