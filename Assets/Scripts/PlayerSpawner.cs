using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    public GameObject prefabAtacante;
    public GameObject prefabDefensor;

    void Start()
    {
        // Verifica se este é o jogador local (criado pelo jogador local)
        if (photonView.IsMine)
        {
            // Atribui papéis baseados no número de jogadores na sala
            int jogadorCount = PhotonNetwork.CurrentRoom.PlayerCount;

            if (jogadorCount == 1)
            {
                PhotonNetwork.Instantiate(prefabAtacante.name, transform.position, Quaternion.identity);
            }
            else if (jogadorCount == 2)
            {
                PhotonNetwork.Instantiate(prefabDefensor.name, transform.position, Quaternion.identity);
            }
        }
    }
}