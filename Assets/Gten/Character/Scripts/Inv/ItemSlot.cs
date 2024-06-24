using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public bool IsEmpty()
    {
        return transform.childCount == 0;
    }
}
