using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;  //Velocidad de movimiento del jugador
    [SerializeField] private float rotationSpeed = 10.0f; //Velocidad de rotación
    [SerializeField] private float playerHealth = 10.0f; //Vida del jugador
    [SerializeField] private float maxHealth = 100.0f; //Vida del jugador
    [SerializeField] private float fallDamageThreshold; //Limite para que reciba daño por caida
    [SerializeField] private float fallDamage = 10; //Daño por caida
    private float rotationAngle = 45.0f; // Ángulo de rotación en grados

    void Update()
    {
        Move();
    }

    public void OnCollisionEnter(Collision collision)
    {
        var collisionSpeed = collision.impulse;

        if(collisionSpeed.y > fallDamageThreshold)
        {
            TakeDamage(fallDamage);
        }
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0)
        {
            playerHealth = 0;
        }
    }

    public void Heal(float healAmounth)
    {
        playerHealth += healAmounth;

        if (playerHealth >= maxHealth)
        {
            playerHealth = maxHealth;
        }
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

    private void RotatePlayer(Quaternion targetRotation)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

}
