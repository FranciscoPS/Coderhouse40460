using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool canMove = true;
    [SerializeField] private float m_speed;


    private void Move()
    {
        transform.position += transform.forward * Time.deltaTime * m_speed;
    }

    private void Update()
    {
        if (canMove)
            Move();
    }
}
