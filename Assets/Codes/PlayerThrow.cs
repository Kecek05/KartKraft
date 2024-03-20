using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour, ITouchable
{
    [SerializeField] private Transform PointFront;
    public GameObject Item;
    [SerializeField] private ArcadeKart KartScript;
    private float PreviousTopSpeed;
    [SerializeField] private float StunTime;

    public void touch(int type)
    {
       if(type == 0)
        {
            PreviousTopSpeed = KartScript.baseStats.TopSpeed;
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
                Instantiate(Item, PointFront.position, PointFront.rotation);
            }

        }
    }

    private IEnumerator StunTaken()
    {
        KartScript.baseStats.TopSpeed = 0;
        yield return new WaitForSeconds(StunTime);
        KartScript.baseStats.TopSpeed = PreviousTopSpeed;
    }
    
}
