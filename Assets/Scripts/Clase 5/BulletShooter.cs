using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    //Esto es para saber que bala vamos a disparar
    [SerializeField] private Bullet m_bulletToShoot;
    // Start is called before the first frame update
    void Start()
    {
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Shoot()
    {
        //Paso 1: Instanciar nueva bala
        Instantiate(m_bulletToShoot)
    }
}
