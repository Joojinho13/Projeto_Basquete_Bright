using System.Collections;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public AttackerController Atacante;
    public DefenderController Defensor;
    public Transform posicaoInicialAtacante;
    public Transform posicaoInicialDefensor; 
    public GameObject Bola;

    private bool faseResetada = false;
    private float tempoResetFase = 5f; // Tempo para resetar a fase

    void Start()
    {
        StartCoroutine(VerificarArremesso());
    }

    IEnumerator VerificarArremesso()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (!faseResetada && Atacante != null && !Atacante.SegurandoBola())
            {
                faseResetada = true;

                // Aguarde o tempo antes de resetar a fase
                yield return new WaitForSeconds(tempoResetFase);

                ResetarFase();
                TrocarPapeis();
            }
        }
    }

    void ResetarFase()
    {
        if (Atacante != null && Defensor != null)
        {
            Atacante.transform.position = posicaoInicialAtacante.position;
            Defensor.transform.position = posicaoInicialDefensor.position;
            ReposicionarBola();
        }

        faseResetada = false;
    }

    Vector3 PosicaoInicialAtacante()
    {
        // Posição inicial desejada do Atacante
        return new Vector3((float)1.57, (float)1.70215, (float)7.620001);
    }

    Vector3 PosicaoInicialDefensor()
    {
        // Posição inicial desejada do Defensor
        return new Vector3(0, 1, 0);
    }

    void ReposicionarBola()
    {
        // Substitua esta lógica pela posição inicial desejada da bola
        Bola.transform.position = new Vector3(0, 1, 10);
        Bola.GetComponent<Rigidbody>().velocity = Vector3.zero; // Zera a velocidade da bola
    }

    void TrocarPapeis()
    {
        if (Atacante != null)
        {
            Atacante.TrocarPapel();
        }

        if (Defensor != null)
        {
            Defensor.TrocarPapel();
        }
    }
}