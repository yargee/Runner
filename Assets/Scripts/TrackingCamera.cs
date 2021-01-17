using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    [SerializeField] Transform _yoba;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, _yoba.transform.position.y, transform.position.z);
    }
}
