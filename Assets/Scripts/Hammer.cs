using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    private bool smashing = true;

    void Update()
    {
        if (smashing)
        {
            transform.Rotate(new Vector3(0f, 0f, 360f) * Time.deltaTime);
            if (transform.localEulerAngles[2] >= 100)
            {
                smashing = false;
            }
        }
        else
        {
            transform.Rotate(new Vector3(0f, 0f, -60f) * Time.deltaTime);
            if (transform.localEulerAngles[2] < 10f)
            {
                smashing = true;
            }
        }
    }
}
