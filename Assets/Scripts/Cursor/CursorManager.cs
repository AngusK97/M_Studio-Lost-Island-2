using Inventory.Logic;
using Transition;
using UnityEngine;

namespace Cursor
{
    public class CursorManager : MonoBehaviour
    {
        private void Update()
        {
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
            }
        }

        private Collider2D CheckColliderAtMousePosition()
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            return Physics2D.OverlapPoint(mouseWorldPos);
        }
    }
}
