/*using UnityEngine;
using TMPro;

public class ScytheUpgradeShop : MonoBehaviour
{
    public GameObject scythe; // La guada�a a mejorar
    public TextMeshProUGUI moneyText; // Texto que muestra el dinero del jugador
    public TextMeshProUGUI feedbackText; // Texto para mostrar mensajes al jugador (opcional)
    public int upgradeCost = 50; // Costo por cada mejora
    public float scaleIncrement = 1f; // Incremento en la escala X por cada mejora

    private int currentMoney; // Dinero actual del jugador

    private void Start()
    {
        // Inicializa el dinero desde el texto (aseg�rate de que el formato sea "Dinero: $123")
        currentMoney = ParseMoneyFromText();
    }

    public void UpgradeScythe()
    {
        if (currentMoney >= upgradeCost)
        {
            // Resta el costo de la mejora del dinero del jugador
            currentMoney -= upgradeCost;

            // Aumenta la escala de la guada�a
            Vector3 newScale = scythe.transform.localScale;
            newScale.x += scaleIncrement;
            scythe.transform.localScale = newScale;

            // Actualiza el texto de dinero
            UpdateMoneyText();

            // Mensaje de �xito
            if (feedbackText != null)
            {
                feedbackText.text = $"�Guada�a mejorada! Dinero restante: ${currentMoney}";
            }
        }
        else
        {
            // Mensaje de error
            if (feedbackText != null)
            {
                feedbackText.text = "No tienes suficiente dinero para mejorar la guada�a.";
            }
        }
    }

    private int ParseMoneyFromText()
    {
        if (moneyText != null)
        {
            string text = moneyText.text.Replace("Dinero: $", "");
            if (int.TryParse(text, out int money))
            {
                return money;
            }
        }
        return 0; // Por defecto, dinero inicial 0 si falla la conversi�n
    }

    private void UpdateMoneyText()
    {
        if (moneyText != null)
        {
            moneyText.text = $"Dinero: ${currentMoney}";
        }
    }
}
*/
using UnityEngine;
using TMPro;

public class ScytheUpgradeShop : MonoBehaviour
{
    public GameObject scythe; // La guada�a a mejorar
    public TextMeshProUGUI moneyText; // Texto que muestra el dinero del jugador
    public TextMeshProUGUI feedbackText; // Texto para mostrar mensajes al jugador (opcional)
    public int upgradeCost = 50; // Costo por cada mejora
    public float scaleIncrement = 1f; // Incremento en la escala X por cada mejora
    private int currentMoney; // Dinero actual del jugador
    private bool isPlayerInShop = false; // Indica si el jugador est� dentro del �rea de la tienda

    private void Start()
    {
        // Inicializa el dinero desde el texto (aseg�rate de que el formato sea "Dinero: $123")
        currentMoney = ParseMoneyFromText();
    }

    private void Update()
    {
        // Detecta si el jugador est� dentro del �rea de la tienda y presiona la tecla X
        if (isPlayerInShop && Input.GetKeyDown(KeyCode.X))
        {
            UpgradeScythe();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detecta si el jugador entra al �rea de la tienda
        if (other.CompareTag("Player")) // Aseg�rate de que el jugador tenga la tag "Player"
        {
            isPlayerInShop = true;
            if (feedbackText != null)
            {
                feedbackText.text = "Presiona 'X' para mejorar tu guada�a.";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Detecta si el jugador sale del �rea de la tienda
        if (other.CompareTag("Player"))
        {
            isPlayerInShop = false;
            if (feedbackText != null)
            {
                feedbackText.text = ""; // Limpia el mensaje
            }
        }
    }

    public void UpgradeScythe()
    {
        if (currentMoney >= upgradeCost)
        {
            // Resta el costo de la mejora del dinero del jugador
            currentMoney -= upgradeCost;

            // Aumenta la escala de la guada�a
            Vector3 newScale = scythe.transform.localScale;
            newScale.x += scaleIncrement;
            scythe.transform.localScale = newScale;

            // Actualiza el texto de dinero
            UpdateMoneyText();

            // Mensaje de �xito
            if (feedbackText != null)
            {
                feedbackText.text = $"�Guada�a mejorada! Dinero restante: ${currentMoney}";
            }
        }
        else
        {
            // Mensaje de error
            if (feedbackText != null)
            {
                feedbackText.text = "No tienes suficiente dinero para mejorar la guada�a.";
            }
        }
    }

    private int ParseMoneyFromText()
    {
        if (moneyText != null)
        {
            string text = moneyText.text.Replace("Dinero: $", "");
            if (int.TryParse(text, out int money))
            {
                return money;
            }
        }
        return 0; // Por defecto, dinero inicial 0 si falla la conversi�n
    }

    private void UpdateMoneyText()
    {
        if (moneyText != null)
        {
            moneyText.text = $"Dinero: ${currentMoney}";
        }
    }
}
