using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour, ITouchable
{
    [SerializeField] private Transform PointFront;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private ArcadeKart kartScript;
    
    public GameObject Item;


   

    public void touch(int type) // coisas que tocao
    {
       if (type == 0) // luckybox
       {
            if (Item == null)
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
                    if(Item.gameObject.tag == "PocaoSpeed")
                    {
                        StartCoroutine(PotionSpeedTaken());
                    } else
                    {
                        Instantiate(Item, PointFront.position, PointFront.rotation);
                    }
                    Item = null;
                }
            }

        }
    }
    private IEnumerator PotionSpeedTaken() // Potion Speed
    {
        kartScript.baseStats.Acceleration += SkillsManager.main.potionSpeedAccAdd;
        kartScript.baseStats.TopSpeed += SkillsManager.main.potionSpeedTopSpeedAdd;
        yield return new WaitForSeconds(SkillsManager.main.potionSpeedDuration);
        kartScript.baseStats.Acceleration -= SkillsManager.main.potionSpeedAccAdd;
        kartScript.baseStats.TopSpeed -= SkillsManager.main.potionSpeedTopSpeedAdd;
    }

    private IEnumerator StunTaken() // Snowball
    {
        rb.constraints = RigidbodyConstraints.FreezePosition;
        yield return new WaitForSeconds(SkillsManager.main.stunTime);
        rb.constraints = RigidbodyConstraints.None;
    }

}
