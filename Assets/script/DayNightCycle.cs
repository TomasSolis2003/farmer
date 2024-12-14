using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sunLight; // Luz del sol
    public float dayDuration = 120f; // Duraci�n de un d�a completo en segundos
    public Color dayColor = Color.white; // Color de la luz de d�a
    public Color nightColor = Color.blue; // Color de la luz de noche
    public float moonIntensity = 0.3f; // Intensidad de la luz lunar

    private float timeOfDay = 0f; // Tiempo actual del d�a (0 a 1)
    private float sunInitialIntensity; // Intensidad inicial del sol

    private void Start()
    {
        // Guardar la intensidad inicial de la luz del sol
        if (sunLight != null)
        {
            sunInitialIntensity = sunLight.intensity;
        }
    }

    private void Update()
    {
        // Incrementar el tiempo del d�a (de 0 a 1)
        timeOfDay += Time.deltaTime / dayDuration;

        if (timeOfDay > 1f) // Si el d�a termin�, reiniciar
        {
            timeOfDay = 0f;
        }

        // Ajustar la rotaci�n del sol para simular el ciclo de d�a/noche
        if (sunLight != null)
        {
            sunLight.transform.rotation = Quaternion.Euler((timeOfDay * 360f) - 90f, 0f, 0f);

            // Cambiar la intensidad y color de la luz seg�n el ciclo de d�a y noche
            sunLight.color = Color.Lerp(nightColor, dayColor, timeOfDay);
            sunLight.intensity = Mathf.Lerp(moonIntensity, sunInitialIntensity, timeOfDay);

            // Si quieres que la luz de la luna sea visible en la noche, ajusta la intensidad
            if (timeOfDay >= 0.5f) // Durante la noche
            {
                sunLight.intensity = moonIntensity;
            }
        }
    }
}
