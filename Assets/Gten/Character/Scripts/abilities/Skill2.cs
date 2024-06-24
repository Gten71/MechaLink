using UnityEngine;

[CreateAssetMenu(fileName = "Skill2", menuName = "Abilities/Skill2")]
public class Skill2 : Ability
{
    public override void Execute(EnemyCharacter enemy, PetsStats pet)
    {
        // Пример выполнения абилки
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Debug.Log($"{pet.petName} used {abilityName}, dealing {damage} skill damage to {enemy.name}.");
        }
    }
}