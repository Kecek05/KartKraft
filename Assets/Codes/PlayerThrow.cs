using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour, ITouchable
{
    [SerializeField] private Transform PointFront;
    [SerializeField] private Rigidbody rb;
    public GameObject Item;
   

    public void touch(int type)
    {
       if (type == 0) // luckybox
       {
            Item = SkillsManager.main.getPowerUp();
       }else if(type == 1) //SnowBall
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
                if(Item != null)
                {
                    Instantiate(Item, PointFront.position, PointFront.rotation);
                    Item = null;
                }
            }

        }
    }

    private IEnumerator StunTaken()
    {
        rb.constraints = RigidbodyConstraints.FreezePosition;
        yield return new WaitForSeconds(SkillsManager.main.StunTime);
        rb.constraints = RigidbodyConstraints.None;
    }

}
