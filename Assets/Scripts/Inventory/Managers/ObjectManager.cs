using System;
using System.Collections.Generic;
using Inventory.Logic;
using UnityEngine;
using EventHandler = Utilities.EventHandler;

namespace Inventory.Managers
{
    public class ObjectManager : MonoBehaviour
    {
        private Dictionary<ItemName, bool> itemavailableDict = new Dictionary<ItemName, bool>();
        
        private void OnEnable()
        {
            EventHandler.UpdateUIEvent += OnUpdateUIEvent;
            EventHandler.AfterSceneUnloadEvent += OnAfterSceneUnloadEvent;
            EventHandler.BeforeSceneUnloadEvent += OnBeforeSceneUnloadEvent;
        }

        private void OnDisable()
        {
            EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
            EventHandler.AfterSceneUnloadEvent -= OnAfterSceneUnloadEvent;
            EventHandler.BeforeSceneUnloadEvent -= OnBeforeSceneUnloadEvent;
        }

        private void OnUpdateUIEvent(ItemDetails itemDetails, int _)
        {
            if (itemDetails != null)
            {
                itemavailableDict[itemDetails.itemName] = false;
            }   
        }

        private void OnBeforeSceneUnloadEvent()
        {
            foreach (var item in FindObjectsOfType<Item>())
            {
                if (!itemavailableDict.ContainsKey(item.itemName))
                    itemavailableDict.Add(item.itemName, true);
            }
        }

        private void OnAfterSceneUnloadEvent()
        {
            foreach (var item in FindObjectsOfType<Item>())
            {
                if (!itemavailableDict.ContainsKey(item.itemName))
                    itemavailableDict.Add(item.itemName, true);
                else
                    item.gameObject.SetActive(itemavailableDict[item.itemName]);
            }
        }
    }
}
