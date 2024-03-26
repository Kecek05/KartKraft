using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPowerUp : MonoBehaviour
{
    public static UIPowerUp main;
    public Sprite[] itensSprite;
    public Image imagemUI;

    private void Awake()
    {
        main = this;
    }

    public void itemToUI(GameObject item)
    {
        if (item == null)
        {
            imagemUI.sprite = null;
        } else if (item.gameObject.tag == "SnowBall")
        {
            imagemUI.sprite = itensSprite[0];
        }
        else if(item.gameObject.tag == "PocaoSpeed")
        {
            imagemUI.sprite = itensSprite[1];
        }


    }
}
