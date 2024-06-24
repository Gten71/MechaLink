using System.Collections;
using UnityEngine;
using TMPro;

public class EnemyHealthUI : MonoBehaviour
{
    public Transform[] hearts; // Массив для хранения ссылок на объекты здоровья
    public int countHearts = 5;
    public int currentHeart;
    public float hideDelay = 2f; // Задержка перед скрытием UI после прекращения урона

    private EnemyCharacter enemy; // Ссылка на объект врага
    private Coroutine hideCoroutine; // Корутина для скрытия UI

    public TextMeshProUGUI petNameText; // Ссылка на TextMeshPro для отображения имени пета

    private void Start()
    {
        hearts = new Transform[countHearts];
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.Find("heart" + (i + 1));
        }

        SetHeartsActive(false);

        // Находим объект врага на сцене
        enemy = GetComponentInParent<EnemyCharacter>();
        if (enemy != null)
        {
            enemy.OnTakeDamage += ShowHealthUI; // Подписываемся на событие получения урона
            UpdatePetName();
        }
    }

    // Метод для отображения UI здоровья
    private void ShowHealthUI()
    {
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }

        SetHeartsActive(true);
        UpdateHealthUI();
        UpdatePetName();

        // Запускаем корутину для скрытия UI спустя некоторое время
        hideCoroutine = StartCoroutine(HideHealthUIAfterDelay());
    }

    // Метод для обновления UI здоровья
    private void UpdateHealthUI()
    {
        int healthPerHeart = enemy.maxHP / countHearts;
        currentHeart = Mathf.CeilToInt((float)enemy.currentHP / healthPerHeart);

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(i < currentHeart);
        }
    }

    // Метод для обновления имени пета
    private void UpdatePetName()
    {
        if (petNameText != null && enemy != null)
        {
            petNameText.text = enemy.petName;
        }
    }

    // Корутина для скрытия UI спустя задержку
    private IEnumerator HideHealthUIAfterDelay()
    {
        yield return new WaitForSeconds(hideDelay);
        SetHeartsActive(false);
    }

    // Метод для установки видимости элементов здоровья и имени пета
    private void SetHeartsActive(bool isActive)
    {
        foreach (var heart in hearts)
        {
            heart.gameObject.SetActive(isActive);
        }

        // Устанавливаем видимость для TextMeshPro
        if (petNameText != null)
        {
            petNameText.gameObject.SetActive(isActive);
        }
    }
}
