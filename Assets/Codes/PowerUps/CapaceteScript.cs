using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapaceteScript : MonoBehaviour
{


    [SerializeField] private Vector3 offset;
    public GameObject target;
    public void FollowPlayer(GameObject targetPlayer)
    {
        target = targetPlayer;
        Vector3 offset = new Vector3(0f, 0f, 0f);
    }
    private void Update()
    {
        transform.position = target.transform.position + offset;
        transform.rotation = target.transform.rotation;
    }
}
