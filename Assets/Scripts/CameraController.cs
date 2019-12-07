using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ToonChickPrefab;
    public GameObject ToonChickenPrefab;
    
    private Transform ChickenTransform;

    [Space(30)]
    public Vector3 lookOffset = new Vector3(0, 1, 0);
    public float distance = 5f;//distance between camera and player position
    public float cameraSpeed = 8f;//speed of camera

    public void Start()
    {
        if (GameManager.Instance.ChickenIndex == 1)
        {
            ChickenTransform = Instantiate(ToonChickenPrefab).transform;
        }
        else if (GameManager.Instance.ChickenIndex == 2)
        {
            ChickenTransform = Instantiate(ToonChickPrefab).transform;
        }
        else
        {
            Debug.LogError("No chicken was selected but scene was still loaded");
        }
    }

    public void Update()
    {
        Vector3 offset = ChickenTransform.position - transform.position;
        Vector3 lookPosition = ChickenTransform.position + lookOffset;
        // look 360 degree
        transform.LookAt(lookPosition);
        if (Vector3.Distance(transform.position, lookPosition) > distance)
        {
            transform.Translate(0, 0, cameraSpeed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, lookPosition) < 1f)
        {
            transform.position = new Vector3(0, 1, ChickenTransform.position.z + 1f);
        }
    }
}

