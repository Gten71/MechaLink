using TMPro;
using UnityEngine;

public class CheckPointSystem : MonoBehaviour, IDataPersistence
{
     private TextMeshProUGUI text;
    private Canvas canvas;
    private bool enterCheker = false;
    private TestPlayer _test;
    [SerializeField] private string firstText = "Press E ";
    [SerializeField] private Transform spawnPoint;
    private GameObject player;
    private void Start()
    {
        canvas = gameObject.GetComponentInChildren<Canvas>();
        text = canvas.GetComponentInChildren<TextMeshProUGUI>();
        _test = FindObjectOfType<TestPlayer>();
        text.enabled = false;
    }
    private void Update(){
            CanvasRotation();
            if (Input.GetKeyDown(KeyCode.E)  && enterCheker && _test.LastCHP.position != gameObject.transform.position)
             {
            _test.LastCHP = spawnPoint;
             enterCheker = false;
            text.text = firstText;
            text.enabled = false;
            DataPersistenceManager.instance.SaveGame();
            }
            if(Input.GetKeyDown(KeyCode.Z)){
             GameObject playerObject = GameObject.FindWithTag("Player");
            playerObject.transform.position = _test.LastCHP.position;
            }
    }
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player") && _test.LastCHP.position != gameObject.transform.position){
            enterCheker = true;
            text.text = firstText;
            text.enabled = true;
            player = other.gameObject;
        }
    }
    private void CanvasRotation()
    {
        if (canvas.transform.rotation != Camera.main.transform.rotation)
        {
            canvas.transform.rotation = Camera.main.transform.rotation;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enterCheker = false;
            text.text = firstText;
            text.enabled = false;
            
        }
    }

    public void LoadData(GameData data)
    {
        player.transform.position = data.playerPosition;
    }

    public void SaveData(GameData data)
    {
        data.playerPosition = spawnPoint.position;
    }
}
