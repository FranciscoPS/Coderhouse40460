using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Con este evento podemos obtener propiedades con las que colisionan objectos
    private void OnCollisionEnter(Collision collision)
    {
        //Obtenemos la fuerza con la que colisiona el player
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"{collision.impulse}");
        }
    }
}
