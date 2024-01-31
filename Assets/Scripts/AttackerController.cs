using UnityEngine;

public class AttackerController : MonoBehaviour
{
    public GameObject bola;
    public bool segurandoBola = true;
    public float forcaMaximaArremesso = 100f;

    private Vector3 posicaoInicialArrasto;
    private Vector3 posicaoFinalArrasto;

    void Start()
    {
        bola.GetComponent<Rigidbody>().useGravity = false;
    }

    void Update()
    {
        if (segurandoBola)
        {
            AtualizarArrastoMouse();
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

        // Calcular a força com base na distância arrastada
        float distanciaArrastada = Vector3.Distance(posicaoInicialArrasto, posicaoFinalArrasto);
        float forcaArremesso = Mathf.Clamp(distanciaArrastada, 0, forcaMaximaArremesso);

        // Calcular a direção do arremesso (horizontal apenas)
        Vector3 direcaoArremesso = (posicaoFinalArrasto - posicaoInicialArrasto).normalized;

        // Aplicar a força ao rigidbody da bola
        Rigidbody rigidbodyBola = bola.GetComponent<Rigidbody>();
        rigidbodyBola.useGravity = true;
        rigidbodyBola.AddForce(new Vector3(direcaoArremesso.x, 1, direcaoArremesso.y) * forcaArremesso, ForceMode.Impulse);
    }
}
