
/*using UnityEngine;

public class VehicleInteraction : MonoBehaviour
{
    public Transform playerSeat; // El asiento donde el jugador se coloca
    public GameObject vehicleCamera; // Cámara del vehículo
    public GameObject playerCamera; // Cámara del jugador
    public MonoBehaviour playerControllerScript; // Controlador del jugador
    public VehicleControl vehicleControlScript; // Script del vehículo

    private Transform player; // Referencia al jugador
    private bool isPlayerInVehicle = false;

    void Start()
    {
        if (vehicleCamera != null)
            vehicleCamera.SetActive(false); // Desactiva la cámara del vehículo al inicio

        if (vehicleControlScript != null)
            vehicleControlScript.enabled = false; // Desactiva el control del vehículo al inicio
    }

    void Update()
    {
        if (isPlayerInVehicle && Input.GetKeyDown(KeyCode.F))
        {
            ExitVehicle();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F) && !isPlayerInVehicle)
        {
            EnterVehicle();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }

    private void EnterVehicle()
    {
        if (player == null || playerControllerScript == null) return;

        // Desactivar el control del jugador y su cámara
        playerControllerScript.enabled = false;
        if (playerCamera != null)
            playerCamera.SetActive(false);

        // Anclar al jugador al asiento
        player.SetParent(playerSeat);
        player.position = playerSeat.position;
        player.rotation = playerSeat.rotation;

        // Activar la cámara y el control del vehículo
        if (vehicleCamera != null)
            vehicleCamera.SetActive(true);

        if (vehicleControlScript != null)
            vehicleControlScript.enabled = true;

        isPlayerInVehicle = true;
    }

    private void ExitVehicle()
    {
        if (player == null || playerControllerScript == null) return;

        // Reactivar el control del jugador y su cámara
        playerControllerScript.enabled = true;
        if (playerCamera != null)
            playerCamera.SetActive(true);

        // Liberar al jugador
        player.SetParent(null);
        player.position = transform.position + Vector3.up; // Colocar cerca del vehículo

        // Desactivar la cámara y el control del vehículo
        if (vehicleCamera != null)
            vehicleCamera.SetActive(false);

        if (vehicleControlScript != null)
            vehicleControlScript.enabled = false;

        isPlayerInVehicle = false;
    }
}
*/
/*using UnityEngine;

public class VehicleInteraction : MonoBehaviour
{
    public Transform playerSeat; // El asiento donde el jugador se coloca
    public GameObject vehicleCamera; // Cámara del vehículo
    public GameObject playerCamera; // Cámara del jugador
    public MonoBehaviour playerControllerScript; // Script de control del jugador
    public VehicleControl vehicleControlScript; // Script del control del vehículo
    public GameObject interactionArea; // Área de interacción para detectar al jugador

    private Transform player; // Referencia al jugador
    private bool isPlayerInVehicle = false;

    void Start()
    {
        if (vehicleCamera != null)
            vehicleCamera.SetActive(false); // Desactiva la cámara del vehículo al inicio

        if (vehicleControlScript != null)
            vehicleControlScript.enabled = false; // Desactiva el control del vehículo al inicio

        if (interactionArea != null && interactionArea.GetComponent<Collider>() != null)
            interactionArea.GetComponent<Collider>().isTrigger = true; // Asegura que sea un Trigger
    }

    void Update()
    {
        if (isPlayerInVehicle && Input.GetKeyDown(KeyCode.F))
        {
            ExitVehicle();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F) && !isPlayerInVehicle)
        {
            EnterVehicle();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }

    private void EnterVehicle()
    {
        if (player == null || playerControllerScript == null) return;

        // Desactivar el control del jugador y su cámara
        playerControllerScript.enabled = false;
        if (playerCamera != null)
            playerCamera.SetActive(false);

        // Anclar al jugador al asiento
        player.SetParent(playerSeat);
        player.position = playerSeat.position;
        player.rotation = playerSeat.rotation;

        // Activar la cámara y el control del vehículo
        if (vehicleCamera != null)
            vehicleCamera.SetActive(true);

        if (vehicleControlScript != null)
            vehicleControlScript.enabled = true;

        isPlayerInVehicle = true;
    }

    private void ExitVehicle()
    {
        if (player == null || playerControllerScript == null) return;

        // Reactivar el control del jugador y su cámara
        playerControllerScript.enabled = true;
        if (playerCamera != null)
            playerCamera.SetActive(true);

        // Liberar al jugador
        player.SetParent(null);
        player.position = transform.position + Vector3.up; // Colocar cerca del vehículo

        // Desactivar la cámara y el control del vehículo
        if (vehicleCamera != null)
            vehicleCamera.SetActive(false);

        if (vehicleControlScript != null)
            vehicleControlScript.enabled = false;

        isPlayerInVehicle = false;
    }
}
*/
/*using UnityEngine;

public class VehicleInteraction : MonoBehaviour
{
    public Transform playerSeat; // El asiento del vehículo
    public GameObject vehicleCamera; // Cámara del vehículo
    public GameObject playerCamera; // Cámara del jugador
    public MonoBehaviour playerControllerScript; // Script del control del jugador
    public MonoBehaviour vehicleControlScript; // Script del control del vehículo
    public GameObject interactionArea; // Área de interacción para detectar al jugador

    private Transform player; // Referencia al jugador
    private bool isPlayerInVehicle = false;

    void Start()
    {
        if (vehicleCamera != null)
            vehicleCamera.SetActive(false); // Desactiva la cámara del vehículo al inicio

        if (vehicleControlScript != null)
            vehicleControlScript.enabled = false; // Desactiva el control del vehículo al inicio

        if (interactionArea != null)
        {
            Collider collider = interactionArea.GetComponent<Collider>();
            if (collider != null)
                collider.isTrigger = true; // Asegura que el área de interacción sea un Trigger
        }
    }

    void Update()
    {
        if (player != null && Input.GetKeyDown(KeyCode.F))
        {
            if (isPlayerInVehicle)
            {
                ExitVehicle();
            }
            else
            {
                EnterVehicle();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform; // Detecta al jugador
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null; // Borra la referencia al jugador cuando sale del área de interacción
        }
    }

   private void EnterVehicle()
    {
        if (player == null || playerControllerScript == null) return;

        // Desactivar el control del jugador y su cámara
        playerControllerScript.enabled = false;
        if (playerCamera != null)
            playerCamera.SetActive(false);

        // Anclar al jugador al asiento
        player.SetParent(playerSeat);
        player.position = playerSeat.position;
        player.rotation = playerSeat.rotation;

        // Activar la cámara y el control del vehículo
        if (vehicleCamera != null)
            vehicleCamera.SetActive(true);

        if (vehicleControlScript != null)
            vehicleControlScript.enabled = true;

        isPlayerInVehicle = true;
    }
    
    private void ExitVehicle()
    {
        if (player == null || playerControllerScript == null) return;

        // Reactivar el control del jugador y su cámara
        playerControllerScript.enabled = true;
        if (playerCamera != null)
            playerCamera.SetActive(true);

        // Liberar al jugador
        player.SetParent(null);
        player.position = transform.position + Vector3.up; // Colocar cerca del vehículo

        // Desactivar la cámara y el control del vehículo
        if (vehicleCamera != null)
            vehicleCamera.SetActive(false);

        if (vehicleControlScript != null)
            vehicleControlScript.enabled = false;

        isPlayerInVehicle = false;
    }
    

}

*/
/*using UnityEngine;

public class VehicleInteraction : MonoBehaviour
{
    public Transform playerSeat; // El asiento del vehículo
    public GameObject vehicleCamera; // Cámara del vehículo
    public GameObject playerCamera; // Cámara del jugador
    public MonoBehaviour playerControllerScript; // Script del control del jugador
    public MonoBehaviour vehicleControlScript; // Script del control del vehículo
    public GameObject interactionArea; // Área de interacción para detectar al jugador

    private Transform player; // Referencia al jugador
    private bool isPlayerInVehicle = false;

    void Start()
    {
        if (vehicleCamera != null)
            vehicleCamera.SetActive(false); // Desactiva la cámara del vehículo al inicio

        if (vehicleControlScript != null)
            vehicleControlScript.enabled = false; // Desactiva el control del vehículo al inicio

        if (interactionArea != null)
        {
            Collider collider = interactionArea.GetComponent<Collider>();
            if (collider != null)
                collider.isTrigger = true; // Asegura que el área de interacción sea un Trigger
        }
    }

    void Update()
    {
        if (player != null && Input.GetKeyDown(KeyCode.F))
        {
            if (isPlayerInVehicle)
            {
                if (IsPlayerInsideInteractionArea()) // Verifica si el jugador está dentro del área de interacción
                {
                    ExitVehicle();
                }
            }
            else
            {
                EnterVehicle();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform; // Detecta al jugador
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null; // Borra la referencia al jugador cuando sale del área de interacción
        }
    }

    private void EnterVehicle()
    {
        if (player == null || playerControllerScript == null) return;

        // Desactivar el control del jugador y su cámara
        playerControllerScript.enabled = false;
        if (playerCamera != null)
            playerCamera.SetActive(false);

        // Anclar al jugador al asiento
        player.SetParent(playerSeat);
        player.position = playerSeat.position;
        player.rotation = playerSeat.rotation;

        // Activar la cámara y el control del vehículo
        if (vehicleCamera != null)
            vehicleCamera.SetActive(true);

        if (vehicleControlScript != null)
            vehicleControlScript.enabled = true;

        isPlayerInVehicle = true;
    }

    private void ExitVehicle()
    {
        if (player == null || playerControllerScript == null) return;

        // Reactivar el control del jugador y su cámara
        playerControllerScript.enabled = true;
        if (playerCamera != null)
            playerCamera.SetActive(true);

        // Liberar al jugador
        player.SetParent(null);
        player.position = transform.position + Vector3.right * 2; // Colocar al jugador a un lado del vehículo

        // Desactivar la cámara y el control del vehículo
        if (vehicleCamera != null)
            vehicleCamera.SetActive(false);

        if (vehicleControlScript != null)
            vehicleControlScript.enabled = false;

        isPlayerInVehicle = false;
    }

    private bool IsPlayerInsideInteractionArea()
    {
        if (interactionArea == null || player == null) return false;

        Collider collider = interactionArea.GetComponent<Collider>();
        if (collider != null)
        {
            return collider.bounds.Contains(player.position);
        }

        return false;
    }
}
*/
using UnityEngine;

