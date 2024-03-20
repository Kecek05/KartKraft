using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour, ITouchable
{
    [SerializeField] private float speed;

    [SerializeField] private Rigidbody rb;

    public void touch(int type)
    {
       
    }

    void Start()
    {
        rb.velocity = transform.forward * speed;
        Destroy(this.gameObject, 5f);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        ITouchable touchable = collision.gameObject.GetComponent<ITouchable>();
        if (touchable != null)
        {
            touchable.touch(0);
            Destroy(this.gameObject);
        }
    }

}
