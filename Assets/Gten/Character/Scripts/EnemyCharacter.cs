using System.Collections;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    // �������������� �����
    public string petName;
    public int maxHP = 100;
    public int currentHP;
    public int maxStamina = 50;
    public int currentStamina;
    public int baseDamage = 10;
    public float attackRange = 5f; // ��������� �����
    public float minDistance = 2f; // ����������� ��������� �� ������
    public float strafeSpeed = 3f; // �������� �������
    public float retreatSpeed = 3f; // �������� �����������
    public float blockChance = 0.75f; // ���� ����������� ����� ������
    public int overheatCost = 10; // ��������� ��������� ��� �����

    // ������ �����
    public enum ElementalType
    {
        Fire,
        Water,
        Wind
    }

    public ElementalType[] elemental;

    // ������ �� �������
    private PetsStats pet;

    private bool isBlocking = false;
    private Coroutine abilityCoroutine;
    private Vector3 strafeDirection; // ����������� �������
    private float strafeChangeInterval = 2f; // �������� ��������� ����������� �������
    private float lastStrafeChangeTime; // ����� ���������� ��������� ����������� �������
    private float nextAbilityCooldown = 2f; // ��������� ����� ����������� 

    private Renderer enemyRenderer; // �������� �����
    private Color originalColor; // ������������ ���� ���������

    // �������, ���������� ��� ��������� �����
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

        enemyRenderer = GetComponent<Renderer>(); // �������� ��������
        if (enemyRenderer != null)
        {
            originalColor = enemyRenderer.material.color; // ��������� ������������ ���� ���������
        }
    }

    private void Update()
    {
        if (pet != null)
        {
            float distanceToPet = Vector3.Distance(transform.position, pet.transform.position);
            if (distanceToPet < minDistance)
            {
                // ��������� �� ������
                Vector3 retreatDirection = (transform.position - pet.transform.position).normalized;
                transform.position += retreatDirection * retreatSpeed * Time.deltaTime;
            }
            else
            {
                // �������� ����������� ������� ����� ������������ ��������� �������
                if (Time.time - lastStrafeChangeTime > strafeChangeInterval)
                {
                    ChangeStrafeDirection();
                    lastStrafeChangeTime = Time.time;
                }
                // �������� ����� � ������
                transform.position += strafeDirection * strafeSpeed * Time.deltaTime;
            }
        }
    }

    // ����� ��� ��������� ����������� �������
    private void ChangeStrafeDirection()
    {
        if (pet != null)
        {
            strafeDirection = Vector3.Cross(Vector3.up, (pet.transform.position - transform.position).normalized);
            if (Random.value > 0.5f)
            {
                strafeDirection = -strafeDirection; // ������ ����������� �� ���������������
            }
        }
    }

    // ����� ��� ������ ������� �� ����
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

    // ����� ��� ��������� ������
    public void TakeDamage(int damage)
    {
        if (isBlocking)
        {
            Debug.Log($"{petName} blocked the damage!");
            return;
        }

        currentHP -= damage;

        // �������� ������� ��������� �����
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
        enemyRenderer.material.color = Color.red; // ������ ���� �� �������
        Debug.Log("Change color enemy by 0.3s");
        yield return new WaitForSeconds(0.3f); // ���� 0.5 �������
        enemyRenderer.material.color = originalColor; // ���������� ������������ ����
    }

    // ����� ��� �����
    public void AttackPlayer()
    {
        // �������� �� ������� ������� �� ��� ������� ��� ������ ���� ����� �� ���
        if (currentStamina >= baseDamage)
        {
            //�������� �� ����� TakeDamage ��� �������� ������
            // ������ ����� �������� ��������� ���� �� ��

            Debug.Log("Enemy attacks player with base damage: " + baseDamage);
        }
        else
        {
            Debug.Log("Enemy is out of stamina!");
        }
    }

    // ����� ������
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

        // ������������ ���� � ����������� �� ������
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

    // �������� ��� ������������� ������������ � ������������ ��������������
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
                    // ��������� ���� �� ����������
                    if (ShouldBlock())
                    {
                        StartCoroutine(BlockAndAttackCoroutine());
                    }
                    else
                    {
                        // ����� ������� ��� ������������� �����������
                        pet.TakeDamage(baseDamage);
                        Debug.Log("Enemy attacks pet with base damage: " + baseDamage);
                    }
                }
            }

            // ������������� ��������� �������� ����������� �� 2 ��� 5 ������
            nextAbilityCooldown = nextAbilityCooldown == 2f ? 5f : 2f;
        }
    }

    // ����� ��� �������� ����� ����������
    private bool ShouldBlock()
    {
        return Random.value < blockChance;
    }

    // �������� ��� ����� � ����� ������������
    private IEnumerator BlockAndAttackCoroutine()
    {
        Debug.Log("Enemy is blocking and attacking...");

        isBlocking = true;
        pet.TakeDamage(baseDamage);
        Debug.Log("Enemy attacks pet with base damage while blocking: " + baseDamage);

        yield return new WaitForSeconds(0.5f); // ������������ �����
        isBlocking = false;

        Debug.Log("Enemy block ended.");

        currentStamina -= overheatCost;
        if (currentStamina < 0)
        {
            currentStamina = 0;
        }
    }
}
