/*using UnityEngine;
using TMPro; // Necesario para usar Text Mesh Pro.

public class UpgradeGuada�aScalerWithTextAndColor : MonoBehaviour
{
    public float scaleAmount = 1.1f; // Cantidad por la que se multiplicar� la escala en X.
    private int upgradeCount = 0; // Contador de mejoras.
    private int maxUpgrades = 10; // L�mite de mejoras.
    private Renderer upgradeRenderer; // Renderer del objeto UpgradeGuada�a.
    public TextMeshPro textMeshPro; // Referencia al Text Mesh Pro.

    private void Start()
    {
        // Asignar el Renderer del objeto UpgradeGuada�a.
        upgradeRenderer = GetComponent<Renderer>();

        if (upgradeRenderer == null)
        {
            Debug.LogWarning("El objeto UpgradeGuada�a no tiene un Renderer asignado.");
        }

        // Inicializa el texto a "0/10".
        UpdateUpgradeText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject guada�a = GameObject.FindGameObjectWithTag("guada�a");

            if (guada�a != null && upgradeCount < maxUpgrades)
            {
                // Aumenta la escala en X de la guada�a.
                Vector3 newScale = guada�a.transform.localScale;
                newScale.x *= scaleAmount;
                guada�a.transform.localScale = newScale;

                upgradeCount++;
                Debug.Log("Mejora " + upgradeCount + "/" + maxUpgrades + " aplicada.");

                // Cambia el color gradualmente y lo mantiene verde al m�ximo.
                Color newColor = upgradeCount < maxUpgrades ? Color.Lerp(Color.white, Color.green, (float)upgradeCount / maxUpgrades) : Color.green;
                if (upgradeRenderer != null)
                {
                    upgradeRenderer.material.color = newColor;
                }

                // Actualiza el texto.
                UpdateUpgradeText();
            }
            else if (upgradeCount >= maxUpgrades)
            {
                Debug.Log("Mejoras completas. El objeto est� al m�ximo.");
            }
        }
    }

    private void UpdateUpgradeText()
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = upgradeCount + "/" + maxUpgrades;
        }
        else
        {
            Debug.LogWarning("No se ha asignado un Text Mesh Pro al script.");
        }
    }
}
*/// salva vidas
/*using UnityEngine;
using TMPro;

public class UpgradeGuada�aScalerWithTextAndColor : MonoBehaviour
{
    [Header("Mejoras de la guada�a")]
    public float scaleAmount = 1.1f; // Cantidad por la que se multiplicar� la escala en X.
    private int upgradeCount = 0; // Contador de mejoras.
    private int maxUpgrades = 10; // L�mite de mejoras.
    private Renderer upgradeRenderer; // Renderer del objeto UpgradeGuada�a.
    public TextMeshPro textMeshPro; // Referencia al Text Mesh Pro.

    [Header("Sistema de dinero")]
    public int dinero = 100; // Dinero inicial del jugador.
    public TextMeshPro dineroTextMeshPro; // Referencia al TextMeshPro que muestra el dinero en pantalla.

    private void Start()
    {
        // Asignar el Renderer del objeto UpgradeGuada�a.
        upgradeRenderer = GetComponent<Renderer>();

        if (upgradeRenderer == null)
        {
            Debug.LogWarning("El objeto UpgradeGuada�a no tiene un Renderer asignado.");
        }

        // Inicializa el texto de mejoras y dinero.
        UpdateUpgradeText();
        UpdateDineroUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject guada�a = GameObject.FindGameObjectWithTag("guada�a");

            if (guada�a != null && upgradeCount < maxUpgrades)
            {
                // Aumenta la escala en X de la guada�a.
                Vector3 newScale = guada�a.transform.localScale;
                newScale.x *= scaleAmount;
                guada�a.transform.localScale = newScale;

                upgradeCount++;
                Debug.Log("Mejora " + upgradeCount + "/" + maxUpgrades + " aplicada.");

                // Cambia el color gradualmente y lo mantiene verde al m�ximo.
                Color newColor = upgradeCount < maxUpgrades ? Color.Lerp(Color.white, Color.green, (float)upgradeCount / maxUpgrades) : Color.green;
                if (upgradeRenderer != null)
                {
                    upgradeRenderer.material.color = newColor;
                }

                // Actualiza el texto de mejoras.
                UpdateUpgradeText();
            }
            else if (upgradeCount >= maxUpgrades)
            {
                Debug.Log("Mejoras completas. El objeto est� al m�ximo.");
            }
        }
        else if (other.CompareTag("mercado"))
        {
            // Interactuar con el mercado.
            ComprarEnMercado();
        }
    }

    private void ComprarEnMercado()
    {
        if (dinero >= 50)
        {
            dinero -= 50;
            Debug.Log("Compra realizada. Dinero restante: $" + dinero);
            UpdateDineroUI();
        }
        else
        {
            Debug.Log("Dinero insuficiente para comprar.");
        }
    }

    private void UpdateUpgradeText()
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = upgradeCount + "/" + maxUpgrades;
        }
        else
        {
            Debug.LogWarning("No se ha asignado un Text Mesh Pro al script.");
        }
    }

    private void UpdateDineroUI()
    {
        if (dineroTextMeshPro != null)
        {
            dineroTextMeshPro.text = "Dinero: $" + dinero;
        }
        else
        {
            Debug.LogWarning("No se ha asignado un Text Mesh Pro para el dinero.");
        }
    }
}
*/
using UnityEngine;
using TMPro; // Necesario para usar Text Mesh Pro.

