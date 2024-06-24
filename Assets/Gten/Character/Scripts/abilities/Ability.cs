using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string abilityName;
    public PetsStats.ElementalType element;
    public int overheatCost;
    public int damage;
    public float cooldown;
    public string description;
    public KeyCode attackKey;


    public abstract void Execute(EnemyCharacter enemy, PetsStats pet);
}
