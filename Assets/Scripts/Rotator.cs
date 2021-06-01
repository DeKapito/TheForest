using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Update()
    {
        if (Time.timeScale == 0) {
            return;
        }
        transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime, Space.World);
    }
}
