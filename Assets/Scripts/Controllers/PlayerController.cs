using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;  //Velocidad de movimiento del jugador
    [SerializeField] private float rotationSpeed = 10.0f; //Velocidad de rotación 
    private float rotationAngle = 45.0f; // Ángulo de rotación en grados

    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Obtener el input horizontal y vertical del jugador
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // Obtener la dirección hacia adelante del objeto basada en su rotación
        Vector3 forwardDirection = transform.forward;

        // Normalizar la dirección hacia adelante para evitar velocidades inconsistentes en diagonales
        forwardDirection.Normalize();

        // Calcular la dirección de movimiento del objeto
        Vector3 moveDirection = (forwardDirection * verticalInput) + (transform.right * horizontalInput);

        // Rotar al jugador a la dirección deseada
        Rotate();

        //Mover al jugador
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }


    private void Rotate()
    {
        Quaternion targetRotation;

        if (Input.GetKey(KeyCode.Q))
        {
            targetRotation = Quaternion.Euler(0, -rotationAngle, 0) * transform.rotation;
            RotatePlayer(targetRotation);
        }

        if (Input.GetKey(KeyCode.E))
        {
            targetRotation = Quaternion.Euler(0, rotationAngle, 0) * transform.rotation;
            RotatePlayer(targetRotation);
        }
    }

    void RotatePlayer(Quaternion targetRotation)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
