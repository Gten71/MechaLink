using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryWindow;
    public Transform slotsParent;
    public GameObject slotPrefab;

    private List<Item> items = new List<Item>();

    public static InventoryUI instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        inventoryWindow.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryWindow.SetActive(!inventoryWindow.activeSelf);
            Camera.main.GetComponent<CinemachineBrain>().enabled = !Camera.main.GetComponent<CinemachineBrain>().enabled;
        }
    }

    public void AddItem(string itemName, Sprite itemIcon, bool isStackable, int itemAmount)
    {
        Item existingItem = items.Find(item => item.name == itemName && item.stackable);


        if (existingItem != null)
        {
            existingItem.stackCount++;
            existingItem.amount += itemAmount;
        }
        else
        {
            Item newItem = new Item(itemName, itemIcon, isStackable, itemAmount);
            items.Add(newItem);
        }

        UpdateInventoryUI();
    }
    private void UpdateInventoryUI()
    {
        // �������� ��� ����� � ���������
        foreach (Transform child in slotsParent)
        {
            Destroy(child.gameObject);
        }

        // ��������� ����� ������������� ����������
        foreach (Item item in items)
        {
            GameObject slot = Instantiate(slotPrefab, slotsParent);
            slot.GetComponent<Image>().sprite = item.icon;

            TextMeshProUGUI stackText = slot.GetComponentInChildren<TextMeshProUGUI>();

            if (item.stackable)
            {
                stackText.text = item.stackCount.ToString();
            }

            slot.name = item.name;

            TextMeshProUGUI amountText = slot.GetComponentInChildren<TextMeshProUGUI>();

            if (item.amount > 1)
            {
                amountText.text = item.amount.ToString();
            }

        }
    }


    private void CreateSlot(string itemName, int itemAmount)
    {
        GameObject slot = Instantiate(slotPrefab, slotsParent);
        slot.GetComponent<Image>().sprite = GetItemIconByName(itemName);

        // ����� Text(TMP) ������ ����� � �������� ��� �����
        TextMeshProUGUI textMeshPro = slot.GetComponentInChildren<TextMeshProUGUI>();
        if (textMeshPro != null)
        {
            textMeshPro.text = itemAmount.ToString();
        }
        // ����� �� ������ �������� �������������� ������ ��� ����������� ���������� ��������� � �.�.
    }

    private void UpdateSlot(string itemName, int itemAmount)
    {
        // ����� ������������ ���� � ���������
        Transform existingSlot = slotsParent.Find(itemName);

        if (existingSlot != null)
        {
            // ����� Text(TMP) ������ ����� � �������� ��� �����
            TextMeshProUGUI textMeshPro = existingSlot.GetComponentInChildren<TextMeshProUGUI>();
            if (textMeshPro != null)
            {
                textMeshPro.text = itemAmount.ToString();
            }
        }
    }

    private Sprite GetItemIconByName(string itemName)
    {
        // ����� ��� ����� ����������� ������ ��������� Sprite �� ����� ��������
        // ��������, � ��� ���� ��������� ������ ��������� ��� ������ ������ �������� ������
        // ������ �������� ���� ��� �� ��� ����� ��������� Sprite
        return null;
    }
}
