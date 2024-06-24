using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/BlockAbility")]
public class BlockAbility : Ability
{
    public float blockDuration = 0.5f; // Длительность блока
    public KeyCode blockKey = KeyCode.Alpha3; // Клавиша для блока

    public override void Execute(EnemyCharacter enemy, PetsStats pet)
    {
        pet.StartCoroutine(BlockCoroutine(pet));
    }

    private IEnumerator BlockCoroutine(PetsStats pet)
    {
        // Индикация каста
        Debug.Log("Blocking...");

        // Начало блока
        pet.isBlocking = true;
        pet.ShowBlockDuration(blockDuration);

        yield return new WaitForSeconds(blockDuration);

        // Конец блока
        pet.isBlocking = false;
        Debug.Log("Block ended.");
        pet.HideBlockDuration();
    }
}
