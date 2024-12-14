using UnityEngine;

public class VehiculoRegador : MonoBehaviour
{
    [Header("Tags")]
    [Tooltip("Tag de la tierra preparada.")]
    public string preparedLandTag = "tierra preparada";

    [Tooltip("Cantidad de humedad a añadir.")]
    public int humidityIncrease = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(preparedLandTag))
        {
            TierraComportamiento tierra = other.GetComponent<TierraComportamiento>();
            if (tierra != null)
            {
                tierra.AumentarHumedad(humidityIncrease);
                Debug.Log("Humedad aumentada en: " + other.gameObject.name);
            }
        }
    }
}
