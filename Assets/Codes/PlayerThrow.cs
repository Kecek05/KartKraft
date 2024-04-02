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
    [SerializeField] private float stunRotationSpeed;

    [SerializeField] private GameObject capaceteObj;

    public GameObject Item;
    private bool haveCapacete;

    [SerializeField] private Transform[] pecasCarro;
    private bool isRotating;

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
            StartCoroutine(StunTaken());
            rotateStart(SkillsManager.main.SnowstunTime);
            
       } else if (type == 2) // MiniZombie
       {
            if (haveCapacete)
            {
                LoseCapacete();
                return;
            }
            StartCoroutine(MiniZombieStunTaken());
            rotateStart(SkillsManager.main.MiniZombiestunTime);

        } else if (type == 3) // teia
        {
            if (haveCapacete)
            {
                LoseCapacete();
                return;
            }
            StartCoroutine(TeiaStunTaken());
            rotateStart(SkillsManager.main.teiaStunDuration);
 
        }

    }


    void Update()
    {
        if(isP1 == 0)
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
        if (Points != null)
        {
            if (Item != null)
            {
                if (Item.gameObject.tag == "PocaoSpeed")
                {
                    StartCoroutine(PotionSpeedTaken());
                } else if(Item.gameObject.tag == "Teia")
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
        yield return new WaitForSeconds(SkillsManager.main.SnowstunTime);
        rb.constraints = RigidbodyConstraints.None;
    }
    private IEnumerator MiniZombieStunTaken() // Snowball
    {
        rb.constraints = RigidbodyConstraints.FreezePosition;
        yield return new WaitForSeconds(SkillsManager.main.MiniZombiestunTime);
        rb.constraints = RigidbodyConstraints.None;
    }

    private IEnumerator TeiaStunTaken() // teia
    {
        rb.constraints = RigidbodyConstraints.FreezePosition;
        yield return new WaitForSeconds(SkillsManager.main.teiaStunDuration);
        rb.constraints = RigidbodyConstraints.None;
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
        Quaternion positionInit = transform.rotation;
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            foreach (Transform peca in pecasCarro)
            {
                peca.Rotate(Vector3.down, stunRotationSpeed * Time.deltaTime);
            }
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        if(elapsedTime >= time)
        {
            foreach (Transform peca in pecasCarro)
            {
                peca.rotation = positionInit;
            }
            kartScript.baseStats.Steer = steerInit;
            isRotating = false;
        }
    }

    public void takeCapacete()
    {
        if (!haveCapacete)
        {
            haveCapacete = true;
            capaceteObj = Instantiate(Item, Points[2].position, Points[2].rotation);
            CapaceteScript capaScript = capaceteObj.transform.GetComponent<CapaceteScript>();
            capaScript.FollowPlayer(this.gameObject);
        }
    }
    public void LoseCapacete()
    {
        haveCapacete = false;
        Destroy(capaceteObj);
    }
}
