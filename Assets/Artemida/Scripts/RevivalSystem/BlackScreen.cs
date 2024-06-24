using System.Collections;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class BlackScreen
{
    
    private Canvas _canvas;
    private Image _img;
    public float fadeSpeed = 0.01f;
    private bool blackCheker = false; 
    public bool BlackChekcer
    {
        get { return blackCheker; }
        set { blackCheker = value; }
    }

    public IEnumerator DimScreen()
    {
        _canvas =  GameObject.Find("CanvasGameOver")?.GetComponent<Canvas>();
        _img = _canvas.GetComponentInChildren<Image>();
        Time.timeScale = 0;
        while (_img.color.a < 1f)
        {
            Color newColor = _img.color;
            newColor.a += fadeSpeed * Time.unscaledDeltaTime;
            _img.color = newColor;
            yield return null;
        }
        blackCheker = true;
    }

    public IEnumerator UnDimScreen()
    {
        Time.timeScale = 1;
        _canvas =  GameObject.Find("CanvasGameOver")?.GetComponent<Canvas>();
        _img = _canvas.GetComponentInChildren<Image>();
        while (_img.color.a > 0f)
        {
            Color newColor = _img.color;
            newColor.a -= fadeSpeed * Time.unscaledDeltaTime;
            _img.color = newColor;
            yield return null;
        }
        blackCheker = false;
        
    }
}
