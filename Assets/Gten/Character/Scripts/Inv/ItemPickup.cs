using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    public Sprite itemIcon;
    public bool isStackable;
    public int itemAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryUI.instance.AddItem(itemName, itemIcon, isStackable, itemAmount);
            gameObject.name = itemName;
            Destroy(gameObject);
        }
    }
}
