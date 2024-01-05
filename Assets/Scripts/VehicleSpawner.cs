using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    [SerializeField] float maxTime = 10f;
    [SerializeField] GameObject vehicle;
    [SerializeField] bool reverseDirection = false;
    [SerializeField] Sprite[] sprites = { };

    private float timer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            Spawn();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    void Spawn()
    {
        vehicle.GetComponent<VehicleMovement>().reverseDirection = reverseDirection;

        GameObject newVehicle = Instantiate(vehicle, transform.position, transform.rotation);

        SpriteRenderer sp = newVehicle.GetComponent<SpriteRenderer>();
        sp.sprite = sprites[Random.Range(0, sprites.Length)];

        Destroy(newVehicle, 10f);
    }
}
