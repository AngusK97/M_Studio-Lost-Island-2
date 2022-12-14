using System.Collections.Generic;
using Tools;
using UnityEngine;
using EventHandler = Utilities.EventHandler;

namespace Inventory.Logic
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        public ItemDataList_SO itemData;
        
        [SerializeField] private List<ItemName> itemList = new List<ItemName>();
        
        public void AddItem(ItemName itemName)
        {
            if (!itemList.Contains(itemName))
            {
                itemList.Add(itemName);
                EventHandler.CallUpdateUIEvent(itemData.GetItemDetails(itemName), itemList.Count - 1);
            }
        }
    }
}
