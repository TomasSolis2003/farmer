/*using UnityEngine;

public class VehicleInteraction : MonoBehaviour
{
    public GameObject player; // El objeto del jugador
    public GameObject vehicle; // El veh�culo
    public Transform seatPosition; // Posici�n del asiento en el veh�culo
    public KeyCode interactKey = KeyCode.E; // Tecla para interactuar
    public KeyCode exitKey = KeyCode.F; // Tecla para salir del veh�culo
    private bool isInsideVehicle = false;

    private void Update()
    {
        if (Input.GetKeyDown(interactKey) && !isInsideVehicle)
        {
            // Intentar subirse al veh�culo
            if (Vector3.Distance(player.transform.position, vehicle.transform.position) < 3f) // Distancia de interacci�n
            {
                EnterVehicle();
            }
        }
        else if (Input.GetKeyDown(exitKey) && isInsideVehicle)
        {
            ExitVehicle();
        }
    }

    private void EnterVehicle()
    {
        isInsideVehicle = true;
        player.SetActive(false); // Desactivar el jugador
        player.transform.position = seatPosition.position; // Mover al asiento
        player.transform.SetParent(vehicle.transform); // Hacer al jugador hijo del veh�culo
        vehicle.GetComponent<VehicleController>().enabled = true; // Activar el controlador del veh�culo
    }

    private void ExitVehicle()
    {
        isInsideVehicle = false;
        player.SetActive(true); // Reactivar el jugador
        player.transform.SetParent(null); // Separar del veh�culo
        player.transform.position = vehicle.transform.position + Vector3.right * 2; // Mover al lado del veh�culo
        vehicle.GetComponent<VehicleController>().enabled = false; // Desactivar el controlador del veh�culo
    }
}
*/
/*using UnityEngine;

public class VehicleInteraction : MonoBehaviour
{
    public GameObject player; // Objeto del jugador
    public GameObject vehicle; // Veh�culo
    public Transform seatPosition; // Posici�n del asiento
    public Camera playerCamera; // C�mara del jugador
    public Camera vehicleCamera; // C�mara del veh�culo
    public KeyCode interactKey = KeyCode.E; // Tecla para interactuar
    public KeyCode exitKey = KeyCode.F; // Tecla para salir del veh�culo
    private bool isInsideVehicle = false;

    private void Start()
    {
        vehicleCamera.gameObject.SetActive(false); // Asegurarse de que la c�mara del veh�culo est� desactivada
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactKey) && !isInsideVehicle)
        {
            if (Vector3.Distance(player.transform.position, vehicle.transform.position) < 3f)
            {
                EnterVehicle();
            }
        }
        else if (Input.GetKeyDown(exitKey) && isInsideVehicle)
        {
            ExitVehicle();
        }
    }

    private void EnterVehicle()
    {
        isInsideVehicle = true;
        player.transform.position = seatPosition.position; // Mover al asiento
        player.transform.rotation = seatPosition.rotation; // Ajustar orientaci�n
        player.transform.SetParent(vehicle.transform); // Anclar al veh�culo

        playerCamera.gameObject.SetActive(false); // Desactivar c�mara del jugador
        vehicleCamera.gameObject.SetActive(true); // Activar c�mara del veh�culo

        vehicle.GetComponent<VehicleController>().enabled = true; // Activar controlador del veh�culo
    }

    private void ExitVehicle()
    {
        isInsideVehicle = false;
        player.transform.SetParent(null); // Separar del veh�culo
        player.transform.position = vehicle.transform.position + Vector3.right * 2; // Mover al lado del veh�culo

        playerCamera.gameObject.SetActive(true); // Reactivar c�mara del jugador
        vehicleCamera.gameObject.SetActive(false); // Desactivar c�mara del veh�culo

        vehicle.GetComponent<VehicleController>().enabled = false; // Desactivar controlador del veh�culo
    }
}
*/
/*using UnityEngine;

public class VehicleInteraction : MonoBehaviour
{
    public GameObject player; // Objeto del jugador
    public GameObject vehicle; // Veh�culo
    public Transform seatPosition; // Posici�n del asiento
    public Camera playerCamera; // C�mara del jugador
    public Camera vehicleCamera; // C�mara del veh�culo
    public KeyCode interactKey = KeyCode.E; // Tecla para interactuar
    public KeyCode exitKey = KeyCode.F; // Tecla para salir del veh�culo
    public Collider interactionZone; // Zona de interacci�n del veh�culo
    private bool isInsideVehicle = false;
    private CharacterController playerController;

    private void Start()
    {
        vehicleCamera.gameObject.SetActive(false); // Desactivar la c�mara del veh�culo
        playerController = player.GetComponent<CharacterController>(); // Obtener el controlador del jugador
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactKey) && !isInsideVehicle && IsPlayerInInteractionZone())
        {
            EnterVehicle();
        }
        else if (Input.GetKeyDown(exitKey) && isInsideVehicle)
        {
            ExitVehicle();
        }
    }

    private bool IsPlayerInInteractionZone()
    {
        return interactionZone.bounds.Contains(player.transform.position); // Verificar si el jugador est� dentro del collider
    }

    private void EnterVehicle()
    {
        isInsideVehicle = true;

        // Ajustar el jugador
        player.transform.position = seatPosition.position;
        player.transform.rotation = seatPosition.rotation;
        player.transform.SetParent(vehicle.transform);
        playerController.enabled = false; // Desactivar movimiento del jugador

        // Ajustar c�maras
        playerCamera.gameObject.SetActive(false);
        vehicleCamera.gameObject.SetActive(true);

        // Activar el veh�culo
        vehicle.GetComponent<VehicleController>().enabled = true;

        // Desactivar movimiento f�sico del veh�culo mientras est� en uso
        Rigidbody rb = vehicle.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }

    private void ExitVehicle()
    {
        isInsideVehicle = false;

        // Separar el jugador
        player.transform.SetParent(null);
        player.transform.position = vehicle.transform.position + Vector3.right * 2; // Mover al lado del veh�culo
        playerController.enabled = true; // Reactivar movimiento del jugador

        // Ajustar c�maras
        playerCamera.gameObject.SetActive(true);
        vehicleCamera.gameObject.SetActive(false);

        // Desactivar el veh�culo
        vehicle.GetComponent<VehicleController>().enabled = false;

        // Congelar el veh�culo cuando no est� en uso
        Rigidbody rb = vehicle.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
}
*/
/*using UnityEngine;

public class VehicleInteraction : MonoBehaviour
{
    public GameObject player; // Objeto del jugador
    public GameObject vehicle; // Veh�culo
    public Transform seatPosition; // Posici�n del asiento
    public Camera playerCamera; // C�mara del jugador
    public Camera vehicleCamera; // C�mara del veh�culo
    public KeyCode interactKey = KeyCode.E; // Tecla para interactuar
    public KeyCode exitKey = KeyCode.F; // Tecla para salir del veh�culo
    public Collider interactionZone; // Zona de interacci�n del veh�culo
    public MonoBehaviour playerMovementScript; // Script que controla el movimiento del jugador
    private bool isInsideVehicle = false;

    private void Start()
    {
        vehicleCamera.gameObject.SetActive(false); // Desactivar la c�mara del veh�culo
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactKey) && !isInsideVehicle && IsPlayerInInteractionZone())
        {
            EnterVehicle();
        }
        else if (Input.GetKeyDown(exitKey) && isInsideVehicle)
        {
            ExitVehicle();
        }
    }

    private bool IsPlayerInInteractionZone()
    {
        return interactionZone.bounds.Contains(player.transform.position); // Verificar si el jugador est� dentro del collider
    }

    private void EnterVehicle()
    {
        isInsideVehicle = true;

        // Ajustar el jugador
        player.transform.position = seatPosition.position;
        player.transform.rotation = seatPosition.rotation;
        player.transform.SetParent(vehicle.transform);

        // Desactivar movimiento del jugador
        playerMovementScript.enabled = false;

        // Ajustar c�maras
        playerCamera.gameObject.SetActive(false);
        vehicleCamera.gameObject.SetActive(true);

        // Activar el veh�culo
        vehicle.GetComponent<VehicleController>().enabled = true;

        // Desactivar movimiento f�sico del veh�culo mientras est� en uso
        Rigidbody rb = vehicle.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }

    private void ExitVehicle()
    {
        isInsideVehicle = false;

        // Separar el jugador
        player.transform.SetParent(null);
        player.transform.position = vehicle.transform.position + Vector3.right * 2; // Mover al lado del veh�culo

        // Reactivar movimiento del jugador
        playerMovementScript.enabled = true;

        // Ajustar c�maras
        playerCamera.gameObject.SetActive(true);
        vehicleCamera.gameObject.SetActive(false);

        // Desactivar el veh�culo
        vehicle.GetComponent<VehicleController>().enabled = false;

        // Congelar el veh�culo cuando no est� en uso
        Rigidbody rb = vehicle.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
}
*/
using UnityEngine;

