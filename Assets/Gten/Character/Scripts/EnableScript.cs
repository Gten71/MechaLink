using UnityEngine;

public class EnableScript : MonoBehaviour
{
    private PetsMovement petsMovementScript;
    private FollowPlayer followPlayerScript;
    private GameObject playerSkinObject;
    private bool isObjectActive = true;

    void Start()
    {
        petsMovementScript = GetComponent<PetsMovement>();
        followPlayerScript = GetComponent<FollowPlayer>();
        playerSkinObject = GameObject.FindGameObjectWithTag("PlayerSkin");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (petsMovementScript != null)
            {
                petsMovementScript.enabled = !petsMovementScript.enabled;

                Debug.Log("PlayerMovement script " + (petsMovementScript.enabled ? "enabled" : "disabled"));
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (followPlayerScript != null)
            {
                followPlayerScript.enabled = !followPlayerScript.enabled;

                Debug.Log("PlayerMovement script " + (followPlayerScript.enabled ? "enabled" : "disabled"));
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            isObjectActive = !isObjectActive;

            playerSkinObject.SetActive(isObjectActive);
        }
    }
}
