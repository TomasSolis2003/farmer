using UnityEngine;

public class TierraComportamiento : MonoBehaviour
{
    [Header("Estados de la tierra")]
    [Tooltip("Estado inicial de la tierra.")]
    public int humedad = 0; // 0: Seco, 1: Ligeramente Húmedo, 2: Húmedo, 3: Muy Húmedo

    [Tooltip("Prefab de tierra sin preparar.")]
    public GameObject unpreparedLandPrefab;

    [Tooltip("Tiempo en segundos para cambiar a tierra sin preparar si está seca.")]
    public float tiempoParaSecarse = 360f; // 6 minutos

    private float tiempoSeco;

    private void Start()
    {
        tiempoSeco = 0f;
    }

    private void Update()
    {
        if (humedad == 0)
        {
            tiempoSeco += Time.deltaTime;
            if (tiempoSeco >= tiempoParaSecarse)
            {
                ConvertirATierraSinPreparar();
            }
        }
        else
        {
            tiempoSeco = 0f; // Reiniciar el contador si no está seco
        }
    }

    public void AumentarHumedad(int cantidad)
    {
        humedad = Mathf.Clamp(humedad + cantidad, 0, 3);
        Debug.Log("Nivel de humedad actual: " + humedad);
    }

    private void ConvertirATierraSinPreparar()
    {
        if (unpreparedLandPrefab != null)
        {
            Instantiate(unpreparedLandPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            Debug.Log("Tierra convertida a tierra sin preparar por estar demasiado tiempo seca.");
        }
        else
        {
            Debug.LogError("Prefab de tierra sin preparar no asignado.");
        }
    }
}

