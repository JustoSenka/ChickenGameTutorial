using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocks : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;

    public float travelSpeed = 5f;

    private Rigidbody rb;
    private bool goingBack;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var endPosition = pointB;
        if (goingBack)
            endPosition = pointA;

        var newPos = Vector3.MoveTowards(transform.position, endPosition, travelSpeed * Time.deltaTime);

        if (newPos == endPosition)
            goingBack = !goingBack;

        rb.MovePosition(newPos);


        /*
        var totalTripDistance = Vector3.Distance(startPosition, endPosition);
        var distanceLeft = Vector3.Distance(transform.position, endPosition);

        var distanceLeftRatio = distanceLeft / totalTripDistance;

        var middlePosition = Vector3.Lerp(startPosition, endPosition, distanceLeftRatio + );

        Vector3.mo


*/
    }
}
