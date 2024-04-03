using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour, ICheckpointable
{

    [SerializeField] private PlayerThrow playerScript;
    [SerializeField] private bool[] checkedPoints;
    public bool canNextLap;
    public bool allChecked;

    public void check(int index)
    {
        checkedPoints[index] = true;
    }

    private void Update()
    {
   
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "FinishLine")
        {
            allChecked = true;
            foreach (bool item in checkedPoints)
            {
                if (!item)
                {
                    allChecked = false;
                    break;
                }
            }
            if(allChecked) // passou em todos os checks e passou na linha de chegada
            {
                print("NEXT LAP");
                if(playerScript.isP1 == 0)
                {
                    LapsManager.main.lapsP1 += 1;
                    LapsManager.main.updateLap(0);
                } else
                {
                    LapsManager.main.lapsP2 += 1;
                    LapsManager.main.updateLap(1);
                }
                for (int i = 0; i < checkedPoints.Length; i++)
                {
                    checkedPoints[i] = false;
                }
            }

        }
    }

}
