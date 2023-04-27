using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthArea : MonoBehaviour
{
    [SerializeField] private float healthPerSecond = 10f;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"{other.name}");

        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerController>();

            if (player)
                player.Heal(healthPerSecond * Time.fixedDeltaTime);
        }
        else
        {
            Debug.Log("NO es un player!");
        }
    }
}
