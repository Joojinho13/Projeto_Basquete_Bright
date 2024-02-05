using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameStarter : MonoBehaviourPunCallbacks
{
    public string cenaDoJogo = "GameScene";
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }
    }

    void Update()
    {
        if (PhotonNetwork.CurrentRoom != null && PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.LoadLevel(cenaDoJogo);
            }
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Novo jogador entrou na sala: " + newPlayer.NickName);
    }
}
