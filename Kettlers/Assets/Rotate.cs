﻿using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);

    }
}
