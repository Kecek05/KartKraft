using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIPowerUp : MonoBehaviour
{
    public static UIPowerUp main;
    public Sprite[] itensSprite;
    public Image[] imagensUI;

    public Image[] lapsUI;

    private void Awake()
    {
        main = this;
    }

    public void itemToUI(GameObject item, bool noItem, int i) // verifica a tag do gameobject para mudar o sprite na UI
    {
        if (noItem)
        {
            imagensUI[i].enabled = false;
            return;
        } else
        {
            imagensUI[i].enabled = true;
        }
        
        if (item.gameObject.tag == "SnowBall")
        {
            imagensUI[i].sprite = itensSprite[0];
        }
        else if(item.gameObject.tag == "PocaoSpeed")
        {
            imagensUI[i].sprite = itensSprite[1];
        } else if (item.gameObject.tag == "MiniZombie")
        {
            imagensUI[i].sprite = itensSprite[2];
        } else if (item.gameObject.tag == "Teia")
        {
            imagensUI[i].sprite = itensSprite[3];
        } else if (item.gameObject.tag == "Capacete")
        {
            imagensUI[i].sprite = itensSprite[4];
        }


    }

 
}
