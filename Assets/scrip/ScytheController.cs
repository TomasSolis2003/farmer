/*using UnityEngine;

public class ScytheController : MonoBehaviour
{
    public string wheatTag = "trigo"; // Tag para identificar los trigos
    public GameObject strawBalePrefab; // Prefab del fardo de paja
    public Transform spawnPoint; // Punto de spawn detrás del vehículo
    public int wheatThreshold = 7; // Cantidad de trigos para generar un fardo de paja

    private int wheatCount = 0; // Contador de trigos cosechados

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(wheatTag))
        {
            Destroy(collision.gameObject); // Destruir el trigo
            wheatCount++; // Incrementar contador de trigos

            if (wheatCount >= wheatThreshold)
            {
                GenerateStrawBale();
                wheatCount = 0; // Reiniciar contador
            }
        }
    }

    private void GenerateStrawBale()
    {
        if (strawBalePrefab != null && spawnPoint != null)
        {
            Instantiate(strawBalePrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("Prefab o punto de spawn no asignados.");
        }
    }
}
*/
using UnityEngine;

public class ScytheController : MonoBehaviour
{
    public string wheatTag = "trigo"; // Tag para identificar los trigos
    public GameObject strawBalePrefab; // Prefab del fardo de paja
    public Transform spawnPoint; // Punto de spawn detrás del vehículo
    public int wheatThreshold = 7; // Cantidad de trigos para generar un fardo de paja

    private int wheatCount = 0; // Contador de trigos cosechados

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Colisionando con: {other.name}"); // Mensaje de depuración para verificar colisiones

        if (other.CompareTag(wheatTag))
        {
            Debug.Log("Trigo cosechado!"); // Confirmación de trigo detectado
            Destroy(other.gameObject); // Destruir el trigo
            wheatCount++; // Incrementar contador de trigos

            if (wheatCount >= wheatThreshold)
            {
                GenerateStrawBale();
                wheatCount = 0; // Reiniciar contador
            }
        }
    }

    private void GenerateStrawBale()
    {
        if (strawBalePrefab != null && spawnPoint != null)
        {
            Instantiate(strawBalePrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Fardo de paja generado."); // Mensaje para verificar generación del prefab
        }
        else
        {
            Debug.LogWarning("Prefab o punto de spawn no asignados.");
        }
    }
}
