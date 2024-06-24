using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Transform camera;
    private List<Transform> activePoints = new List<Transform>();
    [SerializeField] private Transform firstPointFire;
    [SerializeField] private Transform secondPointAir;
    [SerializeField] private Transform thirdPointWater;
    [SerializeField] private float transitionSpeed = 2.0f; // Скорость перехода
    [SerializeField]private int currentPoint = 1;
    public int CurrentPoint => currentPoint;
    private Coroutine transitionCoroutine;
    private PetInfo petInfo;

    private void Start()
    {
        petInfo = GetComponent<PetInfo>();
        UpdatePoints();
    }

    private void Update()
    {
        UpdatePoints();
    }

    private void UpdatePoints()
    {
        activePoints.Clear();

        // Only add points to activePoints if the corresponding pet is open
        if (petInfo.FirePet.GetComponent<FirePet>().OpenPet)
        {
            activePoints.Add(firstPointFire);
        }
        if (petInfo.WaterPet.GetComponent<WaterPet>().OpenPet)
        {
            activePoints.Add(secondPointAir);
        }
        if (petInfo.AirPet.GetComponent<AirPet>().OpenPet)
        {
            activePoints.Add(thirdPointWater);
        }
        if (activePoints.Count > 0 && currentPoint >= activePoints.Count)
        {
            currentPoint = 0; 
        }
    }

    public void NextPoint()
    {
        if (activePoints.Count == 0) return;

        int nextPoint = (currentPoint + 1) % activePoints.Count;
        StartTransition(nextPoint);
    }

    public void BackPoint()
    {
        if (activePoints.Count == 0) return;

        int nextPoint = (currentPoint - 1 + activePoints.Count) % activePoints.Count;
        StartTransition(nextPoint);
    }

    private void StartTransition(int nextPoint)
    {
        if (transitionCoroutine != null)
        {
            StopCoroutine(transitionCoroutine);
        }
        transitionCoroutine = StartCoroutine(TransitionToPoint(nextPoint));
    }

    private IEnumerator TransitionToPoint(int nextPoint)
    {
        Vector3 startPosition = camera.position;
        Vector3 endPosition = activePoints[nextPoint].position;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            camera.position = Vector3.Lerp(startPosition, endPosition, elapsedTime);
            elapsedTime += Time.deltaTime * transitionSpeed;
            yield return null;
        }

        camera.position = endPosition;
        currentPoint = nextPoint; 
        transitionCoroutine = null;
    }
}
