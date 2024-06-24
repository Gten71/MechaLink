using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    public float interactionRadius = 2f; // Радиус взаимодействия с врагом
    public Overheating overheating; // Ссылка на систему чарджей
    public PetsStats pet; // Ссылка на сущность пета

    private EnemyCharacter enemyInRange;
    private Coroutine cooldownCoroutine;

    private void Update()
    {
        foreach (var ability in pet.abilities)
        {
            if (Input.GetKeyDown(ability.attackKey))
            {
                if (enemyInRange != null && cooldownCoroutine == null)
                {
                    if (overheating.CanUseCharge()) // Проверяем, есть ли доступные чарджи
                    {
                        if (pet.currentOverheat >= ability.overheatCost)
                        {
                            cooldownCoroutine = StartCoroutine(UseAbilityWithDelay(ability));
                        }
                        else
                        {
                            Debug.Log("Not enough overheat to use this ability.");
                        }
                    }
                    else
                    {
                        Debug.Log("No charges available to use the skill.");
                    }
                }
            }

            // Проверка блока
            if (ability is BlockAbility && Input.GetKeyDown(((BlockAbility)ability).blockKey))
            {
                if (overheating.CanUseCharge())
                {
                    if (pet.currentOverheat >= ability.overheatCost)
                    {
                        ability.Execute(enemyInRange, pet);
                        overheating.UseCharge();
                        pet.currentOverheat -= ability.overheatCost;
                    }
                    else
                    {
                        Debug.Log("Not enough overheat to use this block.");
                    }
                }
                else
                {
                    Debug.Log("No charges available to use the block.");
                }
            }
        }
    }

    private IEnumerator UseAbilityWithDelay(Ability ability)
    {
        overheating.ShowCooldownText(ability.cooldown);

        yield return new WaitForSeconds(ability.cooldown);

        if (enemyInRange != null)
        {
            ability.Execute(enemyInRange, pet);
            overheating.UseCharge(); // Используем чардж
            pet.currentOverheat -= ability.overheatCost;
        }

        cooldownCoroutine = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, является ли объект врагом и находится ли он в радиусе
        if (other.CompareTag("MobDefault") && Vector3.Distance(transform.position, other.transform.position) <= interactionRadius)
        {
            enemyInRange = other.GetComponent<EnemyCharacter>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Проверяем, уходит ли объект врага из радиуса
        if (other.CompareTag("MobDefault"))
        {
            enemyInRange = null;
        }
    }
}
