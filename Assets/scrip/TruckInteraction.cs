/*using UnityEngine;

public class TruckInteraction : MonoBehaviour
{
    public GameObject player; // Objeto del jugador
    public GameObject truck; // Camioneta
    public Transform seatPosition; // Posici�n del asiento de la camioneta
    public Camera playerCamera; // C�mara del jugador
    public Camera truckCamera; // C�mara de la camioneta
    public KeyCode interactKey = KeyCode.E; // Tecla para subir al cami�n
    public KeyCode exitKey = KeyCode.F; // Tecla para bajar del cami�n
    public Collider interactionZone; // Zona de interacci�n de la camioneta
    public MonoBehaviour playerMovementScript; // Script que controla el movimiento del jugador
    public TruckController truckController; // Script que controla el movimiento de la camioneta

    private bool isInsideTruck = false;

    private void Start()
    {
        truckCamera.gameObject.SetActive(false); // Desactivar c�mara de la camioneta
        truckController.enabled = false; // Desactivar control de la camioneta por defecto
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactKey) && !isInsideTruck && IsPlayerInInteractionZone())
        {
            EnterTruck();
        }
        else if (Input.GetKeyDown(exitKey) && isInsideTruck)
        {
            ExitTruck();
        }
    }

    private bool IsPlayerInInteractionZone()
    {
        return interactionZone.bounds.Contains(player.transform.position); // Verificar si el jugador est� cerca del cami�n
    }

    private void EnterTruck()
    {
        isInsideTruck = true;

        // Ajustar posici�n y rotaci�n del jugador en el asiento
        player.transform.position = seatPosition.position;
        player.transform.rotation = seatPosition.rotation;
        player.transform.SetParent(truck.transform);

        // Desactivar movimiento del jugador
        playerMovementScript.enabled = false;

        // Ajustar c�maras
        playerCamera.gameObject.SetActive(false);
        truckCamera.gameObject.SetActive(true);

        // Activar control de la camioneta
        truckController.enabled = true;

        Debug.Log("Jugador subi� al cami�n.");
    }

    private void ExitTruck()
    {
        isInsideTruck = false;

        // Separar al jugador del cami�n
        player.transform.SetParent(null);
        player.transform.position = truck.transform.position + Vector3.right * 2; // Mover al jugador al lado del cami�n

        // Reactivar movimiento del jugador
        playerMovementScript.enabled = true;

        // Ajustar c�maras
        playerCamera.gameObject.SetActive(true);
        truckCamera.gameObject.SetActive(false);

        // Desactivar control de la camioneta
        truckController.enabled = false;

        Debug.Log("Jugador sali� del cami�n.");
    }
}
*/
/*using UnityEngine;

public class TruckInteraction : MonoBehaviour
{
    public GameObject player; // Objeto del jugador
    public GameObject truck; // Camioneta
    public Transform seatPosition; // Posici�n del asiento de la camioneta
    public Camera playerCamera; // C�mara del jugador
    public Camera truckCamera; // C�mara de la camioneta
    public KeyCode interactKey = KeyCode.E; // Tecla para subir al cami�n
    public KeyCode exitKey = KeyCode.F; // Tecla para bajar del cami�n
    public Collider interactionZone; // Zona de interacci�n de la camioneta
    public MonoBehaviour playerMovementScript; // Script que controla el movimiento del jugador
    public TruckController truckController; // Script que controla el movimiento de la camioneta

    private bool isInsideTruck = false;
    private Rigidbody playerRigidbody; // Referencia al Rigidbody del jugador
    private Collider playerCollider; // Referencia al Collider del jugador

    private void Start()
    {
        truckCamera.gameObject.SetActive(false); // Desactivar c�mara de la camioneta
        truckController.enabled = false; // Desactivar control de la camioneta por defecto

        // Obtener componentes del jugador
        playerRigidbody = player.GetComponent<Rigidbody>();
        playerCollider = player.GetComponent<Collider>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactKey) && !isInsideTruck && IsPlayerInInteractionZone())
        {
            EnterTruck();
        }
        else if (Input.GetKeyDown(exitKey) && isInsideTruck)
        {
            ExitTruck();
        }
    }

    private bool IsPlayerInInteractionZone()
    {
        return interactionZone.bounds.Contains(player.transform.position); // Verificar si el jugador est� cerca del cami�n
    }

    private void EnterTruck()
    {
        isInsideTruck = true;

        // Ajustar posici�n y rotaci�n del jugador en el asiento
        player.transform.position = seatPosition.position;
        player.transform.rotation = seatPosition.rotation;
        player.transform.SetParent(truck.transform);

        // Desactivar movimiento del jugador
        playerMovementScript.enabled = false;

        // Ajustar c�maras
        playerCamera.gameObject.SetActive(false);
        truckCamera.gameObject.SetActive(true);

        // Desactivar f�sicas del jugador
        if (playerRigidbody != null)
        {
            playerRigidbody.isKinematic = true;
        }

        // Desactivar colisiones del jugador
        if (playerCollider != null)
        {
            playerCollider.enabled = false;
        }

        // Activar control de la camioneta
        truckController.enabled = true;

        Debug.Log("Jugador subi� al cami�n.");
    }

    private void ExitTruck()
    {
        isInsideTruck = false;

        // Separar al jugador del cami�n
        player.transform.SetParent(null);
        player.transform.position = truck.transform.position + Vector3.right * 2; // Mover al jugador al lado del cami�n

        // Reactivar movimiento del jugador
        playerMovementScript.enabled = true;

        // Ajustar c�maras
        playerCamera.gameObject.SetActive(true);
        truckCamera.gameObject.SetActive(false);

        // Reactivar f�sicas del jugador
        if (playerRigidbody != null)
        {
            playerRigidbody.isKinematic = false;
        }

        // Reactivar colisiones del jugador
        if (playerCollider != null)
        {
            playerCollider.enabled = true;
        }

        // Desactivar control de la camioneta
        truckController.enabled = false;

        Debug.Log("Jugador sali� del cami�n.");
    }
}
*/
using UnityEngine;

