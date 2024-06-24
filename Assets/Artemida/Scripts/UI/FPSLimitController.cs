using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class FPSLimitController : MonoBehaviour
{
    private TMP_InputField fpsInputField; 

    private void Start(){
        fpsInputField = GetComponent<TMP_InputField>();
    }


    public void OnFPSInputValueChanged()
    {
        if (int.TryParse(fpsInputField.text, out int fpsLimit))
        {
            Application.targetFrameRate = Mathf.Max(1, fpsLimit);
        }
        else
        {
            Debug.LogError("Invalid FPS limit entered!");
        }
    }
}
