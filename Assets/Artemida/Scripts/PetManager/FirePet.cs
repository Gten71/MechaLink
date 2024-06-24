using System.Collections.Generic;
using UnityEngine;

public class FirePet : MonoBehaviour
{
     private string _name = "FirePet";
     private int _healthMax = 2;
     private int _overheatingMax = 2;
     private int _level = 0;
    [SerializeField] private bool _takePet = false;
    [SerializeField] private bool _openPet = false;
     private string _type = "Fire";
     private string _speed = "Medium";
     private int _soulsFire = 0;
     private int _soulsWater = 0;
     private int _soulsAir = 0;
     private int  _soulsGeneral = 0;
    [SerializeField] private PetsStats _petsStats;
    public PetsStats PetsStats => _petsStats;
     public string Name => _name;
    public int HealthMax => _healthMax;
    public int OverheatingMax => _overheatingMax;
    public int Level => _level;
    public bool TakePet => _takePet;
    public bool OpenPet => _openPet;
 
    public string Type => _type;
    public int SoulsFire => _soulsFire;
    public int SoulsWater => _soulsWater;
    public int SoulsAir => _soulsAir;
    public int SoulsGeneral => _soulsGeneral;
    public string Speed => _speed;
    private void Start(){
        _name = _petsStats.petName;
        _healthMax = _petsStats.maxHP;
        _overheatingMax = _petsStats.maxOverheat;
        _level = _petsStats.level;
        _type = _petsStats.element.ToString();
        _speed = _petsStats.speed.ToString();
    }
    private void Update(){
        if(_takePet){
            gameObject.SetActive(true);
        }else{
            gameObject.SetActive(false);
        }
    }

    public void Upgrade(){
        _level += 1;
        _petsStats.level = _level;
         switch(_level){
            case 1:
                //урон поднять
                break;
            case 2:
                _healthMax += 1;
                _petsStats.maxHP+=1;
                //урона поднять 
                break;
            case 3:
                _overheatingMax += 1;
                _petsStats.maxOverheat+=1;
                //урон подянть
                break;
            default:
            break;
        }
        _soulsFire+= 5;
        _soulsWater+= 1;
        _soulsAir+= 2;
        _soulsGeneral+= 10;
    }
 public void OpenPetGame(){
        _openPet = true;
    }
    public void TakePetGame(){
        _takePet = true;
    }
    public void UnTakePet(){
        _takePet = false;
    }
}
