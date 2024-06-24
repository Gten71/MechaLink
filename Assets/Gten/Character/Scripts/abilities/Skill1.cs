using UnityEngine;

[CreateAssetMenu(fileName = "Skill1", menuName = "Abilities/Skill1")]
public class Skill1 : Ability
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
