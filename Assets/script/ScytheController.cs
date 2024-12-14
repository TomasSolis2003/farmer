
/*using UnityEngine;

public class ScytheController : MonoBehaviour
{
    public string wheatTag = "trigo"; // Tag para identificar los trigos
    public GameObject strawBalePrefab; // Prefab del fardo de paja
    public Transform spawnPoint; // Punto de spawn detr�s del veh�culo
    public int wheatThreshold = 7; // Cantidad de trigos para generar un fardo de paja

    private int wheatCount = 0; // Contador de trigos cosechados

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Colisionando con: {other.name}"); // Mensaje de depuraci�n para verificar colisiones

        if (other.CompareTag(wheatTag))
        {
            Debug.Log("Trigo cosechado!"); // Confirmaci�n de trigo detectado
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
            Debug.Log("Fardo de paja generado."); // Mensaje para verificar generaci�n del prefab
        }
        else
        {
            Debug.LogWarning("Prefab o punto de spawn no asignados.");
        }
    }
}
*/
/*using UnityEngine;

public class ScytheController : MonoBehaviour
{
    public string wheatTag = "trigo"; // Tag para identificar los trigos
    public GameObject strawBalePrefab; // Prefab del fardo de paja
    public Transform spawnPoint; // Punto de spawn detr�s del veh�culo
    public GameObject unpreparedSoilPrefab; // Prefab de la tierra sin preparar
    public int wheatThreshold = 7; // Cantidad de trigos para generar un fardo de paja

    private int wheatCount = 0; // Contador de trigos cosechados

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Colisionando con: {other.name}"); // Mensaje de depuraci�n para verificar colisiones

        if (other.CompareTag(wheatTag))
        {
            Debug.Log("Trigo cosechado!"); // Confirmaci�n de trigo detectado
            Vector3 position = other.transform.position; // Obtener la posici�n del trigo
            Quaternion rotation = other.transform.rotation; // Mantener la rotaci�n
            Destroy(other.gameObject); // Destruir el trigo
            wheatCount++; // Incrementar contador de trigos

            // Generar tierra sin preparar en el lugar donde estaba el trigo
            if (unpreparedSoilPrefab != null)
            {
                Instantiate(unpreparedSoilPrefab, position, rotation);
            }
            else
            {
                Debug.LogWarning("Prefab de tierra sin preparar no asignado.");
            }

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
            Debug.Log("Fardo de paja generado."); // Mensaje para verificar generaci�n del prefab
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
    public Transform spawnPoint; // Punto de spawn detr�s del veh�culo
    public GameObject unpreparedSoilPrefab; // Prefab de la tierra sin preparar
    public int wheatThreshold = 7; // Cantidad de trigos para generar un fardo de paja

    private int wheatCount = 0; // Contador de trigos cosechados

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Colisionando con: {other.name}"); // Mensaje de depuraci�n para verificar colisiones

        if (other.CompareTag(wheatTag))
        {
            Debug.Log("Trigo cosechado!"); // Confirmaci�n de trigo detectado

            // Obtener la posici�n del trigo, ajustando la altura a Y = 1
            Vector3 position = other.transform.position;
            position.y = 1f;

            Destroy(other.gameObject); // Destruir el trigo
            wheatCount++; // Incrementar contador de trigos

            // Generar tierra sin preparar en la posici�n ajustada
            if (unpreparedSoilPrefab != null)
            {
                Instantiate(unpreparedSoilPrefab, position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("Prefab de tierra sin preparar no asignado.");
            }

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
            Debug.Log("Fardo de paja generado."); // Mensaje para verificar generaci�n del prefab
        }
        else
        {
            Debug.LogWarning("Prefab o punto de spawn no asignados.");
        }
    }
}
