using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 50f;

    private void Update()
    {
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime; // Avanzar/retroceder
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime; // Girar

        transform.Translate(Vector3.forward * move);
        transform.Rotate(Vector3.up * turn);
    }
}
