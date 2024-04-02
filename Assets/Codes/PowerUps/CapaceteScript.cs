using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapaceteScript : MonoBehaviour
{


    [SerializeField] private Vector3 offset;
    public GameObject target;
    public void FollowPlayer(GameObject targetPlayer, Vector3 offsetPlayer)
    {
        target = targetPlayer;
        offset = offsetPlayer;
    }
    private void Update()
    {
        transform.position = target.transform.position + offset;
        transform.rotation = target.transform.rotation;
    }
}
