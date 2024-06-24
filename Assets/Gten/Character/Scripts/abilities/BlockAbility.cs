using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/BlockAbility")]
public class BlockAbility : Ability
{
    public float blockDuration = 0.5f; // ������������ �����
    public KeyCode blockKey = KeyCode.Alpha3; // ������� ��� �����

    public override void Execute(EnemyCharacter enemy, PetsStats pet)
    {
        pet.StartCoroutine(BlockCoroutine(pet));
    }

    private IEnumerator BlockCoroutine(PetsStats pet)
    {
        // ��������� �����
        Debug.Log("Blocking...");

        // ������ �����
        pet.isBlocking = true;
        pet.ShowBlockDuration(blockDuration);

        yield return new WaitForSeconds(blockDuration);

        // ����� �����
        pet.isBlocking = false;
        Debug.Log("Block ended.");
        pet.HideBlockDuration();
    }
}
