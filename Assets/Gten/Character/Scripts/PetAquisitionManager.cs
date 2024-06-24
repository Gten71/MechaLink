using UnityEngine;

public class PetManagerAquisition : MonoBehaviour
{
    private void Start()
    {
        // Загрузка состояния получения питомцев при старте
        LoadPetStates();
    }

    public void DefeatPet(string petName)
    {
        // Установка состояния получения питомца
        PlayerPrefs.SetInt(petName, 1);
        PlayerPrefs.Save();
    }

    public bool HasPet(string petName)
    {
        // Проверка состояния получения питомца
        return PlayerPrefs.GetInt(petName, 0) == 1;
    }

    private void LoadPetStates()
    {
        // Пример загрузки состояний (можно расширить под нужды игры)
        Debug.Log("Loading pet states...");
    }
}
