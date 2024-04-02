using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{

    [SerializeField] private int indexCheckPoint;


    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.transform.parent.gameObject;
        ICheckpointable checkpointable = obj.gameObject.GetComponent<ICheckpointable>();
        if (checkpointable != null && obj.gameObject.tag == "Player")
        {
            checkpointable.check(indexCheckPoint);
            
        }
    }
}
