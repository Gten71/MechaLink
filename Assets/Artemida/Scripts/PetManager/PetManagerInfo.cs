using System.Collections;
using Cinemachine;
using UnityEngine;

public class PetManagerInfo : MonoBehaviour
{
    [SerializeField] private Canvas startCanvas;
    [SerializeField] private Transform upgradeBtns;
    [SerializeField] private Camera Camera1;
    [SerializeField] private Camera Camera2;
    [SerializeField] private Transform Status;
    [SerializeField] private Transform Btns;
    public Transform UpgradeBtns => upgradeBtns;
    [SerializeField] private ScreenFader _blackScreen;
    [SerializeField] private Transform[] petsOnManagerSceen;
    private PetInfo petInfo;

     private bool isMainCanvasActive = true;
    private bool isProcessing = false;

    private void Start()
    {
        petInfo = GetComponent<PetInfo>();
        Camera1.depth = 1;
        Camera2.depth = 0;
    }
    private void Update(){
            if(petInfo.AirPet.GetComponent<AirPet>().OpenPet){
                petsOnManagerSceen[1].gameObject.SetActive(true);
        }
        else{
             petsOnManagerSceen[1].gameObject.SetActive(false);
        }
        if(petInfo.WaterPet.GetComponent<WaterPet>().OpenPet){
            petsOnManagerSceen[2].gameObject.SetActive(true);
        }else{
            petsOnManagerSceen[2].gameObject.SetActive(false);
        }
    }

    public void OpenPetManager(){
        if(!isProcessing){
            InventoryUI inventoryUI = FindObjectOfType<InventoryUI>();
            inventoryUI.inventoryWindow.SetActive(!inventoryUI.inventoryWindow.activeSelf);
            isProcessing = true;
            StartCoroutine(ToggleCanvasAndCamera());
        }
    }

    private IEnumerator ToggleCanvasAndCamera()
    {
        // Start fading out
        _blackScreen.FadeOut();
        yield return new WaitUntil(() => _blackScreen.isFaded);

        // Toggle the active canvas and camera
        if (isMainCanvasActive)
        {
            startCanvas.enabled = false;
            gameObject.GetComponent<Canvas>().enabled = true;
            Camera1.depth = 0;
            Camera2.depth = 1;
        }
        else
        {
            startCanvas.enabled = true;
            gameObject.GetComponent<Canvas>().enabled = false;
            Camera1.depth = 1;
            Camera2.depth = 0;
        }

        // Wait for a frame to ensure the canvas and camera change
        yield return null;

        // Fade in
        _blackScreen.FadeIn();
        yield return new WaitUntil(() => !_blackScreen.isFaded);

        // Reset processing flag and toggle the active canvas state
        isProcessing = false;
        isMainCanvasActive = !isMainCanvasActive;
    }
public void OpenUpgradePet(){
    Status.GetChild(0).gameObject.SetActive(false);
    Status.GetChild(1).gameObject.SetActive(true);
    Btns.GetChild(0).gameObject.SetActive(false);
    Btns.GetChild(1).gameObject.SetActive(true);
    upgradeBtns.gameObject.SetActive(false);
}
public void CloseUpgradePet(){
    Status.GetChild(0).gameObject.SetActive(true);
    Status.GetChild(1).gameObject.SetActive(false);
    Btns.GetChild(0).gameObject.SetActive(true);
    Btns.GetChild(1).gameObject.SetActive(false);
    upgradeBtns.gameObject.SetActive(true);
    }
}