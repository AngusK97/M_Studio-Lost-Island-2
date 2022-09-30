using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utilities;

namespace Inventory.UI
{
    public class SlotUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        public Image itemImg;
        public ItemTooltip tooltip;
        
        private ItemDetails currentItem;
        private bool isSelected;

        public void SetItem(ItemDetails itemDetails)
        {
            currentItem = itemDetails;
            gameObject.SetActive(true);
            itemImg.sprite = itemDetails.itemIcon;
            itemImg.SetNativeSize();
        }

        public void SetEmpty()
        {
            gameObject.SetActive(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (gameObject.activeInHierarchy)
            {
                tooltip.gameObject.SetActive(true);
                tooltip.UpdateItemName(currentItem.itemName);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            tooltip.gameObject.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            isSelected = !isSelected;
            EventHandler.CallItemSelectedEvent(currentItem, isSelected);
        }

        public void OnPointerUp(PointerEventData eventData) { }

        public void OnPointerDown(PointerEventData eventData) { }
    }
}
