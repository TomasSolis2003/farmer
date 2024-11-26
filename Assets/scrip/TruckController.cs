/*using UnityEngine;

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
*/
/*using UnityEngine;
using TMPro;

public class TruckController : MonoBehaviour
{
    public string strawBaleTag = "StrawBale"; // Tag para identificar los fardos de paja
    public int baleCount = 0; // Contador de fardos recogidos
    public float speed = 12f; // Velocidad de movimiento
    public float turnSpeed = 45f; // Velocidad de giro
    public Transform baleDropPoint; // Punto donde se dropean los fardos
    public GameObject balePrefab; // Prefab de los fardos para dropear
    public TextMeshProUGUI baleCounterText; // Texto en pantalla para mostrar la cantidad de fardos

    private void Update()
    {
        // Movimiento de la camioneta
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime; // Avanzar/retroceder
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime; // Girar

        transform.Translate(Vector3.forward * move);
        transform.Rotate(Vector3.up * turn);

        // Dropear fardos al presionar la tecla 'G'
        if (Input.GetKeyDown(KeyCode.G))
        {
            DropBales();
        }

        // Actualizar el texto en pantalla
        UpdateBaleCounterText();
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

    private void DropBales()
    {
        if (baleCount > 0)
        {
            // Crear un fardo en el punto de dropeo
            GameObject droppedBale = Instantiate(balePrefab, baleDropPoint.position, baleDropPoint.rotation);
            Debug.Log("Fardo dropeado.");
            baleCount--; // Reducir el contador de fardos
        }
        else
        {
            Debug.Log("No hay fardos para dropear.");
        }
    }

    private void UpdateBaleCounterText()
    {
        if (baleCounterText != null)
        {
            baleCounterText.text = $"Fardos: {baleCount}";
        }
    }
}
*/
/*using UnityEngine;
using TMPro;

public class TruckController : MonoBehaviour
{
    public string strawBaleTag = "StrawBale"; // Tag para identificar los fardos de paja
    public string cashingPointTag = "CashingPoint"; // Tag para identificar el punto de canje
    public int baleCount = 0; // Contador de fardos recogidos
    public int money = 0; // Dinero acumulado
    public int baleValue = 10; // Valor de cada fardo
    public float speed = 12f; // Velocidad de movimiento
    public float turnSpeed = 45f; // Velocidad de giro

    public TextMeshProUGUI baleCounterText; // Texto para mostrar la cantidad de fardos
    public TextMeshProUGUI moneyText; // Texto para mostrar el dinero acumulado

    private void Update()
    {
        // Movimiento de la camioneta
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime; // Avanzar/retroceder
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime; // Girar

        transform.Translate(Vector3.forward * move);
        transform.Rotate(Vector3.up * turn);

        // Actualizar textos en pantalla
        UpdateUI();
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

        if (other.CompareTag(cashingPointTag))
        {
            // Canjear fardos por dinero
            if (baleCount > 0)
            {
                int earnedMoney = baleCount * baleValue;
                money += earnedMoney;
                Debug.Log($"Fardos canjeados: {baleCount}. Dinero ganado: {earnedMoney}. Dinero total: {money}");
                baleCount = 0; // Resetear el contador de fardos
            }
            else
            {
                Debug.Log("No tienes fardos para canjear.");
            }
        }
    }

    private void UpdateUI()
    {
        // Actualizar los textos en pantalla
        if (baleCounterText != null)
        {
            baleCounterText.text = $"Fardos: {baleCount}";
        }

        if (moneyText != null)
        {
            moneyText.text = $"Dinero: ${money}";
        }
    }
}
*/
/*using UnityEngine;
using TMPro;

public class TruckController : MonoBehaviour
{
    public string strawBaleTag = "StrawBale"; // Tag para identificar los fardos de paja
    public int baleCount = 0; // Contador de fardos recogidos
    public int money = 0; // Dinero acumulado
    public int baleValue = 10; // Valor de cada fardo
    public float speed = 12f; // Velocidad de movimiento
    public float turnSpeed = 45f; // Velocidad de giro

    public TextMeshProUGUI baleCounterText; // Texto para mostrar la cantidad de fardos
    public TextMeshProUGUI moneyText; // Texto para mostrar el dinero acumulado

    private bool isInsideCashingArea = false; // Verifica si está dentro del área de canje

    private void Update()
    {
        // Movimiento de la camioneta
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime; // Avanzar/retroceder
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime; // Girar

        transform.Translate(Vector3.forward * move);
        transform.Rotate(Vector3.up * turn);

        // Canjear fardos al presionar "G" dentro del área
        if (isInsideCashingArea && Input.GetKeyDown(KeyCode.G))
        {
            CashBales();
        }

        // Actualizar textos en pantalla
        UpdateUI();
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

        if (other.CompareTag("CashingArea")) // Detectar entrada al área de canje
        {
            isInsideCashingArea = true;
            Debug.Log("Dentro del área de canje. Presiona G para canjear.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CashingArea")) // Detectar salida del área de canje
        {
            isInsideCashingArea = false;
            Debug.Log("Saliste del área de canje.");
        }
    }

    private void CashBales()
    {
        if (baleCount > 0)
        {
            int earnedMoney = baleCount * baleValue;
            money += earnedMoney;
            Debug.Log($"Fardos canjeados: {baleCount}. Dinero ganado: {earnedMoney}. Dinero total: {money}");
            baleCount = 0; // Resetear el contador de fardos
        }
        else
        {
            Debug.Log("No tienes fardos para canjear.");
        }
    }

    private void UpdateUI()
    {
        // Actualizar los textos en pantalla
        if (baleCounterText != null)
        {
            baleCounterText.text = $"Fardos: {baleCount}";
        }

        if (moneyText != null)
        {
            moneyText.text = $"Dinero: ${money}";
        }
    }
}
*/
/*using UnityEngine;
using TMPro;

public class TruckController : MonoBehaviour
{
    public string strawBaleTag = "StrawBale"; // Tag para identificar los fardos de paja
    public int baleCount = 0; // Contador de fardos recogidos
    public int money = 0; // Dinero acumulado
    public int baleValue = 10; // Valor de cada fardo
    public float speed = 12f; // Velocidad de movimiento
    public float turnSpeed = 45f; // Velocidad de giro

    public TextMeshProUGUI baleCounterText; // Texto para mostrar la cantidad de fardos
    public TextMeshProUGUI moneyText; // Texto para mostrar el dinero acumulado
    public GameObject cashingArea; // Área de canje asignada desde el inspector

    private bool isInsideCashingArea = false; // Verifica si está dentro del área de canje

    private void Update()
    {
        // Movimiento de la camioneta
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime; // Avanzar/retroceder
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime; // Girar

        transform.Translate(Vector3.forward * move);
        transform.Rotate(Vector3.up * turn);

        // Canjear fardos al presionar "G" dentro del área
        if (isInsideCashingArea && Input.GetKeyDown(KeyCode.G))
        {
            CashBales();
        }

        // Actualizar textos en pantalla
        UpdateUI();
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

        if (other.gameObject == cashingArea) // Detectar entrada al área de canje
        {
            isInsideCashingArea = true;
            Debug.Log("Dentro del área de canje. Presiona G para canjear.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == cashingArea) // Detectar salida del área de canje
        {
            isInsideCashingArea = false;
            Debug.Log("Saliste del área de canje.");
        }
    }

    private void CashBales()
    {
        if (baleCount > 0)
        {
            int earnedMoney = baleCount * baleValue;
            money += earnedMoney;
            Debug.Log($"Fardos canjeados: {baleCount}. Dinero ganado: {earnedMoney}. Dinero total: {money}");
            baleCount = 0; // Resetear el contador de fardos
        }
        else
        {
            Debug.Log("No tienes fardos para canjear.");
        }
    }

    private void UpdateUI()
    {
        // Actualizar los textos en pantalla
        if (baleCounterText != null)
        {
            baleCounterText.text = $"Fardos: {baleCount}";
        }

        if (moneyText != null)
        {
            moneyText.text = $"Dinero: ${money}";
        }
    }
}
*/
/*using UnityEngine;
using TMPro;

public class TruckController : MonoBehaviour
{
    public string strawBaleTag = "StrawBale"; // Tag para identificar los fardos de paja
    public int baleCount = 0; // Contador de fardos recogidos
    public int money = 0; // Dinero acumulado
    public int baleValue = 10; // Valor de cada fardo
    public float speed = 12f; // Velocidad de movimiento
    public float turnSpeed = 45f; // Velocidad de giro

    public TextMeshProUGUI baleCounterText; // Texto para mostrar la cantidad de fardos
    public TextMeshProUGUI moneyText; // Texto para mostrar el dinero acumulado
    public GameObject cashingArea; // Área de canje asignada desde el inspector

    private bool isInsideCashingArea = false; // Verifica si está dentro del área de canje

    private void Update()
    {
        // Movimiento de la camioneta
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime; // Avanzar/retroceder
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime; // Girar

        transform.Translate(Vector3.forward * move);
        transform.Rotate(Vector3.up * turn);

        // Canjear fardos al presionar "G" dentro del área
        if (isInsideCashingArea && Input.GetKeyDown(KeyCode.G))
        {
            CashBales();
        }

        // Actualizar textos en pantalla
        UpdateUI();
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

        if (other.gameObject == cashingArea) // Detectar entrada al área de canje
        {
            isInsideCashingArea = true;
            Debug.Log("Dentro del área de canje. Presiona G para canjear.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == cashingArea) // Detectar salida del área de canje
        {
            isInsideCashingArea = false;
            Debug.Log("Saliste del área de canje.");
        }
    }

    private void CashBales()
    {
        if (baleCount > 0)
        {
            int earnedMoney = baleCount * baleValue;
            money += earnedMoney;
            Debug.Log($"Fardos canjeados: {baleCount}. Dinero ganado: {earnedMoney}. Dinero total: {money}");
            baleCount = 0; // Resetear el contador de fardos
        }
        else
        {
            Debug.Log("No tienes fardos para canjear.");
        }
    }

    private void UpdateUI()
    {
        // Actualizar los textos en pantalla
        if (baleCounterText != null)
        {
            baleCounterText.text = $"Fardos: {baleCount}";
        }

        if (moneyText != null)
        {
            moneyText.text = $"Dinero: ${money}";
        }
    }
}
*/
/*using UnityEngine;
using TMPro;

public class TruckController : MonoBehaviour
{
    public string strawBaleTag = "StrawBale"; // Tag para identificar los fardos de paja
    public int baleCount = 0; // Contador de fardos recogidos
    public int money = 0; // Total de dinero acumulado
    public int moneyPerBale = 10; // Valor de dinero que representa cada fardo
    public float speed = 12f; // Velocidad de movimiento
    public float turnSpeed = 45f; // Velocidad de giro
    public TextMeshProUGUI baleCounterText; // Texto en pantalla para mostrar la cantidad de fardos
    public TextMeshProUGUI moneyText; // Texto en pantalla para mostrar el dinero
    public GameObject cashZone; // Zona donde se pueden canjear los fardos

    private bool inCashZone = false; // Verifica si estás en la zona de canje

    private void Update()
    {
        // Movimiento del vehículo
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime; // Avanzar/retroceder
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime; // Girar

        transform.Translate(Vector3.forward * move);
        transform.Rotate(Vector3.up * turn);

        // Canjear fardos al presionar "G" si estás en la zona de canje
        if (inCashZone && Input.GetKeyDown(KeyCode.G))
        {
            CashBales();
        }

        // Actualizar la interfaz
        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Recoger fardos de paja
        if (other.CompareTag(strawBaleTag))
        {
            baleCount++;
            Debug.Log($"Fardo recogido. Total: {baleCount}");
            Destroy(other.gameObject);
        }

        // Detectar entrada a la zona de canje
        if (other.gameObject == cashZone)
        {
            inCashZone = true;
            Debug.Log("Entraste a la zona de canje.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Detectar salida de la zona de canje
        if (other.gameObject == cashZone)
        {
            inCashZone = false;
            Debug.Log("Saliste de la zona de canje.");
        }
    }

    private void CashBales()
    {
        if (baleCount > 0)
        {
            int earnedMoney = baleCount * moneyPerBale; // Calcula el dinero obtenido
            money += earnedMoney; // Incrementa el total de dinero
            Debug.Log($"Fardos canjeados: {baleCount}. Dinero ganado: {earnedMoney}. Dinero total: {money}");
            baleCount = 0; // Reinicia el contador de fardos
        }
        else
        {
            Debug.Log("No tienes fardos para canjear.");
        }
    }

    private void UpdateUI()
    {
        if (baleCounterText != null)
        {
            baleCounterText.text = $"Fardos: {baleCount}";
        }

        if (moneyText != null)
        {
            moneyText.text = $"Dinero: ${money}";
        }
    }
}
*/
/*using UnityEngine;
using TMPro;

public class TruckController : MonoBehaviour
{
    public string strawBaleTag = "StrawBale"; // Tag para identificar los fardos de paja
    public int baleCount = 0; // Contador de fardos recogidos
    public int money = 0; // Total de dinero acumulado
    public int moneyPerBale = 10; // Valor de dinero que representa cada fardo
    public float speed = 12f; // Velocidad de movimiento
    public float turnSpeed = 45f; // Velocidad de giro
    public TextMeshProUGUI baleCounterText; // Texto en pantalla para mostrar la cantidad de fardos
    public TextMeshProUGUI moneyText; // Texto en pantalla para mostrar el dinero
    public GameObject cashZone; // Zona donde se pueden canjear los fardos

    private bool inCashZone = false; // Verifica si estás en la zona de canje

    private void Update()
    {
        // Movimiento del vehículo
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime; // Avanzar/retroceder
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime; // Girar

        transform.Translate(Vector3.forward * move);
        transform.Rotate(Vector3.up * turn);

        // Canjear fardos al presionar "G" si estás en la zona de canje
        if (inCashZone && Input.GetKeyDown(KeyCode.G))
        {
            CashBales();
        }

        // Actualizar la interfaz
        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Recoger fardos de paja
        if (other.CompareTag(strawBaleTag))
        {
            baleCount++;
            Debug.Log($"Fardo recogido. Total: {baleCount}");
            Destroy(other.gameObject);
        }

        // Detectar entrada a la zona de canje
        if (other.gameObject == cashZone)
        {
            inCashZone = true;
            Debug.Log("Entraste a la zona de canje.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Detectar salida de la zona de canje
        if (other.gameObject == cashZone)
        {
            inCashZone = false;
            Debug.Log("Saliste de la zona de canje.");
        }
    }

    private void CashBales()
    {
        if (baleCount > 0)
        {
            int earnedMoney = baleCount * moneyPerBale; // Calcula el dinero obtenido
            money += earnedMoney; // Incrementa el total de dinero
            Debug.Log($"Fardos canjeados: {baleCount}. Dinero ganado: {earnedMoney}. Dinero total: {money}");
            baleCount = 0; // Reinicia el contador de fardos
            UpdateUI(); // Asegura que los textos se actualicen tras el canje
        }
        else
        {
            Debug.Log("No tienes fardos para canjear.");
        }
    }

    private void UpdateUI()
    {
        if (baleCounterText != null)
        {
            baleCounterText.text = $"Fardos: {baleCount}";
        }

        if (moneyText != null)
        {
            moneyText.text = $"Dinero: ${money}";
        }
    }
}
*/
using UnityEngine;
using TMPro;

