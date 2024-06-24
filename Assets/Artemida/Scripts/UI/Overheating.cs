using System.Collections;
using UnityEngine;
using TMPro;

public class Overheating : MonoBehaviour
{
    public Transform[] charges;
    public int countCharges = 5;
    public int countCharge = 5;
    public PetsStats pet; // Ссылка на сущность пета
    public TextMeshProUGUI cooldownText; // Ссылка на TextMeshPro для индикации

    private void Start()
    {
        charges = new Transform[countCharges];
        for (int i = 0; i < charges.Length; i++)
        {
            charges[i] = transform.Find("charge" + (i + 1));
        }

        // Находим TextMeshPro компонент
        cooldownText = GetComponentInChildren<TextMeshProUGUI>();
        cooldownText.gameObject.SetActive(false);
    }

    public void AddCharge()
    {
        if (countCharge < countCharges && charges[countCharge] != null)
        {
            charges[countCharge].gameObject.SetActive(true);
            countCharge++;
            pet.RestoreOverheat(); // Восстанавливаем перегрев в пете
        }
    }

    public void UseCharge()
    {
        if (countCharge > 0 && charges[countCharge - 1] != null)
        {
            countCharge--;
            charges[countCharge].gameObject.SetActive(false);
            StartCoroutine(RestoreCharge());
        }
    }

    private IEnumerator RestoreCharge()
    {
        yield return new WaitForSeconds(4f);
        AddCharge();
    }

    public bool CanUseCharge()
    {
        return countCharge > 0;
    }

    public void ShowCooldownText(float cooldown)
    {
        StartCoroutine(CooldownRoutine(cooldown));
    }

    private IEnumerator CooldownRoutine(float cooldown)
    {
        cooldownText.gameObject.SetActive(true);
        float remainingTime = cooldown;

        while (remainingTime > 0)
        {
            cooldownText.text = remainingTime.ToString("F1");
            remainingTime -= Time.deltaTime;
            yield return null;
        }

        cooldownText.gameObject.SetActive(false);
    }
}
