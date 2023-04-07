using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float m_speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += m_speed * Time.deltaTime * (transform.forward * -1);
    }
}
