using System.Collections;
using UnityEngine;
public class DeathCollision : MonoBehaviour
{
    private BlackScreen _blackScreen = new BlackScreen();
    [SerializeField] private Animator _animator;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(_blackScreen.DimScreen());
            _animator.SetBool("Death", true);
        }
        
    }

    private void Update()
    {
        if (_blackScreen.BlackChekcer)
        {
            GameObject playerObject = GameObject.FindWithTag("Player");
            TestPlayer _test = playerObject.GetComponent<TestPlayer>();
            _animator.SetBool("Death", false);
            playerObject.transform.position = _test.LastCHP.position;
            StartCoroutine(_blackScreen.UnDimScreen());
        }
    }
   
}
