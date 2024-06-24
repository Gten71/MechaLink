using System.Collections;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    // Характеристики врага
    public string petName;
    public int maxHP = 100;
    public int currentHP;
    public int maxStamina = 50;
    public int currentStamina;
    public int baseDamage = 10;
    public float attackRange = 5f; // Дистанция атаки
    public float minDistance = 2f; // Минимальная дистанция до игрока
    public float strafeSpeed = 3f; // Скорость стрейфа
    public float retreatSpeed = 3f; // Скорость отступления
    public float blockChance = 0.75f; // Шанс блокировать атаку игрока
    public int overheatCost = 10; // Стоимость перегрева для блока

    // Стихии врага
    public enum ElementalType
    {
        Fire,
        Water,
        Wind
    }

    public ElementalType[] elemental;

    // Ссылка на питомца
    private PetsStats pet;

    private bool isBlocking = false;
    private Coroutine abilityCoroutine;
    private Vector3 strafeDirection; // Направление стрейфа
    private float strafeChangeInterval = 2f; // Интервал изменения направления стрейфа
    private float lastStrafeChangeTime; // Время последнего изменения направления стрейфа
    private float nextAbilityCooldown = 2f; // Следующее время перезарядки 

    private Renderer enemyRenderer; // Рендерер врага
    private Color originalColor; // Оригинальный цвет материала

    // Событие, вызываемое при получении урона
    public delegate void TakeDamageEventHandler();
    public event TakeDamageEventHandler OnTakeDamage;

    private void Start()
    {
        currentHP = maxHP;
        currentStamina = maxStamina;
        abilityCoroutine = StartCoroutine(UseAbilitiesPeriodically());
        lastStrafeChangeTime = Time.time;
        ChangeStrafeDirection();
        FindPet();

        enemyRenderer = GetComponent<Renderer>(); // Получаем рендерер
        if (enemyRenderer != null)
        {
            originalColor = enemyRenderer.material.color; // Сохраняем оригинальный цвет материала
        }
    }

    private void Update()
    {
        if (pet != null)
        {
            float distanceToPet = Vector3.Distance(transform.position, pet.transform.position);
            if (distanceToPet < minDistance)
            {
                // Отступаем от игрока
                Vector3 retreatDirection = (transform.position - pet.transform.position).normalized;
                transform.position += retreatDirection * retreatSpeed * Time.deltaTime;
            }
            else
            {
                // Изменяем направление стрейфа через определенные интервалы времени
                if (Time.time - lastStrafeChangeTime > strafeChangeInterval)
                {
                    ChangeStrafeDirection();
                    lastStrafeChangeTime = Time.time;
                }
                // Стрейфим влево и вправо
                transform.position += strafeDirection * strafeSpeed * Time.deltaTime;
            }
        }
    }

    // Метод для изменения направления стрейфа
    private void ChangeStrafeDirection()
    {
        if (pet != null)
        {
            strafeDirection = Vector3.Cross(Vector3.up, (pet.transform.position - transform.position).normalized);
            if (Random.value > 0.5f)
            {
                strafeDirection = -strafeDirection; // Меняем направление на противоположное
            }
        }
    }

    // Метод для поиска питомца по тегу
    private void FindPet()
    {
        GameObject[] pets = GameObject.FindGameObjectsWithTag("Pets");
        if (pets.Length > 0)
        {
            pet = pets[0].GetComponent<PetsStats>();
            if (pet == null)
            {
                Debug.LogWarning("Found object with 'Pets' tag, but it does not have a PetsStats component.");
            }
        }
        else
        {
            Debug.LogWarning("No objects with 'Pets' tag found in the scene.");
        }
    }

    // Метод для получения дамага
    public void TakeDamage(int damage)
    {
        if (isBlocking)
        {
            Debug.Log($"{petName} blocked the damage!");
            return;
        }

        currentHP -= damage;

        // Вызываем событие получения урона
        OnTakeDamage?.Invoke();

        if (enemyRenderer != null)
        {
            StartCoroutine(FlashRed());
        }

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private IEnumerator FlashRed()
    {
        enemyRenderer.material.color = Color.red; // Меняем цвет на красный
        Debug.Log("Change color enemy by 0.3s");
        yield return new WaitForSeconds(0.3f); // Ждем 0.5 секунды
        enemyRenderer.material.color = originalColor; // Возвращаем оригинальный цвет
    }

    // Метод для атаки
    public void AttackPlayer()
    {
        // Проверка на наличие стамины ну это наверно для скилов надо будет но лан
        if (currentStamina >= baseDamage)
        {
            //Добавить гг метод TakeDamage для принятия дамага
            // вообще можно добавить стихийный урон но хз

            Debug.Log("Enemy attacks player with base damage: " + baseDamage);
        }
        else
        {
            Debug.Log("Enemy is out of stamina!");
        }
    }

    // Метод смерти
    private void Die()
    {
        Debug.Log($"{petName} enemy has been defeated!");
        AddSoulsBeforeDeath();
        Destroy(gameObject);
    }

    private void AddSoulsBeforeDeath()
    {
        int fireSouls = 0;
        int waterSouls = 0;
        int airSouls = 0;

        // Распределяем души в зависимости от стихии
        foreach (ElementalType type in elemental)
        {
            switch (type)
            {
                case ElementalType.Fire:
                    fireSouls += 5;
                    break;
                case ElementalType.Water:
                    waterSouls += 5;
                    break;
                case ElementalType.Wind:
                    airSouls += 5;
                    break;
            }
        }
        int generalSouls = fireSouls + waterSouls + airSouls;

        SoulsManager.AddSouls(fireSouls, waterSouls, airSouls, generalSouls);
        Debug.Log($"Added souls: Fire - {fireSouls}, Water - {waterSouls}, Air - {airSouls}, General - {generalSouls}");
    }

    // Корутина для использования способностей с определенной периодичностью
    private IEnumerator UseAbilitiesPeriodically()
    {
        while (true)
        {
            yield return new WaitForSeconds(nextAbilityCooldown);

            if (pet != null)
            {
                float distanceToPet = Vector3.Distance(transform.position, pet.transform.position);
                if (distanceToPet <= attackRange)
                {
                    // Проверяем шанс на блокировку
                    if (ShouldBlock())
                    {
                        StartCoroutine(BlockAndAttackCoroutine());
                    }
                    else
                    {
                        // Атака питомца или использование способности
                        pet.TakeDamage(baseDamage);
                        Debug.Log("Enemy attacks pet with base damage: " + baseDamage);
                    }
                }
            }

            // Устанавливаем следующий интервал перезарядки на 2 или 5 секунд
            nextAbilityCooldown = nextAbilityCooldown == 2f ? 5f : 2f;
        }
    }

    // Метод для проверки шанса блокировки
    private bool ShouldBlock()
    {
        return Random.value < blockChance;
    }

    // Корутина для блока и атаки одновременно
    private IEnumerator BlockAndAttackCoroutine()
    {
        Debug.Log("Enemy is blocking and attacking...");

        isBlocking = true;
        pet.TakeDamage(baseDamage);
        Debug.Log("Enemy attacks pet with base damage while blocking: " + baseDamage);

        yield return new WaitForSeconds(0.5f); // Длительность блока
        isBlocking = false;

        Debug.Log("Enemy block ended.");

        currentStamina -= overheatCost;
        if (currentStamina < 0)
        {
            currentStamina = 0;
        }
    }
}
