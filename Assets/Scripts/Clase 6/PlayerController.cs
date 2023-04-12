using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_playerHealth;
    [SerializeField] private float m_speed;
    [SerializeField] private string m_playerName;
    [SerializeField] private Bullet m_bullet;
    [SerializeField] private float m_initialTime = 3f;
    private float m_currentTimeToShoot;

    private void Awake()
    {
        if (!IsValidName(m_playerName)) return;

        Debug.Log($"Your player name is {m_playerName}");
    }

    private void Update()
    {
        if (m_playerHealth <= 0) return;

        CheckMovement();

        //Creamos un temporizador que no permite disparar más que una vez cada 3 segundos
        m_currentTimeToShoot -= Time.deltaTime;
        CheckShoot();
    }

    private void CheckShoot()
    {
        if (Input.GetButton("Disparo") && m_currentTimeToShoot <= 0)
        {
            Shoot();

            m_currentTimeToShoot = m_initialTime;
        }

    }

    private void Shoot()
    {
        var l_bullet = Instantiate(m_bullet, transform.position, Quaternion.identity);
    }

    private void CheckMovement()
    {
        var l_horizontal = Input.GetAxis("Horizontal"); //Tiene suavizado
        //var l_horizontal = Input.GetAxisRaw("Horizontal"); //No tiene suavizado de movimiento


        var l_vertical = Input.GetAxis("Vertical");

        var l_direction = new Vector3(l_horizontal, 0, l_vertical);

        Move(l_direction);

        //DEPRECATED
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position += transform.forward * (Time.deltaTime * m_speed);
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position -= transform.forward * (Time.deltaTime * m_speed);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += transform.right * (Time.deltaTime * m_speed);
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position -= transform.right * (Time.deltaTime * m_speed);
        //}
    }

    private void CheckDamage()
    {
        //Detecta solo en el frame que se presiona la letra k
        bool l_kKeyIsPressed = Input.GetKeyDown(KeyCode.K);

        if (l_kKeyIsPressed)
        {
            TakeDamage(1);
        }
    }

    private void Move(Vector3 p_direction)
    {
        transform.position += p_direction * Time.deltaTime * m_speed;
    }

    private void TakeDamage(float p_damage)
    {
        m_playerHealth -= p_damage;
    }

    private bool IsValidName(string p_name)
    {
        bool isNullOrWhiteSpace = string.IsNullOrWhiteSpace(p_name);
        return !isNullOrWhiteSpace;
    }
}
