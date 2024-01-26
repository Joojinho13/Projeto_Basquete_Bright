using System.Collections;
using UnityEngine;

public class AttackerController : MonoBehaviour
{
    public GameObject ball;
    public GameObject ballThrowingPoint;

    public bool holdingBall = true;

    public float ballThrowingForce;
    public float maxThrowingForce = 100f;
    public float accuracyFactor = 0.2f; // Fator de precisão, ajuste conforme necessário
    public float randomFactor = 0.1f;   // Fator aleatório para adicionar variabilidade

    private Vector3 dragStartPosition;
    private Vector3 dragEndPosition;

    void Start()
    {
        ball.GetComponent<Rigidbody>().useGravity = false;
    }

    void Update()
    {
        if (holdingBall)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragStartPosition = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                holdingBall = false;
                ball.GetComponent<Rigidbody>().useGravity = true;

                dragEndPosition = Input.mousePosition;
                Vector3 dragDirection = (dragEndPosition - dragStartPosition).normalized;

                float throwingForce = Mathf.Clamp((dragEndPosition - dragStartPosition).magnitude, 0f, maxThrowingForce);
                throwingForce *= 1 + Random.Range(-randomFactor, randomFactor); // Adiciona variabilidade

                // Aplica força ao arremessar, levando em consideração a precisão
                ball.GetComponent<Rigidbody>().AddForce(dragDirection * throwingForce * accuracyFactor);
            }
        }
    }
}
