using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    [SerializeField]
    private Image LinearTimer;

    public float totalTimeSeconds = 120;
    public float timeLeftSeconds;



    void Start()
    {
        timeLeftSeconds = totalTimeSeconds;
    }

    void Update()
    {
        timeLeftSeconds -= Time.deltaTime;
        var scale = timeLeftSeconds / totalTimeSeconds;

        if (timeLeftSeconds <= 0)
            scale = 0;

        LinearTimer.transform.localScale = new Vector3(scale, 1, 1);
    }
}
