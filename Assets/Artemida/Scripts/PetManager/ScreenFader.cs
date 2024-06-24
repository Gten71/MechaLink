using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    private Image image;
    public float fadeSpeed = 1.0f; 
    public bool isFaded = false; // Начальное значение isFaded

    private void Start()
    {
        image = gameObject.GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f); // Устанавливаем начальную прозрачность
    }

    public void FadeOut()
    {
        StartCoroutine(FadeImage(1.0f, true)); // FadeOut затемняет экран
    }

    public void FadeIn()
    {
        StartCoroutine(FadeImage(0.0f, false)); // FadeIn делает экран прозрачным
    }

    private IEnumerator FadeImage(float targetAlpha, bool fadeOut)
    {
        float currentAlpha = image.color.a;

        while (!Mathf.Approximately(currentAlpha, targetAlpha))
        {
            currentAlpha = Mathf.MoveTowards(currentAlpha, targetAlpha, fadeSpeed * Time.deltaTime);
            image.color = new Color(image.color.r, image.color.g, image.color.b, currentAlpha);
            yield return null;
        }

        isFaded = fadeOut;
    }
}
