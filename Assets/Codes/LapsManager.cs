using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LapsManager : MonoBehaviour
{
   
    public static LapsManager main;
    public int lapsP1;
    public int lapsP2;
    [SerializeField] private Image[] lapsUIP1;
    [SerializeField] private Image[] lapsUIP2;

    private void Awake()
    {
        main = this;
    }

    private void Update()
    {
        if(lapsP1 >= 3 || lapsP2 >= 3)
        {
            FinishGame();
        }
        updateLap(0);
        updateLap(1);
    }


    public void updateLap(int i)
    {
        if (i == 0) // player 1
        {
            if(lapsP1 == 1) // esta na 2
            {
                lapsUIP1[0].gameObject.SetActive(false);
                lapsUIP1[1].gameObject.SetActive(true);
            } else if (lapsP1 == 2) // estana 3
            {
                lapsUIP1[1].gameObject.SetActive(false);
                lapsUIP1[2].gameObject.SetActive(true);
            } 

        } else if(i == 1) // player 2
        {
            if (lapsP2 == 1) // esta na 2
            {
                lapsUIP2[0].gameObject.SetActive(false);
                lapsUIP2[1].gameObject.SetActive(true);
            }
            else if (lapsP2 == 2) // esta na 3
            {
                lapsUIP2[1].gameObject.SetActive(false);
                lapsUIP2[2].gameObject.SetActive(true);
            }
           
        }
    }

    private void FinishGame()
    {
        if(lapsP1 >= 3)
        {
            SceneManager.LoadSceneAsync("WinSceneP1");
        } else if (lapsP2 >= 3)
        {
            SceneManager.LoadSceneAsync("WinSceneP2");
        }
    }
}
