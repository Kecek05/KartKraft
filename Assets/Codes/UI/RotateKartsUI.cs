using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateKartsUI : MonoBehaviour
{
   // [SerializeField]
   // private Transform transform;
    [SerializeField]
    private float rotationSpeed;

    void Update()
    {
        transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
    }
}