public class TruckInteraction : MonoBehaviour
{
    public GameObject player; // Objeto del jugador
    public GameObject truck; // Camioneta
    public Transform seatPosition; // Posici�n del asiento de la camioneta
    public Camera playerCamera; // C�mara del jugador
    public Camera truckCamera; // C�mara de la camioneta
    public KeyCode interactKey = KeyCode.E; // Tecla para subir al cami�n
    public KeyCode exitKey = KeyCode.F; // Tecla para bajar del cami�n
    public Collider interactionZone; // Zona de interacci�n de la camioneta
    public MonoBehaviour playerMovementScript; // Script que controla el movimiento del jugador
    public TruckController truckController; // Script que controla el movimiento de la camioneta

    private bool isInsideTruck = false;
    private Rigidbody playerRigidbody; // Referencia al Rigidbody del jugador
    private Collider playerCollider; // Referencia al Collider del jugador

    // Contador de fardos recogidos
    private int baleCount = 0;

    private void Start()
    {
        truckCamera.gameObject.SetActive(false); // Desactivar c�mara de la camioneta
        truckController.enabled = false; // Desactivar control de la camioneta por defecto

        // Obtener componentes del jugador
        playerRigidbody = player.GetComponent<Rigidbody>();
        playerCollider = player.GetComponent<Collider>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactKey) && !isInsideTruck && IsPlayerInInteractionZone())
        {
            EnterTruck();
        }
        else if (Input.GetKeyDown(exitKey) && isInsideTruck)
        {
            ExitTruck();
        }
    }

    private bool IsPlayerInInteractionZone()
    {
        return interactionZone.bounds.Contains(player.transform.position); // Verificar si el jugador est� cerca del cami�n
    }

    private void EnterTruck()
    {
        isInsideTruck = true;

        // Ajustar posici�n y rotaci�n del jugador en el asiento
        player.transform.position = seatPosition.position;
        player.transform.rotation = seatPosition.rotation;
        player.transform.SetParent(truck.transform);

        // Desactivar movimiento del jugador
        playerMovementScript.enabled = false;

        // Ajustar c�maras
        playerCamera.gameObject.SetActive(false);
        truckCamera.gameObject.SetActive(true);

        // Desactivar f�sicas del jugador
        if (playerRigidbody != null)
        {
            playerRigidbody.isKinematic = true;
        }

        // Desactivar colisiones del jugador
        if (playerCollider != null)
        {
            playerCollider.enabled = false;
        }

        // Activar control de la camioneta
        truckController.enabled = true;

        Debug.Log("Jugador subi� al cami�n.");
    }

    private void ExitTruck()
    {
        isInsideTruck = false;

        // Separar al jugador del cami�n
        player.transform.SetParent(null);
        player.transform.position = truck.transform.position + Vector3.right * 2; // Mover al jugador al lado del cami�n

        // Reactivar movimiento del jugador
        playerMovementScript.enabled = true;

        // Ajustar c�maras
        playerCamera.gameObject.SetActive(true);
        truckCamera.gameObject.SetActive(false);

        // Reactivar f�sicas del jugador
        if (playerRigidbody != null)
        {
            playerRigidbody.isKinematic = false;
        }

        // Reactivar colisiones del jugador
        if (playerCollider != null)
        {
            playerCollider.enabled = true;
        }

        // Desactivar control de la camioneta
        truckController.enabled = false;

        Debug.Log("Jugador sali� del cami�n.");
    }

    // M�todo de colisi�n con fardos de paja
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fardo")) // Si colisiona con un fardo
        {
            baleCount++; // Incrementa el contador de fardos recogidos
            Debug.Log($"Fardo recogido. Total: {baleCount}");

            // Destruir el fardo despu�s de recogerlo
            Destroy(other.gameObject);
        }
    }
}
