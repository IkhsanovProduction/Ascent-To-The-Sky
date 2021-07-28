using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanets : MonoBehaviour
{
    [SerializeField] private float _degreesPerSecond = 20;

    void Update()
    {
        transform.Rotate(Vector3.up * _degreesPerSecond * Time.deltaTime);
    }
}
