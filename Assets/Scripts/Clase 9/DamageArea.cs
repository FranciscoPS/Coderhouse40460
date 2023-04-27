using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [SerializeField] private float dps = 1.0f;

    private void OnTriggerStay(Collider other)
    {
        //Con estas comparaciones directamente intentamos obtener componente y si lo obtiene lo asigna a la variable player
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerController player))
        {
            player.TakeDamage(dps * Time.fixedDeltaTime);
        }
        else
        {
            Debug.Log("NO es un player!");
        }
    }
}
