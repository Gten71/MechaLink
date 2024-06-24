using TMPro;
using UnityEngine;

public class TalkNPC : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Canvas canvas;
    [SerializeField] private string firstText = "Press E ";
    [SerializeField] private string[] monologue = { "Камень", "Не камень", "Stone" };
    [SerializeField] private string repeatingText = "Water";
    private int countText = 0;
    private bool endMonologue = false; 
    private bool enterCheker = false;
    public bool quest = false;
    public bool takeQuest = false;
    public bool endQest = false;
    public bool finishQuest = false;

    private void Start()
    {
        canvas = gameObject.GetComponentInChildren<Canvas>();
        text = canvas.GetComponentInChildren<TextMeshProUGUI>();
        text.enabled = false;
    }
    public void SetMonologue(string[] monologue)
    {
        this.monologue = monologue;
        countText = 0;
    }

    private void Update()
    {
        if(quest && !takeQuest && !enterCheker){
             text.enabled = true;
             text.text = "!";
        }
        if(endQest && !enterCheker){
            text.enabled = true;
            text.text = "?";
        }
        CanvasRotation();
        if (Input.GetKeyDown(KeyCode.E) && enterCheker)
        {
            ChangeText();
           
        }
    }

    private void ChangeText()
    {
        if (endMonologue)
        {
            text.text = repeatingText;
        }
        
        if (countText < monologue.Length)
        {
            text.text = monologue[countText];
            countText++;
        }
        else if (countText == monologue.Length)
        {
            text.text = firstText;
            endMonologue = true;
            countText++;
        }

        
    }
    private void CanvasRotation()
    {
        if (canvas.transform.rotation != Camera.main.transform.rotation)
        {
            canvas.transform.rotation = Camera.main.transform.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enterCheker = true;
            text.text = firstText;
            text.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(countText <= monologue.Length){
                countText = 0;
            }
            if (endQest && countText >= monologue.Length){
                finishQuest = true;
            }
            if(quest && countText >= monologue.Length){
                takeQuest = true;
            }
            enterCheker = false;
            text.text = firstText;
            text.enabled = false;
            
        }
    }
    public void OffText(){
        text.enabled = false;
    }
}
