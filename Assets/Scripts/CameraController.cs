using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ToonChick;
    public GameObject ToonChicken;
    
    public Transform GameObject;

    public Vector3 lookOffset = new Vector3(0, 1, 0);
    public float distance = 5f;//distance between camera and player position
    public float cameraSpeed = 8f;//speed of camera
    private float offset;

    public void Start()
    {
        if (chickenIndex == 1)
        {
            GameObject = Instantiate(ToonChicken.Load("ToonChicken", typeof(GameObject))) as GameObject;
        }

        else (chickenIndex == 2){
            GameObject = Instantiate(Toon Chick.Load("Toon Chick", typeof(GameObject))) as GameObject;

        }
    }

    public void Update()
    {
        Vector3 offset = GameObject.position - transform.position;
        Vector3 lookPosition = GameObject.position + lookOffset;
        // look 360 degree
        transform.LookAt(lookPosition);
        if (Vector3.Distance(transform.position, lookPosition) > distance)
        {
            transform.Translate(0, 0, cameraSpeed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, lookPosition) < 1f)
        {
            transform.position = new Vector3(0, 1, GameObject.position.z + 1f);
        }
    }
}

