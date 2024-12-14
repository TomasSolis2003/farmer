/*using UnityEngine;
using TMPro;

public class PickupHayBale : MonoBehaviour
{
    [Header("Configuración del dinero")]
    public int valorPorFardo = 10; // Dinero que suma cada fardo
    private int totalDinero = 0;  // Total acumulado

    [Header("UI")]
    public TextMeshProUGUI textoDinero; // Referencia al TextMeshPro en pantalla

    [Header("Camioneta")]
    public GameObject camioneta; // Referencia al GameObject de la camioneta con el BoxCollider

    private void Start()
    {
        // Inicializar el texto de dinero en pantalla
        if (textoDinero != null)
        {
            textoDinero.text = "$$$:0";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisiona tiene el tag "fardo"
        if (other.CompareTag("fardo"))
        {
            // Incrementar el total de dinero
            totalDinero += valorPorFardo;

            // Actualizar el texto en pantalla
            if (textoDinero != null)
            {
                textoDinero.text = "Dinero: $" + totalDinero;
            }

            // Destruir el objeto fardo
            Destroy(other.gameObject);
        }
    }
}
*/
using UnityEngine;
using TMPro;

public class PickupHayBale : MonoBehaviour
{
    [Header("Configuración del dinero")]
    public int valorPorFardo = 10; // Dinero que suma cada fardo
    private int totalDinero = 0;  // Total acumulado

    [Header("UI")]
    public TextMeshProUGUI textoDinero; // Referencia al TextMeshPro en pantalla
    public TextMeshProUGUI mensajeUI;   // Mensaje adicional para notificaciones

    [Header("Camioneta")]
    public GameObject camioneta; // Referencia al GameObject de la camioneta con el BoxCollider

    private void Start()
    {
        // Inicializar el texto de dinero en pantalla
        if (textoDinero != null)
        {
            textoDinero.text = "Dinero: $0";
        }

        // Asegurar que el mensaje está vacío al inicio
        if (mensajeUI != null)
        {
            mensajeUI.text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisiona tiene el tag "fardo"
        if (other.CompareTag("fardo"))
        {
            // Incrementar el total de dinero
            totalDinero += valorPorFardo;

            // Actualizar el texto en pantalla
            ActualizarDineroUI();

            // Destruir el objeto fardo
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("mercado"))
        {
            // Intentar comprar en el mercado
            ComprarEnMercado();
        }
    }

    private void ComprarEnMercado()
    {
        if (totalDinero >= 50)
        {
            // Restar dinero y mostrar el cambio
            totalDinero -= 50;
            ActualizarDineroUI();

            // Mostrar un mensaje de éxito
            if (mensajeUI != null)
            {
                mensajeUI.text = "¡Compra realizada!";
                Invoke("LimpiarMensaje", 2f); // Limpiar el mensaje después de 2 segundos
            }
        }
        else
        {
            // Mostrar mensaje de dinero insuficiente
            if (mensajeUI != null)
            {
                mensajeUI.text = "Dinero insuficiente para comprar.";
                Invoke("LimpiarMensaje", 2f);
            }
        }
    }

    private void ActualizarDineroUI()
    {
        if (textoDinero != null)
        {
            textoDinero.text = "Dinero: $" + totalDinero;
        }
    }

    private void LimpiarMensaje()
    {
        if (mensajeUI != null)
        {
            mensajeUI.text = "";
        }
    }
}
