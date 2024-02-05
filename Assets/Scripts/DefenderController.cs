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
        view = GetComponent<PhotonView>();
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

     public void TrocarPapel()
    {
        if (view.IsMine)
        {
            // Defensor torna-se Atacante
            view.RPC("RPC_TrocarPapel", RpcTarget.AllBuffered, "Attacker");
        }
    }

    [PunRPC]
    void RPC_TrocarPapel(string novoPapel)
    {
        if (view.IsMine)
        {
            // Desativa o script de Defensor
            GetComponent<DefenderController>().enabled = false;

            // Ativa o script de Atacante
            GetComponent<AttackerController>().enabled = true;
        }
    }
}