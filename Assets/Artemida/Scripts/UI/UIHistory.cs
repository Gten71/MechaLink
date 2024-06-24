using System.Collections;
using TMPro;
using UnityEngine;

public class UIHistory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCanvas;
    [SerializeField] private string[] _history;
    private int _indexText = 0;
    private ImageTransparency _img;
    public bool _activ = true;
    private bool _transitioning = false;

    private void Start()
    {
        _textCanvas.text = _history[_indexText];
        StartCoroutine(StartTextTransition());
        _img = FindAnyObjectByType<ImageTransparency>().GetComponent<ImageTransparency>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_transitioning)
        {
            _indexText++;
            if (_indexText < _history.Length)
            {
                StartCoroutine(TextTransition());
            }
            else
            {
                _activ = false;
                _img.MakeTransparent();
                this.GetComponent<Canvas>().enabled = false;
            }
        }
    }

    IEnumerator StartTextTransition()
    {
        _textCanvas.text = _history[_indexText];
        yield return StartCoroutine(TextTransition());
    }

    IEnumerator TextTransition()
    {
        _transitioning = true;
        float duration = 0.5f; 
        float timer = 0f;
        Color startColor = _textCanvas.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while (timer < duration)
        {
            _textCanvas.color = Color.Lerp(startColor, endColor, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        _textCanvas.color = endColor;

        _textCanvas.text = _history[_indexText];

        timer = 0f;
        startColor = endColor;
        endColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        while (timer < duration)
        {
            _textCanvas.color = Color.Lerp(startColor, endColor, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        _textCanvas.color = endColor;

        _transitioning = false;
    }
}
