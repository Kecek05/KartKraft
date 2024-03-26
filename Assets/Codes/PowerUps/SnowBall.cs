using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    [SerializeField] private GameObject father;
    [SerializeField] private float speed;

    [SerializeField] private Rigidbody rb;
    [SerializeField] float dieTime;

    void Start()
    {
        FindFather();
        rb.velocity = transform.forward * speed;
        Destroy(this.gameObject, dieTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == father)
            return;
        ITouchable touchable = collision.gameObject.GetComponent<ITouchable>();
        if (touchable != null && collision.gameObject.tag == "Player")
        {
            touchable.touch(1);
            Destroy(this.gameObject);
        }
    }



    private void FindFather()
    {
        GameObject[] playersTarget = GameObject.FindGameObjectsWithTag("Player");
        if (playersTarget.Length > 0)
        {
            float shortestDistance = Vector3.Distance(transform.position, playersTarget[0].transform.position);
            for (int i = 0; i < playersTarget.Length; i++)
            {
                float distance = Vector3.Distance(transform.position, playersTarget[i].transform.position);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    father = playersTarget[i];
                }
            }
        }
    }
}
