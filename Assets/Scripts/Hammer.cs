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
            transform.Rotate(new Vector3(180f, 0f, 0f) * Time.deltaTime);
            if (transform.eulerAngles[1] == 180)
            {
                smashing = false;
            }
        }
        else
        {
            transform.Rotate(new Vector3(-30f, 0f, 0f) * Time.deltaTime);
            if (transform.eulerAngles[0] < 10f)
            {
                smashing = true;
            }
        }
    }
}
