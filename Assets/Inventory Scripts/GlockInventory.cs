using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GlockInventory : MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get { return "glock"; }
    }
   

    public Sprite Image => image;

    public GunData GunData
    {
        get { return gunData; }
        set { gunData = value; }
    }

    public Sprite image = null;
    public GunData gunData; // Public reference to GunData ScriptableObject
    
  
  
  public void OnPickup()
  {
    gameObject.SetActive(false); // Deactivate after notifying inventory

  }

    
}