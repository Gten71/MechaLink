using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITutorial : MonoBehaviour
{
    [SerializeField] private Canvas[] _pages;
    private int _pageIndex = 0;
    public void CloseTutorial(){
        _pages[_pageIndex].enabled = false;
        _pageIndex = 0;
    }

    public void NexytPage(){
        _pages[_pageIndex].enabled = false;
        _pageIndex++;
        _pages[_pageIndex].enabled = true;
    }
    public void BackPage(){
        _pages[_pageIndex].enabled = false;
        _pageIndex--;
        _pages[_pageIndex].enabled = true;
    }
}
