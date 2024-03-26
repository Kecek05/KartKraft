using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SkillsManager : MonoBehaviour
{

    public static SkillsManager main;
    public GameObject[] powerUpsArray;


    [Header("PowerUps")]
    public float stunTime;
    public float MiniZombiestunTime;
    public float potionSpeedDuration;
    public float potionSpeedAccAdd;
    public float potionSpeedTopSpeedAdd;

    private void Awake()
    {
        main = this;
    }


    public GameObject getPowerUp()
    {
        int randomPower = Random.Range(0, powerUpsArray.Length);

        return powerUpsArray[randomPower];
    }

}
