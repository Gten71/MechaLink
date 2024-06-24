using System.Collections;
using UnityEngine;
using TMPro;

public class EnemyHealthUI : MonoBehaviour
{
    public Transform[] hearts; // ������ ��� �������� ������ �� ������� ��������
    public int countHearts = 5;
    public int currentHeart;
    public float hideDelay = 2f; // �������� ����� �������� UI ����� ����������� �����

    private EnemyCharacter enemy; // ������ �� ������ �����
    private Coroutine hideCoroutine; // �������� ��� ������� UI

    public TextMeshProUGUI petNameText; // ������ �� TextMeshPro ��� ����������� ����� ����

    private void Start()
    {
        hearts = new Transform[countHearts];
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.Find("heart" + (i + 1));
        }

        SetHeartsActive(false);

        // ������� ������ ����� �� �����
        enemy = GetComponentInParent<EnemyCharacter>();
        if (enemy != null)
        {
            enemy.OnTakeDamage += ShowHealthUI; // ������������� �� ������� ��������� �����
            UpdatePetName();
        }
    }

    // ����� ��� ����������� UI ��������
    private void ShowHealthUI()
    {
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }

        SetHeartsActive(true);
        UpdateHealthUI();
        UpdatePetName();

        // ��������� �������� ��� ������� UI ������ ��������� �����
        hideCoroutine = StartCoroutine(HideHealthUIAfterDelay());
    }

    // ����� ��� ���������� UI ��������
    private void UpdateHealthUI()
    {
        int healthPerHeart = enemy.maxHP / countHearts;
        currentHeart = Mathf.CeilToInt((float)enemy.currentHP / healthPerHeart);

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(i < currentHeart);
        }
    }

    // ����� ��� ���������� ����� ����
    private void UpdatePetName()
    {
        if (petNameText != null && enemy != null)
        {
            petNameText.text = enemy.petName;
        }
    }

    // �������� ��� ������� UI ������ ��������
    private IEnumerator HideHealthUIAfterDelay()
    {
        yield return new WaitForSeconds(hideDelay);
        SetHeartsActive(false);
    }

    // ����� ��� ��������� ��������� ��������� �������� � ����� ����
    private void SetHeartsActive(bool isActive)
    {
        foreach (var heart in hearts)
        {
            heart.gameObject.SetActive(isActive);
        }

        // ������������� ��������� ��� TextMeshPro
        if (petNameText != null)
        {
            petNameText.gameObject.SetActive(isActive);
        }
    }
}
