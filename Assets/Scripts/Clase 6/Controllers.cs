using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllers : MonoBehaviour
{
    public int lifePoints = 100;
    [SerializeField] private float speed = 1f;
    [SerializeField] private Vector3 direction = new Vector3(0, 0, 1);

    void Start()
    {
        Debug.Log("Hello! You have " + lifePoints + " life points!");

        Harm(10);
        Debug.LogError("Auch! You took damage!!! LP: " + lifePoints);

        Heal(20);
        Debug.LogWarning("Here....take 20 life points :D  LP: " + lifePoints);

        Debug.Log("Let's move!");
    }

    void Update()
    {
        Move(speed, direction);
    }

    private void Move(float speed, Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * speed;
    }

    private void Heal(int lp)
    {
        lifePoints += lp;
    }

    private void Harm(int lp)
    {
        lifePoints -= lp;
    }
}
