using System;
using Inventory.Logic;
using Transition;
using UnityEngine;
using EventHandler = Utilities.EventHandler;

namespace Cursor
{
    public class CursorManager : MonoBehaviour
    {
        public RectTransform hand;
        
        private ItemName curItem;
        private bool holdItem;

        private void OnEnable()
        {
            EventHandler.ItemSelectedEvent += OnItemSelectedEvent;
        }

        private void OnDisable()
        {
            EventHandler.ItemSelectedEvent -= OnItemSelectedEvent;
        }

        private void Update()
        {
            if (hand.gameObject.activeInHierarchy)
                hand.position = Input.mousePosition;
            
            if (Input.GetMouseButtonDown(0))
            {
                var clickedCollider = CheckColliderAtMousePosition();
                if (clickedCollider) ClickAction(clickedCollider.gameObject);
            }
        }

        private void ClickAction(GameObject clickObject)
        {
            switch (clickObject.tag)
            {
                case "Teleport":
                    var teleport = clickObject.GetComponent<Teleport>();
                    teleport?.TeleportToScene();
                    break;
                case "Item":
                    var item = clickObject.GetComponent<Item>();
                    item?.ItemClicked();
                    break;
                case "Interactive":
                    var interactive = clickObject.GetComponent<Interactive.Interactive>();
                    if (holdItem) interactive?.CheckItem(curItem);
                    else interactive?.EmptyClicked();
                    break;
            }
        }

        private Collider2D CheckColliderAtMousePosition()
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            return Physics2D.OverlapPoint(mouseWorldPos);
        }

        private void OnItemSelectedEvent(ItemDetails itemDetails, bool isSelected)
        {
            holdItem = isSelected;
            hand.gameObject.SetActive(isSelected);
            if (isSelected) curItem = itemDetails.itemName;
        }
    }
}
