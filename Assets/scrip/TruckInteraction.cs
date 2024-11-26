/*using UnityEngine;

public class TruckInteraction : MonoBehaviour
{
    public GameObject player; // Objeto del jugador
    public GameObject truck; // Camioneta
    public Transform seatPosition; // Posición del asiento de la camioneta
    public Camera playerCamera; // Cámara del jugador
    public Camera truckCamera; // Cámara de la camioneta
    public KeyCode interactKey = KeyCode.E; // Tecla para subir al camión
    public KeyCode exitKey = KeyCode.F; // Tecla para bajar del camión
    public Collider interactionZone; // Zona de interacción de la camioneta
    public MonoBehaviour playerMovementScript; // Script que controla el movimiento del jugador
    public TruckController truckController; // Script que controla el movimiento de la camioneta

    private bool isInsideTruck = false;

    private void Start()
    {
        truckCamera.gameObject.SetActive(false); // Desactivar cámara de la camioneta
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
        return interactionZone.bounds.Contains(player.transform.position); // Verificar si el jugador está cerca del camión
    }

    private void EnterTruck()
    {
        isInsideTruck = true;

        // Ajustar posición y rotación del jugador en el asiento
        player.transform.position = seatPosition.position;
        player.transform.rotation = seatPosition.rotation;
        player.transform.SetParent(truck.transform);

        // Desactivar movimiento del jugador
        playerMovementScript.enabled = false;

        // Ajustar cámaras
        playerCamera.gameObject.SetActive(false);
        truckCamera.gameObject.SetActive(true);

        // Activar control de la camioneta
        truckController.enabled = true;

        Debug.Log("Jugador subió al camión.");
    }

    private void ExitTruck()
    {
        isInsideTruck = false;

        // Separar al jugador del camión
        player.transform.SetParent(null);
        player.transform.position = truck.transform.position + Vector3.right * 2; // Mover al jugador al lado del camión

        // Reactivar movimiento del jugador
        playerMovementScript.enabled = true;

        // Ajustar cámaras
        playerCamera.gameObject.SetActive(true);
        truckCamera.gameObject.SetActive(false);

        // Desactivar control de la camioneta
        truckController.enabled = false;

        Debug.Log("Jugador salió del camión.");
    }
}
*/
/*using UnityEngine;

public class TruckInteraction : MonoBehaviour
{
    public GameObject player; // Objeto del jugador
    public GameObject truck; // Camioneta
    public Transform seatPosition; // Posición del asiento de la camioneta
    public Camera playerCamera; // Cámara del jugador
    public Camera truckCamera; // Cámara de la camioneta
    public KeyCode interactKey = KeyCode.E; // Tecla para subir al camión
    public KeyCode exitKey = KeyCode.F; // Tecla para bajar del camión
    public Collider interactionZone; // Zona de interacción de la camioneta
    public MonoBehaviour playerMovementScript; // Script que controla el movimiento del jugador
    public TruckController truckController; // Script que controla el movimiento de la camioneta

    private bool isInsideTruck = false;
    private Rigidbody playerRigidbody; // Referencia al Rigidbody del jugador
    private Collider playerCollider; // Referencia al Collider del jugador

    private void Start()
    {
        truckCamera.gameObject.SetActive(false); // Desactivar cámara de la camioneta
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
        return interactionZone.bounds.Contains(player.transform.position); // Verificar si el jugador está cerca del camión
    }

    private void EnterTruck()
    {
        isInsideTruck = true;

        // Ajustar posición y rotación del jugador en el asiento
        player.transform.position = seatPosition.position;
        player.transform.rotation = seatPosition.rotation;
        player.transform.SetParent(truck.transform);

        // Desactivar movimiento del jugador
        playerMovementScript.enabled = false;

        // Ajustar cámaras
        playerCamera.gameObject.SetActive(false);
        truckCamera.gameObject.SetActive(true);

        // Desactivar físicas del jugador
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

        Debug.Log("Jugador subió al camión.");
    }

    private void ExitTruck()
    {
        isInsideTruck = false;

        // Separar al jugador del camión
        player.transform.SetParent(null);
        player.transform.position = truck.transform.position + Vector3.right * 2; // Mover al jugador al lado del camión

        // Reactivar movimiento del jugador
        playerMovementScript.enabled = true;

        // Ajustar cámaras
        playerCamera.gameObject.SetActive(true);
        truckCamera.gameObject.SetActive(false);

        // Reactivar físicas del jugador
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

        Debug.Log("Jugador salió del camión.");
    }
}
*/
using UnityEngine;

public class TruckInteraction : MonoBehaviour
{
    public GameObject player; // Objeto del jugador
    public GameObject truck; // Camioneta
    public Transform seatPosition; // Posición del asiento de la camioneta
    public Camera playerCamera; // Cámara del jugador
    public Camera truckCamera; // Cámara de la camioneta
    public KeyCode interactKey = KeyCode.E; // Tecla para subir al camión
    public KeyCode exitKey = KeyCode.F; // Tecla para bajar del camión
    public Collider interactionZone; // Zona de interacción de la camioneta
    public MonoBehaviour playerMovementScript; // Script que controla el movimiento del jugador
    public TruckController truckController; // Script que controla el movimiento de la camioneta

    private bool isInsideTruck = false;
    private Rigidbody playerRigidbody; // Referencia al Rigidbody del jugador
    private Collider playerCollider; // Referencia al Collider del jugador

    // Contador de fardos recogidos
    private int baleCount = 0;

    private void Start()
    {
        truckCamera.gameObject.SetActive(false); // Desactivar cámara de la camioneta
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
        return interactionZone.bounds.Contains(player.transform.position); // Verificar si el jugador está cerca del camión
    }

    private void EnterTruck()
    {
        isInsideTruck = true;

        // Ajustar posición y rotación del jugador en el asiento
        player.transform.position = seatPosition.position;
        player.transform.rotation = seatPosition.rotation;
        player.transform.SetParent(truck.transform);

        // Desactivar movimiento del jugador
        playerMovementScript.enabled = false;

        // Ajustar cámaras
        playerCamera.gameObject.SetActive(false);
        truckCamera.gameObject.SetActive(true);

        // Desactivar físicas del jugador
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

        Debug.Log("Jugador subió al camión.");
    }

    private void ExitTruck()
    {
        isInsideTruck = false;

        // Separar al jugador del camión
        player.transform.SetParent(null);
        player.transform.position = truck.transform.position + Vector3.right * 2; // Mover al jugador al lado del camión

        // Reactivar movimiento del jugador
        playerMovementScript.enabled = true;

        // Ajustar cámaras
        playerCamera.gameObject.SetActive(true);
        truckCamera.gameObject.SetActive(false);

        // Reactivar físicas del jugador
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

        Debug.Log("Jugador salió del camión.");
    }

    // Método de colisión con fardos de paja
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fardo")) // Si colisiona con un fardo
        {
            baleCount++; // Incrementa el contador de fardos recogidos
            Debug.Log($"Fardo recogido. Total: {baleCount}");

            // Destruir el fardo después de recogerlo
            Destroy(other.gameObject);
        }
    }
}
