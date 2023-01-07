using System;

namespace Imp
{
    internal sealed class InventoryPresenter : IDisposable
    {
        private readonly ImpInventory _impInventory;
        private readonly InventoryView _inventoryView;

        public InventoryPresenter(ImpInventory impInventory, InventoryView inventoryView)
        {
            _inventoryView = inventoryView;
            _impInventory = impInventory;
            impInventory.InventoryUpdated += OnInventoryUpdated;
            OnInventoryUpdated();
        }

        private void OnInventoryUpdated()
        {
            _inventoryView.UpdateItems(_impInventory.Items, _impInventory.Size);
        }

        public void Dispose()
        {
            _impInventory.InventoryUpdated -= OnInventoryUpdated;
        }
    }
}