using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float m_speed;
    [SerializeField] private float m_initialTime = 3f; //Basicamente el temporizador es de 3 segundos
    private float m_currentTime;


    void Awake()
    {
        m_currentTime = m_initialTime;
    }

    void Update()
    {
        //Al restarle un deltaTime, estamos siempre bajando un "uno"
        //Usamos deltaTime ya que es el equivalente y nivela o proporciona sin importar los fps del juego
        m_currentTime -= Time.deltaTime;

        //Si pasó un segundo, se elimina el objeto
        if(m_currentTime <= 0)
        {
            Destroy(gameObject);
        }

        Move();
    }

    void Move()
    {
        transform.position += m_speed * Time.deltaTime * (transform.forward * -1);
    }
}
