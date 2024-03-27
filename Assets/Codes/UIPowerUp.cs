using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIPowerUp : MonoBehaviour
{
    //public static UIPowerUp main;
    public Sprite[] itensSprite;
    public Image imagemUI;

    //private void Awake()
    //{
    //    main = this;
    //}

    public void itemToUI(GameObject item, bool noItem) // verifica a tag do gameobject para mudar o sprite na UI
    {
        if (noItem)
        {
            imagemUI.enabled = false;
            return;
        } else
        {
            imagemUI.enabled = true;
        }
        
        if (item.gameObject.tag == "SnowBall")
        {
            imagemUI.sprite = itensSprite[0];
        }
        else if(item.gameObject.tag == "PocaoSpeed")
        {
            imagemUI.sprite = itensSprite[1];
        } else if (item.gameObject.tag == "MiniZombie")
        {
            imagemUI.sprite = itensSprite[2];
        }


    }
}