public class VehicleInteraction : MonoBehaviour
{
    public Transform playerSeat; // Asiento del vehículo
    public GameObject vehicleCamera; // Cámara del vehículo
    public GameObject playerCamera; // Cámara del jugador
    public MonoBehaviour playerControllerScript; // Script del control del jugador
    public MonoBehaviour vehicleControlScript; // Script del control del vehículo
    public GameObject interactionArea; // Área de interacción para detectar al jugador

    private Transform player; // Referencia al jugador
    private bool isPlayerInVehicle = false;

    void Start()
    {
        if (vehicleCamera != null)
            vehicleCamera.SetActive(false); // Desactiva la cámara del vehículo al inicio

        if (vehicleControlScript != null)
            vehicleControlScript.enabled = false; // Desactiva el control del vehículo al inicio

        if (interactionArea != null)
        {
            Collider collider = interactionArea.GetComponent<Collider>();
            if (collider != null)
                collider.isTrigger = true; // Asegura que el área de interacción sea un Trigger
        }
    }

    void Update()
    {
        if (player == null) return;

        // Acción de subir o bajar con la tecla F
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isPlayerInVehicle)
            {
                HandleExitVehicle();
            }
            else
            {
                HandleEnterVehicle();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform; // Detecta al jugador
            Debug.Log("Jugador detectado en el área de interacción.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isPlayerInVehicle) // Solo borra referencia si no está en el vehículo
            {
                player = null;
                Debug.Log("Jugador salió del área de interacción.");
            }
        }
    }

