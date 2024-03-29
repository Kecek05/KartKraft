using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour, ITouchable
{
    public bool isP1;
    [SerializeField] private UIPowerUp UiPower;
    [SerializeField] private Transform PointFront;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private ArcadeKart kartScript;
    [SerializeField] private GameObject particleSpeed;

    public GameObject Item;
   

    public void touch(int type) // coisas que tocao
    {
       if (type == 0) // luckybox
       {
            if (Item == null)
            {
                Item = SkillsManager.main.getPowerUp();
                UiPower.itemToUI(Item, false);
            }
       }else if(type == 1) //SnowBall
       { 
            StartCoroutine(StunTaken()); 
       } else if (type == 2) // MiniZombie
       {
            StartCoroutine(MiniZombieStunTaken());
       }

    }


    void Update()
    {
        if(isP1)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                shootPressed();
            }
        } else
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                shootPressed();
            }
        }
    }

    private void shootPressed()
    {
        if (PointFront != null)
        {
            if (Item != null)
            {
                if (Item.gameObject.tag == "PocaoSpeed")
                {
                    StartCoroutine(PotionSpeedTaken());
                }
                else
                {
                    Instantiate(Item, PointFront.position, PointFront.rotation);
                }
                Item = null;
            }
                UiPower.itemToUI(Item, true);
        }
    }

    private IEnumerator PotionSpeedTaken() // Potion Speed
    {
        particleSpeed.SetActive(true);
        kartScript.baseStats.Acceleration += SkillsManager.main.potionSpeedAccAdd;
        kartScript.baseStats.TopSpeed += SkillsManager.main.potionSpeedTopSpeedAdd;
        yield return new WaitForSeconds(SkillsManager.main.potionSpeedDuration);
        kartScript.baseStats.Acceleration -= SkillsManager.main.potionSpeedAccAdd;
        kartScript.baseStats.TopSpeed -= SkillsManager.main.potionSpeedTopSpeedAdd;
        particleSpeed.SetActive(false);
    }

    private IEnumerator StunTaken() // Snowball
    {
        rb.constraints = RigidbodyConstraints.FreezePosition;
        yield return new WaitForSeconds(SkillsManager.main.stunTime);
        rb.constraints = RigidbodyConstraints.None;
    }
    private IEnumerator MiniZombieStunTaken() // Snowball
    {
        rb.constraints = RigidbodyConstraints.FreezePosition;
        yield return new WaitForSeconds(SkillsManager.main.MiniZombiestunTime);
        rb.constraints = RigidbodyConstraints.None;
    }

}
