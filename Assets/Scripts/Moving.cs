using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float xDistance;
    [SerializeField] private float yDistance;
    [SerializeField] private float zDistance;

    private float runningTime = 0f;

    void Update()
    {
        runningTime += Time.deltaTime;
        transform.Translate(new Vector3(xDistance, yDistance, zDistance)
            * Mathf.Sin(runningTime * speed) * Time.deltaTime);
    }
}
