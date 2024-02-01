using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    void Update()
    {
        // Verifica se a tecla "R" foi pressionada
        if (Input.GetKeyDown(KeyCode.F1))
        {
            // Chama a função para reiniciar a cena
            ReiniciarCena();
        }
    }

    void ReiniciarCena()
    {
        // Obtém o índice da cena atual
        int cenaAtual = SceneManager.GetActiveScene().buildIndex;

        // Carrega novamente a cena atual
        SceneManager.LoadScene(cenaAtual);
    }
}
