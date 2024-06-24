using System.Collections;
using TMPro;
using UnityEngine;

public class ShowTutorial : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text; 
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private float whaitTime = 2f;
    [SerializeField] private string textForShow;

    private void Start()
    {
        SetTextAlpha(0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _text.text = textForShow;
            StartCoroutine(FadeText());
        }
    }

    private IEnumerator FadeText()
    {
        yield return StartCoroutine(Fade(0f, 1f, fadeDuration));
        yield return new WaitForSeconds(whaitTime);
        yield return StartCoroutine(Fade(1f, 0f, fadeDuration));
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            SetTextAlpha(alpha);
            yield return null;
        }

        SetTextAlpha(endAlpha);
    }

    private void SetTextAlpha(float alpha)
    {
        if (_text != null)
        {
            Color color = _text.color;
            color.a = alpha;
            _text.color = color;
        }
    }
}
