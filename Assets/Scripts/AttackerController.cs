using Photon.Pun;
using UnityEngine;

public class AttackerController : MonoBehaviour
{
    public GameObject bola;
    public bool segurandoBola = true;
    public float forcaMaximaArremesso = 100f;
    public float fatorInfluenciaArrasto = 1.5f; // Ajuste este valor conforme necessário
    public float alturaArremesso = 2.0f; // Ajuste este valor para controlar a altura do arremesso

    private Vector3 posicaoInicialArrasto;
    private Vector3 posicaoFinalArrasto;
    private PhotonView view;

    void Start()
    {
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
          bola.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    void Update()
    {
        if (view.IsMine)
        {
          if (segurandoBola)
            {
                AtualizarArrastoMouse();
            }
            
        }
    }

    void AtualizarArrastoMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            posicaoInicialArrasto = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            posicaoFinalArrasto = Input.mousePosition;
            RealizarArremesso();
        }
    }

    void RealizarArremesso()
    {
        segurandoBola = false;

        // Calcular a força com base na distância arrastada, com ajuste de influência
        float distanciaArrastada = Vector3.Distance(posicaoInicialArrasto, posicaoFinalArrasto);
        float forcaArremesso = Mathf.Clamp(distanciaArrastada * fatorInfluenciaArrasto, 0, forcaMaximaArremesso);

        // Calcular a direção do arremesso sempre para frente no eixo Z, com ajuste para cima no eixo Y
        Vector3 direcaoArremesso = new Vector3(0, alturaArremesso, 1).normalized;

        // Aplicar a força ao rigidbody da bola
        Rigidbody rigidbodyBola = bola.GetComponent<Rigidbody>();
        rigidbodyBola.useGravity = true;
        rigidbodyBola.AddForce(direcaoArremesso * forcaArremesso, ForceMode.Impulse);
    }
}
