using System;
using UnityEngine;
using UnityEngine.UI;
using EventHandler = Utilities.EventHandler;

namespace Inventory.UI
{
    public class InventoryUI : MonoBehaviour
    {
        public Button leftBtn;
        public Button rightBtn;
        public SlotUI slotUI;
        public int currentIndex;

        private void OnEnable()
        {
            EventHandler.UpdateUIEvent += OnUpdateUIEvent;
        }

        private void OnDisable()
        {
            EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
        }

        private void OnUpdateUIEvent(ItemDetails itemDetails, int index)
        {
            if (itemDetails == null)
            {
                slotUI.SetEmpty();
                currentIndex = -1;
                leftBtn.interactable = false;
                rightBtn.interactable = false;
            }
            else
            {
                currentIndex = index;
                slotUI.SetItem(itemDetails);
            }
        }
    }
}
