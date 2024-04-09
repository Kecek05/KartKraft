using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using UnityEngine;
using UnityEngine.Video;

public class PlayerThrow : MonoBehaviour, ITouchable
{
    public int isP1;
    [SerializeField] private Transform[] Points;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform transBouncing;
    [SerializeField] private ArcadeKart kartScript;
    [SerializeField] private GameObject particleSpeed;

    [SerializeField] private GameObject capaceteObj;

    [SerializeField] private Vector3 offCapa;

    public GameObject Item;
    private bool haveCapacete;

    public bool atirando;

    private bool isRotating;

    public string fireButton;

    [SerializeField] private Animator anim;
    [SerializeField] private GameObject WheelsObj;
    [SerializeField] private GameObject WheelsVisual;
    public void touch(int type) // coisas que tocao
    {
       if (type == 0) // luckybox
       {
            if (Item == null)
            {
                Item = SkillsManager.main.getPowerUp();
                UIPowerUp.main.itemToUI(Item, false, isP1);
            }
       }else if(type == 1) //SnowBall
       { 
            if(haveCapacete) { 
                LoseCapacete();
                return;
            }
            StartCoroutine(StunTaken(SkillsManager.main.SnowstunTime));
            
       } else if (type == 2) // MiniZombie
       {
            if (haveCapacete)
            {
                LoseCapacete();
                return;
            }
            StartCoroutine(StunTaken(SkillsManager.main.MiniZombiestunTime));

        } else if (type == 3) // teia
        {
            if (haveCapacete)
            {
                LoseCapacete();
                return;
            }
            StartCoroutine(StunTaken(SkillsManager.main.teiaStunDuration));
 
        }

    }


    void Update()
    {
        if(Input.GetButton(fireButton))
        {
            shootPressed();
            print(" ATIRA");
        }
       
        
    }

    private void shootPressed()
    {
        if (Points != null)
        {
            if (Item != null)
            {
                if (Item.CompareTag("PocaoSpeed"))
                {
                    StopCoroutine(PotionSpeedTaken());
                    StartCoroutine(PotionSpeedTaken());
                } else if(Item.CompareTag("Teia"))
                {
                    Instantiate(Item, Points[1].position, Points[1].rotation);
                } else if (Item.CompareTag("Capacete"))
                {
                    takeCapacete();
                }
                else
                {
                    Instantiate(Item, Points[0].position, Points[0].rotation);
                }
                Item = null;
            }
            UIPowerUp.main.itemToUI(Item, true, isP1);
        }
    }

    private IEnumerator StunTaken(float time)
    {
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rotateStart(time);
        yield return new WaitForSeconds(time);
        rb.constraints = RigidbodyConstraints.None;
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

    private void rotateStart(float time)
    {
        if (!isRotating)
        {
            StartCoroutine(stunFeedback(time));
            isRotating = true;
        }
    }

    private IEnumerator stunFeedback(float time)
    {
        float steerInit = kartScript.baseStats.Steer;
        kartScript.baseStats.Steer = 0f;
        //anim play
        WheelsVisual.SetActive(true);
        WheelsObj.SetActive(false);
        anim.Play("rotate");
        yield return new WaitForSeconds(time);
        //anim stop
        kartScript.baseStats.Steer = steerInit;
        isRotating = false;
        WheelsObj.SetActive(true);
        WheelsVisual.SetActive(false);
        anim.Play("idle");


    }

    public void takeCapacete()
    {
        if (!haveCapacete)
        {
            haveCapacete = true;
            capaceteObj = Instantiate(Item, Points[2].position, Points[2].rotation);
            CapaceteScript capaScript = capaceteObj.transform.GetComponent<CapaceteScript>();
            capaScript.FollowPlayer(this.gameObject, offCapa);
        }
    }
    public void LoseCapacete()
    {
        haveCapacete = false;
        Destroy(capaceteObj);
    }
}