public class TruckController : MonoBehaviour
{
    public string strawBaleTag = "StrawBale"; // Tag para identificar los fardos de paja
    public int money = 0; // Total de dinero acumulado
    public int moneyPerBale = 10; // Valor de dinero que representa cada fardo
    public float speed = 12f; // Velocidad de movimiento
    public float turnSpeed = 45f; // Velocidad de giro
    public TextMeshProUGUI moneyText; // Texto en pantalla para mostrar el dinero

    private void Update()
    {
        // Movimiento del vehículo
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime; // Avanzar/retroceder
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime; // Girar

        transform.Translate(Vector3.forward * move);
        transform.Rotate(Vector3.up * turn);

        // Actualizar la interfaz
        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Recoger fardos de paja y ganar dinero automáticamente
        if (other.CompareTag(strawBaleTag))
        {
            money += moneyPerBale; // Incrementa el total de dinero
            Debug.Log($"Fardo recogido. Dinero ganado: {moneyPerBale}. Dinero total: {money}");
            Destroy(other.gameObject); // Destruye el fardo
            UpdateUI(); // Asegura que el texto se actualice tras recoger el fardo
        }
    }

    private void UpdateUI()
    {
        if (moneyText != null)
        {
            moneyText.text = $"Dinero: ${money}";
        }
    }
}
