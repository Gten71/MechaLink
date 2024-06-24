using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoulsInfo : MonoBehaviour
{
    [SerializeField] private Transform allTexts;

    private void Update(){
            allTexts.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = SoulsManager.FireSouls.ToString();
            allTexts.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = SoulsManager.WaterSouls.ToString();
            allTexts.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = SoulsManager.GeneralSouls.ToString();
            allTexts.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>().text = SoulsManager.AirSouls.ToString();
    }
}
