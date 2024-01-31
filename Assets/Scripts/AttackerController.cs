using UnityEngine;

public class AttackerController : MonoBehaviour
{
    public GameObject ball;
    public bool holdingBall = true;
    public float maxThrowingForce = 100f;
    public float accuracyFactor = 0.2f;
    public float randomFactor = 0.1f;

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
                throwingForce *= 1 + Random.Range(-randomFactor, randomFactor);

                float upwardForce = throwingForce * 0.5f; // Ajuste conforme necessário
                float forwardForce = throwingForce * 2f; // Ajuste conforme necessário

                Vector3 throwForce = new Vector3(dragDirection.x * forwardForce * 50, upwardForce * 50, dragDirection.y * forwardForce* 50);

                // Aplica força ao arremessar, levando em consideração a precisão
                ball.GetComponent<Rigidbody>().AddForce((throwForce * 100) * accuracyFactor);
                
                Debug.Log("Throw Direction: " + dragDirection);
                Debug.Log("Throw Force: " + throwingForce);
                Debug.Log("Accuracy Factor: " + accuracyFactor);
            }
        }
    }
}
