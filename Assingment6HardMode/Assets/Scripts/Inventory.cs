/*
 * Stefanos Charalampous
 * Inventory.cs
 * Assignment 6 - Hard Mode
 * Manages inventory items.
 */

using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryItem item;
    public List<InventoryItem> inventory;

    void Start()
    {
        item = new InventoryItem();
        inventory = new List<InventoryItem>();
    }
}