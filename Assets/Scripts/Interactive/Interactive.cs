using UnityEngine;

namespace Interactive
{
    public class Interactive : MonoBehaviour
    {
        public ItemName requireItem;
        public bool isDone;

        public void CheckItem(ItemName itemName)
        {
            if (itemName == requireItem && isDone)
            {
                isDone = true;
            }
        }

        // call when click with right item
        protected virtual void OnClickedAction() { }

        public void EmptyClicked()
        {
            Debug.Log("empty click");
        }
    }
}
