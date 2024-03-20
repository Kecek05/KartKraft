using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour, ITouchable
{
    [SerializeField] private Transform PointFront;
    [SerializeField] private Rigidbody rb;
    public GameObject Item;
    [SerializeField] private float StunTime;

    public void touch(int type)
    {
       if(type == 0)
        {
            StartCoroutine(StunTaken());
        }
    }

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (PointFront != null)
            {
                Instantiate(Item, PointFront.position, PointFront.rotation);
            }

        }
    }

    private IEnumerator StunTaken()
    {
        rb.constraints = RigidbodyConstraints.FreezePosition;
        yield return new WaitForSeconds(StunTime);
        rb.constraints = RigidbodyConstraints.None;
    }
    
}
