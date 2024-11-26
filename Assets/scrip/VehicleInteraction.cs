/*using UnityEngine;

public class VehicleInteraction : MonoBehaviour
{
    public GameObject player; // El objeto del jugador
    public GameObject vehicle; // El vehículo
    public Transform seatPosition; // Posición del asiento en el vehículo
    public KeyCode interactKey = KeyCode.E; // Tecla para interactuar
    public KeyCode exitKey = KeyCode.F; // Tecla para salir del vehículo
    private bool isInsideVehicle = false;

    private void Update()
    {
        if (Input.GetKeyDown(interactKey) && !isInsideVehicle)
        {
            // Intentar subirse al vehículo
            if (Vector3.Distance(player.transform.position, vehicle.transform.position) < 3f) // Distancia de interacción
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
        player.transform.SetParent(vehicle.transform); // Hacer al jugador hijo del vehículo
        vehicle.GetComponent<VehicleController>().enabled = true; // Activar el controlador del vehículo
    }

    private void ExitVehicle()
    {
        isInsideVehicle = false;
        player.SetActive(true); // Reactivar el jugador
        player.transform.SetParent(null); // Separar del vehículo
        player.transform.position = vehicle.transform.position + Vector3.right * 2; // Mover al lado del vehículo
        vehicle.GetComponent<VehicleController>().enabled = false; // Desactivar el controlador del vehículo
    }
}
*/
/*using UnityEngine;

public class VehicleInteraction : MonoBehaviour
{
    public GameObject player; // Objeto del jugador
    public GameObject vehicle; // Vehículo
    public Transform seatPosition; // Posición del asiento
    public Camera playerCamera; // Cámara del jugador
    public Camera vehicleCamera; // Cámara del vehículo
    public KeyCode interactKey = KeyCode.E; // Tecla para interactuar
    public KeyCode exitKey = KeyCode.F; // Tecla para salir del vehículo
    private bool isInsideVehicle = false;

    private void Start()
    {
        vehicleCamera.gameObject.SetActive(false); // Asegurarse de que la cámara del vehículo esté desactivada
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
        player.transform.rotation = seatPosition.rotation; // Ajustar orientación
        player.transform.SetParent(vehicle.transform); // Anclar al vehículo

        playerCamera.gameObject.SetActive(false); // Desactivar cámara del jugador
        vehicleCamera.gameObject.SetActive(true); // Activar cámara del vehículo

        vehicle.GetComponent<VehicleController>().enabled = true; // Activar controlador del vehículo
    }

    private void ExitVehicle()
    {
        isInsideVehicle = false;
        player.transform.SetParent(null); // Separar del vehículo
        player.transform.position = vehicle.transform.position + Vector3.right * 2; // Mover al lado del vehículo

        playerCamera.gameObject.SetActive(true); // Reactivar cámara del jugador
        vehicleCamera.gameObject.SetActive(false); // Desactivar cámara del vehículo

        vehicle.GetComponent<VehicleController>().enabled = false; // Desactivar controlador del vehículo
    }
}
*/
/*using UnityEngine;

public class VehicleInteraction : MonoBehaviour
{
    public GameObject player; // Objeto del jugador
    public GameObject vehicle; // Vehículo
    public Transform seatPosition; // Posición del asiento
    public Camera playerCamera; // Cámara del jugador
    public Camera vehicleCamera; // Cámara del vehículo
    public KeyCode interactKey = KeyCode.E; // Tecla para interactuar
    public KeyCode exitKey = KeyCode.F; // Tecla para salir del vehículo
    public Collider interactionZone; // Zona de interacción del vehículo
    private bool isInsideVehicle = false;
    private CharacterController playerController;

    private void Start()
    {
        vehicleCamera.gameObject.SetActive(false); // Desactivar la cámara del vehículo
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
        return interactionZone.bounds.Contains(player.transform.position); // Verificar si el jugador está dentro del collider
    }

    private void EnterVehicle()
    {
        isInsideVehicle = true;

        // Ajustar el jugador
        player.transform.position = seatPosition.position;
        player.transform.rotation = seatPosition.rotation;
        player.transform.SetParent(vehicle.transform);
        playerController.enabled = false; // Desactivar movimiento del jugador

        // Ajustar cámaras
        playerCamera.gameObject.SetActive(false);
        vehicleCamera.gameObject.SetActive(true);

        // Activar el vehículo
        vehicle.GetComponent<VehicleController>().enabled = true;

        // Desactivar movimiento físico del vehículo mientras está en uso
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
        player.transform.position = vehicle.transform.position + Vector3.right * 2; // Mover al lado del vehículo
        playerController.enabled = true; // Reactivar movimiento del jugador

        // Ajustar cámaras
        playerCamera.gameObject.SetActive(true);
        vehicleCamera.gameObject.SetActive(false);

        // Desactivar el vehículo
        vehicle.GetComponent<VehicleController>().enabled = false;

        // Congelar el vehículo cuando no está en uso
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
    public GameObject vehicle; // Vehículo
    public Transform seatPosition; // Posición del asiento
    public Camera playerCamera; // Cámara del jugador
    public Camera vehicleCamera; // Cámara del vehículo
    public KeyCode interactKey = KeyCode.E; // Tecla para interactuar
    public KeyCode exitKey = KeyCode.F; // Tecla para salir del vehículo
    public Collider interactionZone; // Zona de interacción del vehículo
    public MonoBehaviour playerMovementScript; // Script que controla el movimiento del jugador
    private bool isInsideVehicle = false;

    private void Start()
    {
        vehicleCamera.gameObject.SetActive(false); // Desactivar la cámara del vehículo
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
        return interactionZone.bounds.Contains(player.transform.position); // Verificar si el jugador está dentro del collider
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

        // Ajustar cámaras
        playerCamera.gameObject.SetActive(false);
        vehicleCamera.gameObject.SetActive(true);

        // Activar el vehículo
        vehicle.GetComponent<VehicleController>().enabled = true;

        // Desactivar movimiento físico del vehículo mientras está en uso
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
        player.transform.position = vehicle.transform.position + Vector3.right * 2; // Mover al lado del vehículo

        // Reactivar movimiento del jugador
        playerMovementScript.enabled = true;

        // Ajustar cámaras
        playerCamera.gameObject.SetActive(true);
        vehicleCamera.gameObject.SetActive(false);

        // Desactivar el vehículo
        vehicle.GetComponent<VehicleController>().enabled = false;

        // Congelar el vehículo cuando no está en uso
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
    public GameObject vehicle; // Vehículo
    public Transform seatPosition; // Posición del asiento
    public Camera playerCamera; // Cámara del jugador
    public Camera vehicleCamera; // Cámara del vehículo
    public KeyCode interactKey = KeyCode.E; // Tecla para interactuar
    public KeyCode exitKey = KeyCode.F; // Tecla para salir del vehículo
    public Collider interactionZone; // Zona de interacción del vehículo
    public MonoBehaviour playerMovementScript; // Script que controla el movimiento del jugador
    public MonoBehaviour vehicleMovementScript; // Script que controla el movimiento del vehículo
    private bool isInsideVehicle = false;

    private void Start()
    {
        vehicleCamera.gameObject.SetActive(false); // Desactivar la cámara del vehículo
        vehicleMovementScript.enabled = false; // Desactivar movimiento del vehículo por defecto
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
        return interactionZone.bounds.Contains(player.transform.position); // Verificar si el jugador está dentro del collider
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

        // Ajustar cámaras
        playerCamera.gameObject.SetActive(false);
        vehicleCamera.gameObject.SetActive(true);

        // Activar el movimiento del vehículo
        vehicleMovementScript.enabled = true;

        // Desactivar movimiento físico del vehículo mientras está en uso
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
        player.transform.position = vehicle.transform.position + Vector3.right * 2; // Mover al lado del vehículo

        // Reactivar movimiento del jugador
        playerMovementScript.enabled = true;

        // Ajustar cámaras
        playerCamera.gameObject.SetActive(true);
        vehicleCamera.gameObject.SetActive(false);

        // Desactivar el movimiento del vehículo
        vehicleMovementScript.enabled = false;

        // Congelar el vehículo cuando no está en uso
        Rigidbody rb = vehicle.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
}
