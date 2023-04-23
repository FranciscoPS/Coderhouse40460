using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    [SerializeField] private Vector3 scale = new Vector3(1, 1, 1);
    [SerializeField] private Vector3 direction = new Vector3(0, 0, 0);

    void Start()
    {
        transform.localScale = scale;
    }

    void Update()
    {
        Move(speed, direction);
    }

    private void Move(float speed, Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * speed;
    }
}
