using UnityEngine;

public class TruckController : MonoBehaviour
{
    public string strawBaleTag = "StrawBale"; // Tag para identificar los fardos de paja
    public int baleCount = 0; // Contador de fardos recogidos
    public float speed = 12f; // Velocidad de movimiento
    public float turnSpeed = 45f; // Velocidad de giro

    private void Update()
    {
        // Movimiento de la camioneta
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime; // Avanzar/retroceder
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime; // Girar

        transform.Translate(Vector3.forward * move);
        transform.Rotate(Vector3.up * turn);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(strawBaleTag))
        {
            // Incrementar el contador y destruir el fardo recogido
            baleCount++;
            Debug.Log($"Fardo recogido. Total: {baleCount}");
            Destroy(other.gameObject);
        }
    }
}
