using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour, ITouchable
{
    [SerializeField] private float speed;

    [SerializeField] private Rigidbody rb;
    [SerializeField] float dieTime;
    public void touch(int type)
    {
       
    }

    void Start()
    {
        rb.velocity = transform.forward * speed;
        Destroy(this.gameObject, dieTime);
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
