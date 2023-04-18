using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform m_pointOfInterest;
    [SerializeField] private float m_followTime;
    private Vector3 m_initialDistance;

    void Awake()
    {
        //La distancia inicial es igual a la distancia del punto de interés menos la distancia del componente actual
        m_initialDistance = m_pointOfInterest.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //El siguiente código da suavizado al movimiento de la cámara
        var l_currVelocity = new Vector3();
        var l_desiredPosition = Vector3.SmoothDamp(transform.position, m_pointOfInterest.position - m_initialDistance, ref l_currVelocity, m_followTime);
        transform.position = l_desiredPosition;
    }
}
