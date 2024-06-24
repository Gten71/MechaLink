using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowNameTaskInGame : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _names = new List<TextMeshProUGUI>(3);
    [SerializeField] private List<TextMeshProUGUI> _nowTask = new List<TextMeshProUGUI>(3);

    private ShowNameTaskInMenu _showNameTaskInMenu;
    private void Start(){
        _showNameTaskInMenu = FindObjectOfType<ShowNameTaskInMenu>();
    }
    private void Update(){
        for(int i = 0; i < _names.Count; i++){
            _names[i].text = _showNameTaskInMenu.Get3Name(i);
            _nowTask[i].text = _showNameTaskInMenu.Get3Tasks(i);
        }
    }
}
