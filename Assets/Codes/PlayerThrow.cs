using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using UnityEngine;

public class PlayerThrow : MonoBehaviour, ITouchable
{
    public bool isP1;
    [SerializeField] private UIPowerUp UiPower;
    [SerializeField] private Transform[] Points;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private ArcadeKart kartScript;
    [SerializeField] private GameObject particleSpeed;
    [SerializeField] private float stunRotationSpeed;

    public GameObject Item;

    [SerializeField] private Transform[] pecasCarro;
    private bool isRotating;
   

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
            rotateStart(SkillsManager.main.stunTime);
            
       } else if (type == 2) // MiniZombie
       {
            StartCoroutine(MiniZombieStunTaken());
            rotateStart(SkillsManager.main.MiniZombiestunTime);

        } else if (type == 3) // teia
        {
            StartCoroutine(TeiaStunTaken());
            rotateStart(SkillsManager.main.teiaStunDuration);
 
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
                }
                else
                {
                    Instantiate(Item, Points[0].position, Points[0].rotation);
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
            stunFeedback(time);
            isRotating = true;
        }
    }

    private IEnumerator stunFeedback(float time)
    {

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
       transform.rotation = positionInit;
       isRotating = false;
    }
}
