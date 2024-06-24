using TMPro;
using UnityEngine;

public class PetInfo : MonoBehaviour
{
    [SerializeField] private WaterPet _waterPet;
    [SerializeField] private FirePet _firePet;
    [SerializeField] private AirPet _airPet;

    [SerializeField] private Transform _startStats;
    [SerializeField] private Transform _upgradeStats;
    [SerializeField] private Transform[] _deletedItems;
    [SerializeField] private Transform _spels;
    public WaterPet WaterPet => _waterPet;
    public FirePet FirePet => _firePet;
    public AirPet AirPet => _airPet;
    private int _count = 0;
    [SerializeField] private Transform spawnPointPets;


    public void SetCount(int count)
    {
        _count = count;
    }
    private void Update() {
        ShowStats(_count);
        _count = gameObject.GetComponent<CameraRotation>().CurrentPoint;
    }

    private void ShowStats(int count){
       
            if(count == 1){
                
                _upgradeStats.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = _waterPet.GetComponent<WaterPet>().Name;
                _upgradeStats.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = _waterPet.GetComponent<WaterPet>().Level.ToString();
                if((_waterPet.GetComponent<WaterPet>().Level+1) == 3){
                    _upgradeStats.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "Max";
                }else{
                    _upgradeStats.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = (_waterPet.GetComponent<WaterPet>().Level+1).ToString();
                }
                _upgradeStats.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = _waterPet.GetComponent<WaterPet>().Type;
                _upgradeStats.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = _waterPet.GetComponent<WaterPet>().HealthMax.ToString();
                _upgradeStats.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>().text = _waterPet.GetComponent<WaterPet>().OverheatingMax.ToString();
                _upgradeStats.GetChild(8).gameObject.GetComponent<TextMeshProUGUI>().text = _waterPet.GetComponent<WaterPet>().Speed;
                _upgradeStats.GetChild(9).gameObject.GetComponent<TextMeshProUGUI>().text = _waterPet.GetComponent<WaterPet>().SoulsFire.ToString();
                _upgradeStats.GetChild(10).gameObject.GetComponent<TextMeshProUGUI>().text = _waterPet.GetComponent<WaterPet>().SoulsWater.ToString();
                _upgradeStats.GetChild(11).gameObject.GetComponent<TextMeshProUGUI>().text = _waterPet.GetComponent<WaterPet>().SoulsAir.ToString();
                _upgradeStats.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().text = _waterPet.GetComponent<WaterPet>().SoulsGeneral.ToString();
                 switch(_waterPet.GetComponent<WaterPet>().Level+1){
                    case 1:
                        _upgradeStats.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = (_waterPet.GetComponent<WaterPet>().HealthMax+1).ToString();
                        _upgradeStats.GetChild(7).gameObject.GetComponent<TextMeshProUGUI>().text = _waterPet.GetComponent<WaterPet>().OverheatingMax.ToString();
                    break;
                    case 2:
                        _upgradeStats.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = (_waterPet.GetComponent<WaterPet>().HealthMax+1).ToString();
                        _upgradeStats.GetChild(7).gameObject.GetComponent<TextMeshProUGUI>().text = _waterPet.GetComponent<WaterPet>().OverheatingMax.ToString();
                        //урона поднять 
                    break;
                    case 3:
                        _upgradeStats.GetChild(7).gameObject.GetComponent<TextMeshProUGUI>().text = (_waterPet.GetComponent<WaterPet>().OverheatingMax+1).ToString();
                        _upgradeStats.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = (_waterPet.GetComponent<WaterPet>().HealthMax+1).ToString();
                    break;
                    default:
                    break;
                    }
                if(_waterPet.GetComponent<WaterPet>().Level == 3){
                    DisableItems();
                }
                else{
                    EnableItems();
                }
                
        }else if (count == 0){
                _upgradeStats.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().Name;
                _upgradeStats.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().Level.ToString();
                if((_firePet.GetComponent<FirePet>().Level+1) == 3){
                    _upgradeStats.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "Max";
                }else{
                    _upgradeStats.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = (_firePet.GetComponent<FirePet>().Level+1).ToString();
                }
               _upgradeStats.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().Type;
                _upgradeStats.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().HealthMax.ToString();
                _upgradeStats.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().OverheatingMax.ToString();
                _upgradeStats.GetChild(8).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().Speed;
                _upgradeStats.GetChild(9).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().SoulsFire.ToString();
                _upgradeStats.GetChild(10).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().SoulsWater.ToString();
                _upgradeStats.GetChild(11).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().SoulsAir.ToString();
                _upgradeStats.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().SoulsGeneral.ToString();
                switch(_waterPet.GetComponent<WaterPet>().Level+1){
                    case 1:
                        _upgradeStats.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().HealthMax.ToString();
                        _upgradeStats.GetChild(7).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().OverheatingMax.ToString();
                        //урон поднять
                    break;
                    case 2:
                        _upgradeStats.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = (_firePet.GetComponent<FirePet>().HealthMax+1).ToString();
                        _upgradeStats.GetChild(7).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().OverheatingMax.ToString();
                        //урона поднять 
                    break;
                    case 3:
                        _upgradeStats.GetChild(7).gameObject.GetComponent<TextMeshProUGUI>().text = (_firePet.GetComponent<FirePet>().OverheatingMax+1).ToString();
                        _upgradeStats.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().HealthMax.ToString();
                        //урон поднять
                    break;
                    default:
                    break;
                    }

                if(_firePet.GetComponent<FirePet>().Level == 3){
                    DisableItems();
                }
                else{
                    EnableItems();
                }
        }else if(count == 2){
                _upgradeStats.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = _airPet.GetComponent<AirPet>().Name;
                _upgradeStats.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = _airPet.GetComponent<AirPet>().Level.ToString();
                 if((_airPet.GetComponent<AirPet>().Level+1) == 3){
                    _upgradeStats.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "Max";
                }else{
                    _upgradeStats.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = (_airPet.GetComponent<AirPet>().Level+1).ToString();
                }
                _upgradeStats.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text =_airPet.GetComponent<AirPet>().Type;
                _upgradeStats.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = _airPet.GetComponent<AirPet>().HealthMax.ToString();
                _upgradeStats.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>().text = _airPet.GetComponent<AirPet>().OverheatingMax.ToString();
                _upgradeStats.GetChild(8).gameObject.GetComponent<TextMeshProUGUI>().text = _airPet.GetComponent<AirPet>().Speed;
                _upgradeStats.GetChild(9).gameObject.GetComponent<TextMeshProUGUI>().text = _airPet.GetComponent<AirPet>().SoulsFire.ToString();
                _upgradeStats.GetChild(10).gameObject.GetComponent<TextMeshProUGUI>().text = _airPet.GetComponent<AirPet>().SoulsWater.ToString();
                _upgradeStats.GetChild(11).gameObject.GetComponent<TextMeshProUGUI>().text = _airPet.GetComponent<AirPet>().SoulsAir.ToString();
                _upgradeStats.GetChild(12).gameObject.GetComponent<TextMeshProUGUI>().text = _airPet.GetComponent<AirPet>().SoulsGeneral.ToString();
                 switch(_waterPet.GetComponent<WaterPet>().Level+1){
                    case 1:
                        _upgradeStats.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = _airPet.GetComponent<AirPet>().HealthMax.ToString();
                        _upgradeStats.GetChild(7).gameObject.GetComponent<TextMeshProUGUI>().text = (_airPet.GetComponent<AirPet>().OverheatingMax+1).ToString();
                    break;
                    case 2:
                        _upgradeStats.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = _airPet.GetComponent<AirPet>().HealthMax.ToString();
                        _upgradeStats.GetChild(7).gameObject.GetComponent<TextMeshProUGUI>().text = (_airPet.GetComponent<AirPet>().OverheatingMax+1).ToString();
                        //урона поднять 
                    break;
                    case 3:
                        _upgradeStats.GetChild(7).gameObject.GetComponent<TextMeshProUGUI>().text = (_airPet.GetComponent<AirPet>().OverheatingMax+1).ToString();
                        _upgradeStats.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = (_airPet.GetComponent<AirPet>().HealthMax+1).ToString();
                    break;
                    default:
                    break;
                    }
                if(_airPet.GetComponent<AirPet>().Level == 3){
                    DisableItems();
                }
                else{
                    EnableItems();
                }
        }
        
        if(count == 1){
                _startStats.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = _waterPet.GetComponent<WaterPet>().Name;
                _startStats.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = _waterPet.GetComponent<WaterPet>().Level.ToString();
                _startStats.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = _waterPet.GetComponent<WaterPet>().Type;
                _startStats.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = _waterPet.GetComponent<WaterPet>().HealthMax.ToString();
                _startStats.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = _waterPet.GetComponent<WaterPet>().OverheatingMax.ToString();
                _startStats.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = _waterPet.GetComponent<WaterPet>().Speed;
                if(_waterPet.GetComponent<WaterPet>().TakePet){
                    _startStats.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>().text = "Taken";
                } else{
                    _startStats.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>().text = "Not Taken";
                }
                
        }else if (count == 0){
                _startStats.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().Name;
                _startStats.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().Level.ToString();
                _startStats.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().Type;
                _startStats.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().HealthMax.ToString();
                _startStats.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().OverheatingMax.ToString();
                _startStats.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<FirePet>().Speed;
                if(_firePet.GetComponent<FirePet>().TakePet){
                    _startStats.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>().text = "Taken";
                } else{
                    _startStats.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>().text = "Not Taken";
                }
                // добавить всем петам спеллы
                _startStats.GetChild(7).gameObject.GetComponent<TextMeshProUGUI>().text = "10"; // тут надо будет общий урон выводить где то макс вроде добавит по словам андрея
                _spels.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<PetsStats>().abilities[0].abilityName;
                _spels.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<PetsStats>().abilities[0].description;
                _spels.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<PetsStats>().abilities[1].abilityName;
                _spels.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<PetsStats>().abilities[1].description;
                _spels.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<PetsStats>().abilities[2].abilityName;
                _spels.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = _firePet.GetComponent<PetsStats>().abilities[2].description;
        }else if(count == 2){
                _startStats.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = _airPet.GetComponent<AirPet>().Name;
                 _startStats.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = _airPet.GetComponent<AirPet>().Name;
                _startStats.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = _airPet.GetComponent<AirPet>().Name;
                _startStats.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = _airPet.GetComponent<AirPet>().Level.ToString();
                _startStats.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = _airPet.GetComponent<AirPet>().Type;
                _startStats.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = _airPet.GetComponent<AirPet>().HealthMax.ToString();
                _startStats.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>().text = _airPet.GetComponent<AirPet>().OverheatingMax.ToString();
                _startStats.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>().text = _airPet.GetComponent<AirPet>().Speed;
                if(_airPet.GetComponent<AirPet>().TakePet){
                    _startStats.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>().text = "Taken";
                } else{
                    _startStats.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>().text = "Not Taken";
                }
        
        }
    }
    public void UpgradePet(){
        if(_count == 1){
            _waterPet.GetComponent<WaterPet>().Upgrade();
        }else if(_count == 0){
            _firePet.GetComponent<FirePet>().Upgrade();
        }else if(_count == 2){
            _airPet.GetComponent<AirPet>().Upgrade();
        }
    }
    public void PickPet(){
        if(_count == 1){
            _waterPet.GetComponent<WaterPet>().TakePetGame();
            _waterPet.gameObject.SetActive(true);
            _airPet.GetComponent<AirPet>().UnTakePet();
            _airPet.gameObject.SetActive(false);
            _firePet.GetComponent<FirePet>().UnTakePet();
            _firePet.gameObject.SetActive(false);
            _waterPet.gameObject.transform.position = spawnPointPets.position;
        }else if(_count == 0){
            _firePet.GetComponent<FirePet>().TakePetGame();
            _firePet.gameObject.SetActive(true);
            _waterPet.GetComponent<WaterPet>().UnTakePet();
            _waterPet.gameObject.SetActive(false);
            _airPet.GetComponent<AirPet>().UnTakePet();
            _airPet.gameObject.SetActive(false);
            _firePet.gameObject.transform.position = spawnPointPets.position;
        }else if(_count == 2){
            _airPet.GetComponent<AirPet>().TakePetGame();
            _airPet.gameObject.SetActive(true);
            _firePet.GetComponent<FirePet>().UnTakePet();
            _firePet.gameObject.SetActive(false);
            _waterPet.GetComponent<WaterPet>().UnTakePet();
            _waterPet.gameObject.SetActive(false);
            _airPet.gameObject.transform.position = spawnPointPets.position;
        }
    }
    private void DisableItems(){
        for(int i = 0; i < _deletedItems.Length; i++){
            _deletedItems[i].gameObject.SetActive(false);
        }
    }
    private void EnableItems(){
        for(int i = 0; i < _deletedItems.Length; i++){
            _deletedItems[i].gameObject.SetActive(true);
        }
    }
}
