using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    private enum EnemyType
    {
        Enemy1,
        Enemy2
    }

    private Vector3 diffVector;
    private float maxNearbyDistance = 2.0f; //Máximo que se puede acercar
    [SerializeField] private EnemyType enemyType; //Tipo del enemigo
    [SerializeField] private Transform target; //Objetivo del enemigo
    [SerializeField] private float moveSpeed = 5.0f;  //Velocidad de movimiento del jugador
    [SerializeField] private float rotationSpeed = 10.0f; //Velocidad de rotación 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        setDiffVector();

        CheckEnemyType();
    }

    private void CheckEnemyType()
    {
        switch (enemyType)
        {
            case EnemyType.Enemy1:
                LookAtTarget(diffVector.normalized);
                break;
            case EnemyType.Enemy2:
                ChaseTarget();
                break;
        }
    }

    private void setDiffVector()
    {
        //Calculamos el vector de diferencia entre el target y el enemigo
        diffVector = target.position - transform.position;
    }

    private void LookAtTarget(Vector3 targetDirection)
    {
        //Con esto podemos hacer que rote hacia la dirección del player
        Quaternion rotation = Quaternion.LookRotation(targetDirection);

        //Haciendo un lerp hace más suavizada la rotación
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
    }

    private void ChaseTarget()
    {
        if (diffVector.magnitude >= maxNearbyDistance)
        {
            Move(diffVector.normalized);
        }
    }

    private void Move(Vector3 direction)
    {
        Quaternion rotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}