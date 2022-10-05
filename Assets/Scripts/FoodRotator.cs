using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRotator : MonoBehaviour
{

    float rotateSpeed = 100f;

    void Start()
    {

    }

    void Update()
    {
        // Make food animation by rotating
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed, Space.World);
    }
}
