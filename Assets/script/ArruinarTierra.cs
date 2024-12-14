/*using UnityEngine;

public class ArruinarTierra : MonoBehaviour
{
    [Header("Tags")]
    [Tooltip("Tag de las ruedas que destruyen la tierra preparada.")]
    public string wheelTag = "ruedas";

    [Tooltip("Tag de la tierra preparada.")]
    public string preparedLandTag = "tierra preparada";

    [Header("Prefab de tierra sin preparar")]
    [Tooltip("Prefab que reemplazar� la tierra preparada.")]
    public GameObject unpreparedLandPrefab;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detectado con: " + other.gameObject.name);

        // Verificar si el objeto que colision� tiene el tag de tierra preparada
        if (other.CompareTag(preparedLandTag) && unpreparedLandPrefab != null)
        {
            Debug.Log("Trigger con tierra preparada detectado.");

            // Obtener la posici�n del objeto de tierra preparada
            Vector3 position = other.transform.position;
            Quaternion rotation = other.transform.rotation;

            // Instanciar el prefab de tierra sin preparar en la misma posici�n y rotaci�n
            Instantiate(unpreparedLandPrefab, position, rotation);

            // Destruir el objeto de tierra preparada para liberar recursos
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("Trigger no v�lido o prefab no asignado.");
        }
    }
}
*/
using UnityEngine;

public class ArruinarTierra : MonoBehaviour
{
    [Header("Tags")]
    [Tooltip("Tag de las ruedas que destruyen la tierra preparada.")]
    public string wheelTag = "ruedas";

    [Tooltip("Tag de la tierra preparada.")]
    public string preparedLandTag = "tierra preparada";

    [Header("Prefab de tierra sin preparar")]
    [Tooltip("Prefab que reemplazar� la tierra preparada.")]
    public GameObject unpreparedLandPrefab;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detectado con: " + other.gameObject.name);

        // Verificar si el objeto que colision� tiene el tag de tierra preparada
        if (other.CompareTag(preparedLandTag))
        {
            if (unpreparedLandPrefab != null)
            {
                Debug.Log("Trigger con tierra preparada detectado.");

                // Obtener la posici�n del objeto de tierra preparada
                Vector3 position = other.transform.position;
                Quaternion rotation = other.transform.rotation;

                // Instanciar el prefab de tierra sin preparar en la misma posici�n y rotaci�n
                Instantiate(unpreparedLandPrefab, position, rotation);

                // Destruir el objeto de tierra preparada para liberar recursos
                Destroy(other.gameObject);
            }
            else
            {
                Debug.LogError("Prefab de tierra sin preparar no asignado en el inspector.");
            }
        }
        else
        {
            Debug.Log("Objeto con tag no v�lido colision�: " + other.tag);
        }
    }

    private void Start()
    {
        // Verificar si el objeto tiene un Collider
        Collider collider = GetComponent<Collider>();
        if (collider == null)
        {
            Debug.LogError("El objeto que contiene este script no tiene un Collider.");
        }

        // Verificar si el prefab est� asignado
        if (unpreparedLandPrefab == null)
        {
            Debug.LogError("Prefab de tierra sin preparar no asignado en el inspector.");
        }
    }
}