public class UpgradeGuada�aScalerWithTextAndColor : MonoBehaviour
{
    [Header("Mejoras de la guada�a")]
    public float scaleAmount = 1.1f; // Cantidad por la que se multiplicar� la escala en X.
    private int upgradeCount = 0; // Contador de mejoras.
    private int maxUpgrades = 10; // L�mite de mejoras.
    private Renderer upgradeRenderer; // Renderer del objeto UpgradeGuada�a.
    public TextMeshProUGUI upgradeText; // Referencia al TextMeshProUGUI para mejoras.

    [Header("Sistema de dinero")]
    public int dinero = 100; // Dinero inicial del jugador.
    public int costoMejora = 50; // Costo de cada mejora.
    public TextMeshProUGUI dineroText; // Referencia al TextMeshProUGUI que muestra el dinero en pantalla.

    private void Start()
    {
        // Asignar el Renderer del objeto UpgradeGuada�a.
        upgradeRenderer = GetComponent<Renderer>();

        if (upgradeRenderer == null)
        {
            Debug.LogWarning("El objeto UpgradeGuada�a no tiene un Renderer asignado.");
        }

        // Inicializa el texto de mejoras y dinero.
        UpdateUpgradeText();
        UpdateDineroUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject guada�a = GameObject.FindGameObjectWithTag("guada�a");

            if (guada�a != null && upgradeCount < maxUpgrades)
            {
                // Verifica si el jugador tiene suficiente dinero para mejorar.
                if (dinero >= costoMejora)
                {
                    // Aumenta la escala en X de la guada�a.
                    Vector3 newScale = guada�a.transform.localScale;
                    newScale.x *= scaleAmount;
                    guada�a.transform.localScale = newScale;

                    upgradeCount++;
                    dinero -= costoMejora; // Resta el costo de la mejora.
                    Debug.Log("Mejora " + upgradeCount + "/" + maxUpgrades + " aplicada.");
                    Debug.Log("Dinero restante: $" + dinero);

                    // Cambia el color gradualmente y lo mantiene verde al m�ximo.
                    Color newColor = upgradeCount < maxUpgrades ? Color.Lerp(Color.white, Color.green, (float)upgradeCount / maxUpgrades) : Color.green;
                    if (upgradeRenderer != null)
                    {
                        upgradeRenderer.material.color = newColor;
                    }

                    // Actualiza el texto de mejoras y dinero.
                    UpdateUpgradeText();
                    UpdateDineroUI();
                }
                else
                {
                    Debug.Log("Dinero insuficiente para mejorar.");
                }
            }
            else if (upgradeCount >= maxUpgrades)
            {
                Debug.Log("Mejoras completas. El objeto est� al m�ximo.");
            }
        }
        else if (other.CompareTag("mercado"))
        {
            ComprarEnMercado();
        }
    }

    private void ComprarEnMercado()
    {
        if (dinero >= 50)
        {
            dinero -= 50;
            Debug.Log("Compra realizada. Dinero restante: $" + dinero);
            UpdateDineroUI();
        }
        else
        {
            Debug.Log("Dinero insuficiente para comprar en el mercado.");
        }
    }

    private void UpdateUpgradeText()
    {
        if (upgradeText != null)
        {
            upgradeText.text = upgradeCount + "/" + maxUpgrades;
        }
        else
        {
            Debug.LogWarning("No se ha asignado un TextMeshProUGUI para las mejoras.");
        }
    }

    private void UpdateDineroUI()
    {
        if (dineroText != null)
        {
            dineroText.text = "Dinero: $" + dinero;
        }
        else
        {
            Debug.LogWarning("No se ha asignado un TextMeshProUGUI para el dinero.");
        }
    }
}
