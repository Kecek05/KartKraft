using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{

    public static SkillsManager main;
    public GameObject[] powerUpsArray;


    [Header("PowerUps")]
    public float StunTime;

    private void Awake()
    {
        main = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    //public void hitSkill(GameObject Player)
    //{
    //    print("nome player " + Player.name);
    //}



    public GameObject getPowerUp()
    {
        int randomPower = Random.Range(0, powerUpsArray.Length);

        return powerUpsArray[randomPower];
    }

}
