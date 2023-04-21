using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private enum EnemyType
    {
        Basic, Great, Lord
    }

    private int attackDamage;
    private Vector3 m_myVector;
    private EnemyType enemyType;
    //Objeto al que va a perseguir el enemigo
    [SerializeField] private Transform m_target;
    //Distancia a la que comenzará a seguir
    [SerializeField] private float m_distanceToChase = 10f;
    //Velocidad a la que queremos el enemigo persiga
    [SerializeField] private float m_movementSpeed = 2f;
    //Velocidad de giro para suavizado de cambio de rotación
    [SerializeField] private float m_turningSpeed = 10f;

    void Start()
    {
    }

    private void Update()
    {
        Chase();
    }

    private void Chase()
    {
        var l_diffVector = m_target.position - transform.position;

        //Tenemos el vector, pero la longitud o magnitud es la que define la distancia a la que se encuentra
        //Entonces, el enemigo va a cazar al jugador si la distancia MÍNIMA PARA SEGUIR es mayor a la que se encuentra el enemigo
        if (l_diffVector.magnitude < m_distanceToChase)
        {
            Debug.Log("Estoy persiguiendo al jugador");
            //No debemos mandar todo el vector, debemos mandar el vector normalizado el cual contiene dirección
            Move(l_diffVector.normalized);
        }
    }

    //Aqui recibimas la dirección a la que se va a mover el enemigo con respecto a la posición
    private void Move(Vector3 p_direction)
    {
        //Con esto podemos hacer que rote hacia la dirección del player
        Quaternion l_newRotation = Quaternion.LookRotation(p_direction);
        //Haciendo un lerp hace más suavizada la rotación
        transform.rotation = Quaternion.Lerp(transform.rotation, l_newRotation, Time.deltaTime * m_turningSpeed);

        transform.position += p_direction * m_movementSpeed * Time.deltaTime;
    }

    private void SetEnemyDamage(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Basic:
                attackDamage = 2;
                break;
            case EnemyType.Great:
                attackDamage = 5;
                break;
            case EnemyType.Lord:
                attackDamage = 10;
                break;
            default:
                attackDamage = 0;
                break;
        }
    }
}
