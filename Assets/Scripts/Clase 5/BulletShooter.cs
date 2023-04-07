using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    //Esto es para saber que bala vamos a disparar
    [SerializeField] private Bullet m_bulletToShoot;
    //Al pasar el transofrm del shooting point, podemos hacer que siempre salga de ahi
    [SerializeField] private Transform m_shootingPoint;
    //Podemos asignar un padre
    [SerializeField] private Transform m_bulletParent;


    void Start()
    {
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        //Paso 1: Instanciar nueva bala
        Instantiate(m_bulletToShoot, m_shootingPoint.position, m_shootingPoint.rotation, m_bulletParent);
    }
}
