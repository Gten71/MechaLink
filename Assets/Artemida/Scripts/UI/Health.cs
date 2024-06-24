using UnityEngine;

public class Health : MonoBehaviour
{
    public Transform[] hearts;
    public int countHearts = 5;
    public PetsStats pet; // Ссылка на объект питомца

    private void Start()
    {
        hearts = new Transform[countHearts];
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.Find("heart" + (i + 1));
        }
        UpdateHearts();
    }

    private void Update()
    {
        // Проверка, существует ли объект пета
        if (pet == null)
        {
            HideAllHearts();
        }
        else
        {
            UpdateHearts();
        }
    }

    private void UpdateHearts()
    {
        if (pet != null)
        {
            int activeHearts = pet.currentHP / 20;
            for (int i = 0; i < hearts.Length; i++)
            {
                if (hearts[i] != null)
                {
                    hearts[i].gameObject.SetActive(i < activeHearts);
                }
            }
        }
    }

    private void HideAllHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (hearts[i] != null)
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }

    public void PlusHealth(int amount)
    {
        if (pet != null)
        {
            pet.currentHP += amount;
            if (pet.currentHP > pet.maxHP)
            {
                pet.currentHP = pet.maxHP;
            }
            UpdateHearts();
        }
    }

    public void MinusHealth(int amount)
    {
        if (pet != null)
        {
            pet.currentHP -= amount;
            if (pet.currentHP < 0)
            {
                pet.currentHP = 0;
            }
            UpdateHearts();
        }
    }
}
