using UnityEngine;

namespace Inventory.Logic
{
    public class Item : MonoBehaviour
    {
        public ItemName itemName;

        public void ItemClicked()
        {
            InventoryManager.Instance.AddItem(itemName);
            gameObject.SetActive(false);
        }
    }
}