public class VehicleInteraction : MonoBehaviour
{
    public GameObject player; // Objeto del jugador
    public GameObject vehicle; // Veh�culo
    public Transform seatPosition; // Posici�n del asiento
    public Camera playerCamera; // C�mara del jugador
    public Camera vehicleCamera; // C�mara del veh�culo
    public KeyCode interactKey = KeyCode.E; // Tecla para interactuar
    public KeyCode exitKey = KeyCode.F; // Tecla para salir del veh�culo
    public Collider interactionZone; // Zona de interacci�n del veh�culo
    public MonoBehaviour playerMovementScript; // Script que controla el movimiento del jugador
    public MonoBehaviour vehicleMovementScript; // Script que controla el movimiento del veh�culo
    private bool isInsideVehicle = false;

    private void Start()
    {
        vehicleCamera.gameObject.SetActive(false); // Desactivar la c�mara del veh�culo
        vehicleMovementScript.enabled = false; // Desactivar movimiento del veh�culo por defecto
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactKey) && !isInsideVehicle && IsPlayerInInteractionZone())
        {
            EnterVehicle();
        }
        else if (Input.GetKeyDown(exitKey) && isInsideVehicle)
        {
            ExitVehicle();
        }
    }

    private bool IsPlayerInInteractionZone()
    {
        return interactionZone.bounds.Contains(player.transform.position); // Verificar si el jugador est� dentro del collider
    }

    private void EnterVehicle()
    {
        isInsideVehicle = true;

        // Ajustar el jugador
        player.transform.position = seatPosition.position;
        player.transform.rotation = seatPosition.rotation;
        player.transform.SetParent(vehicle.transform);

        // Desactivar movimiento del jugador
        playerMovementScript.enabled = false;

        // Ajustar c�maras
        playerCamera.gameObject.SetActive(false);
        vehicleCamera.gameObject.SetActive(true);

        // Activar el movimiento del veh�culo
        vehicleMovementScript.enabled = true;

        // Desactivar movimiento f�sico del veh�culo mientras est� en uso
        Rigidbody rb = vehicle.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }

    private void ExitVehicle()
    {
        isInsideVehicle = false;

        // Separar el jugador
        player.transform.SetParent(null);
        player.transform.position = vehicle.transform.position + Vector3.right * 2; // Mover al lado del veh�culo

        // Reactivar movimiento del jugador
        playerMovementScript.enabled = true;

        // Ajustar c�maras
        playerCamera.gameObject.SetActive(true);
        vehicleCamera.gameObject.SetActive(false);

        // Desactivar el movimiento del veh�culo
        vehicleMovementScript.enabled = false;

        // Congelar el veh�culo cuando no est� en uso
        Rigidbody rb = vehicle.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
}
