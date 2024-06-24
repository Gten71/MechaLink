using UnityEngine;
using UnityEngine.UI;

public class ImageTransparency : MonoBehaviour
{
    private float changeSpeed = 0.5f; // Скорость изменения прозрачности
    private float minAlpha = 255f; // Минимальная прозрачность
    private float maxAlpha = 0f; // Максимальная прозрачность

    private Image imageComponent;
    private bool isFadingOut = false;
    private bool isFadingIn = false;

    void Start()
    {
        imageComponent = GetComponent<Image>();
    }

    void Update()
    {
        if (isFadingOut)
        {
            FadeOut();
        }
        else if (isFadingIn)
        {
            FadeIn();
        }
    }

    // Функция для плавного изменения прозрачности изображения в темную
    public void MakeDark()
    {
        isFadingOut = true;
        isFadingIn = false;
    }

    // Функция для плавного изменения прозрачности изображения в прозрачную
    public void MakeTransparent()
    {
        isFadingOut = false;
        isFadingIn = true;
    }

    // Плавное изменение прозрачности в темную
    private void FadeOut()
    {
        Color currentColor = imageComponent.color;
        float newAlpha = Mathf.MoveTowards(currentColor.a, minAlpha, changeSpeed * Time.deltaTime);
        imageComponent.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

        if (newAlpha == 255f)
        {
            isFadingOut = false;
        }
    }

    // Плавное изменение прозрачности в прозрачную
    private void FadeIn()
    {
        Color currentColor = imageComponent.color;
        float newAlpha = Mathf.MoveTowards(currentColor.a, maxAlpha, changeSpeed * Time.deltaTime);
        imageComponent.color = new Color(currentColor.r, currentColor.g, currentColor.b, newAlpha);

        if (newAlpha == 0f)
        {
            isFadingIn = false;
        }
    }
}
