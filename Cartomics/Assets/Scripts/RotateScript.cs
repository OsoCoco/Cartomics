using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Rotate(speed * Vector3.up * Time.deltaTime);
    }
}
