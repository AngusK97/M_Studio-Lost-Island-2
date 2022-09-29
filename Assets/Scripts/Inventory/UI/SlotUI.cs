using UnityEngine;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class SlotUI : MonoBehaviour
    {
        public Image itemImg;
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
    }
}
