using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] public bool reverseDirection = false;

    void Start()
    {
        if (reverseDirection)
            GetComponent<SpriteRenderer>().flipY = true;
    }

    void Update()
    {
        if (reverseDirection)
            transform.position += Vector3.right * speed * Time.deltaTime;
        else
            transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
