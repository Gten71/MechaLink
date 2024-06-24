using UnityEngine;

public class PetManagerAquisition : MonoBehaviour
{
    private void Start()
    {
        // �������� ��������� ��������� �������� ��� ������
        LoadPetStates();
    }

    public void DefeatPet(string petName)
    {
        // ��������� ��������� ��������� �������
        PlayerPrefs.SetInt(petName, 1);
        PlayerPrefs.Save();
    }

    public bool HasPet(string petName)
    {
        // �������� ��������� ��������� �������
        return PlayerPrefs.GetInt(petName, 0) == 1;
    }

    private void LoadPetStates()
    {
        // ������ �������� ��������� (����� ��������� ��� ����� ����)
        Debug.Log("Loading pet states...");
    }
}
