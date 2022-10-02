using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    private GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        // Get keyboard W / S input
        float moveForward = Input.GetAxis("Vertical");
        // Get keyboard A / D input
        float moveRight = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * moveForward);
        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed * moveRight);
        mainCamera.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * moveForward);
        mainCamera.transform.Translate(Vector3.right * Time.deltaTime * movementSpeed * moveRight);
    }
}
