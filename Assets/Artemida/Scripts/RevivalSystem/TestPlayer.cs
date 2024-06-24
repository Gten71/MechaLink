using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] private Transform lastCheckPoint;

    public Transform LastCHP
    {
        get { return lastCheckPoint; }
        set { lastCheckPoint = value; }
    }
}
