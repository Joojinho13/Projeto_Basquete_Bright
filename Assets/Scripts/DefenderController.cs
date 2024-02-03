using System.Collections;
using Photon.Pun;
using UnityEngine;

public class DefenderController : MonoBehaviour
{
    public float jumpForce = 5f;
    public float jumpCooldown = 1f;
    private bool canJump = true;

    private PhotonView view;
    void Update()
    {
        if (view.IsMine)
        {
            
         if (Input.GetMouseButtonDown(1) && canJump)
            {   
              StartCoroutine(Jump());
             }
        }
    }

    IEnumerator Jump()
    {
        canJump = false;
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }
}