using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour, ICheckpointable
{


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
            if(allChecked)
            {
                //canNextLap = true;
                print("NEXT LAP");

                for (int i = 0; i < checkedPoints.Length; i++)
                {
                    checkedPoints[i] = false;
                }
            }

        }
    }

}
