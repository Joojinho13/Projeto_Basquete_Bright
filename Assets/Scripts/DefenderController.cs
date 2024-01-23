using System.Collections;
using UnityEngine;

public class DefenderController : MonoBehaviour
{
    public float jumpForce = 5f;
    public float jumpCooldown = 1f;
    private bool canJump = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canJump)
        {
            StartCoroutine(Jump());
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