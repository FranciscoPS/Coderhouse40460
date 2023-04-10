using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_playerHealth;
    [SerializeField] private float m_speed;


    private void Move()
    {
        transform.position += transform.forward * Time.deltaTime * m_speed;
    }

    private void Update()
    {
        if (m_playerHealth > 0)
            Move();
    }
}
