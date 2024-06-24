using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public Sprite icon;
    public bool stackable;
    public int stackCount;
    public int amount;

    public Item(string itemName, Sprite itemIcon, bool isStackable, int itemAmount)
    {
        name = itemName;
        icon = itemIcon;
        stackable = isStackable;
        stackCount = 1;
        amount = itemAmount;
    }
}
