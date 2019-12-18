using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject ToonChickPrefab;
    public GameObject ToonChickenPrefab;

    public Light gameLight;

    private Transform ChickenTransform;

    [Space(30)]
    public Vector3 lookOffset = new Vector3(0, 1, 0);
    public float distance = 5f;   //distance between camera and player position
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

        gameLight.enabled = GameManager.Instance.IsLightsOn;
    }

    public void Update()
    {
        Vector3 offset = ChickenTransform.position - transform.position;
        Vector3 lookPosition = ChickenTransform.position + lookOffset;
        // look 360 degree
        transform.LookAt(lookPosition);
        if (Vector3.Distance(transform.position, lookPosition) > distance)
        {
            var diffInDistance = Vector3.Distance(transform.position, lookPosition) - distance;
            var movementDueToSpeed = cameraSpeed * Time.deltaTime;
            transform.Translate(0, 0, Mathf.Min(diffInDistance, movementDueToSpeed));
        }
        if (Vector3.Distance(transform.position, lookPosition) < 1f)
        {
            transform.position = new Vector3(0, 1, ChickenTransform.position.z + 1f);
        }
    }
}

