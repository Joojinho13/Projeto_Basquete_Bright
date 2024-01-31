using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public AttackerController player;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ResetScene();
        }
    }

    void ResetScene()
    {
        // Obtém o índice da cena atual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Carrega a cena atual novamente
        SceneManager.LoadScene(currentSceneIndex);
    }
}