    private void HandleEnterVehicle()
    {
        if (player == null) return;

        Debug.Log("Subiendo al vehículo...");

        // Desactiva el control del jugador y su cámara
        if (playerControllerScript != null)
            playerControllerScript.enabled = false;

        if (playerCamera != null)
            playerCamera.SetActive(false);

        // Ancla al jugador al asiento
        player.SetParent(playerSeat);
        player.position = playerSeat.position;
        player.rotation = playerSeat.rotation;

        // Activa el control del vehículo y su cámara
        if (vehicleControlScript != null)
            vehicleControlScript.enabled = true;

        if (vehicleCamera != null)
            vehicleCamera.SetActive(true);

        isPlayerInVehicle = true;
    }

    private void HandleExitVehicle()
    {
        if (player == null) return;

        Debug.Log("Bajando del vehículo...");

        // Reactiva el control del jugador y su cámara
        if (playerControllerScript != null)
            playerControllerScript.enabled = true;

        if (playerCamera != null)
            playerCamera.SetActive(true);

        // Libera al jugador del asiento
        player.SetParent(null);
        player.position = transform.position + Vector3.right * 2; // Lo coloca al lado del vehículo

        // Desactiva el control del vehículo y su cámara
        if (vehicleControlScript != null)
            vehicleControlScript.enabled = false;

        if (vehicleCamera != null)
            vehicleCamera.SetActive(false);

        isPlayerInVehicle = false;
    }
}
