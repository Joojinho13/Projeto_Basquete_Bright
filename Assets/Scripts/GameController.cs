using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public AttackerController player;

    public float resetTimer;


    void Start()
    {
        
    }

    void Update()
    {
        if (player.holdingBall == false)
        {
            resetTimer -= Time.deltaTime;
            if(resetTimer <= 0)
            {
                SceneManager.LoadScene ("GameScene");
            }
        }
    }
}
