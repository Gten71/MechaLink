using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PetsStats : MonoBehaviour
{
    public string petName;
    public int level;
    public ElementalType element;
    public int maxHP = 100;
    public int currentHP;
    public int maxOverheat = 50;
    public int currentOverheat;
    public float speed;
    public List<Ability> abilities;
    public bool isBlocking = false;
    public TextMeshProUGUI blockDurationText; // TextMeshPro для индикации времени блока

    public enum ElementalType
    {
        Fire,
        Water,
        Wind
    }

    private void Start()
    {
        currentHP = maxHP;
        currentOverheat = maxOverheat;
        blockDurationText.gameObject.SetActive(false); // Скрываем текст в начале
    }

    public void TakeDamage(int damage)
    {
        if (isBlocking)
        {
            Debug.Log($"{petName} blocked the damage!");
            return;
        }

        currentHP -= damage;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    public void RestoreOverheat()
    {
        currentOverheat = Mathf.Min(currentOverheat + 10, maxOverheat);
    }

    private void Die()
    {
        Debug.Log($"{petName} has been defeated!");
        Destroy(gameObject);
    }

    // Метод для показа времени блока
    public void ShowBlockDuration(float duration)
    {
        StartCoroutine(BlockDurationRoutine(duration));
    }

    private IEnumerator BlockDurationRoutine(float duration)
    {
        blockDurationText.gameObject.SetActive(true);
        float remainingTime = duration;

        while (remainingTime > 0)
        {
            blockDurationText.text = $"Block duration: {remainingTime:F1}"; // Обновление текста
            remainingTime -= Time.deltaTime;
            yield return null;
        }

        blockDurationText.gameObject.SetActive(false);
    }

    public void HideBlockDuration()
    {
        blockDurationText.gameObject.SetActive(false);
    }
}
