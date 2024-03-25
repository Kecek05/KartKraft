using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Rigidbody rb;
    [SerializeField] float dieTime;

    void Start()
    {
        rb.velocity = transform.forward * speed;
        Destroy(this.gameObject, dieTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        ITouchable touchable = collision.gameObject.GetComponent<ITouchable>();
        if (touchable != null)
        {
            touchable.touch(1);
            Destroy(this.gameObject);
        }
    }

}
