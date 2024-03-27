using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KartSelector : MonoBehaviour
{
    private int playerChossing = 0; 
    public TextMeshProUGUI txtPlayer;
    public GameObject[] cartList;
    public int selectedCar = 0;
    
    public GameObject currentCar;
    public GameObject carousel;
    public string SceneName;
    public static GameObject selectedCarObj;
    public static GameObject selectedCarObj2Player;

    private void Update()
    {
        currentCar = cartList[selectedCar];
        carousel.transform.position = Vector3.Lerp(carousel.transform.position,new Vector3(selectedCar * -7,0,0), Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            RightKartSelector();
        } else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            LeftKartSelector();
        }
        if(Input.GetKeyDown(KeyCode.Space)) 
            SelectCar();
    }

    public void RightKartSelector()
    {
        selectedCar++;

        if (selectedCar > cartList.Length - 1)
        {
            selectedCar = 0;
        }

    }
    public void LeftKartSelector()
    {
        selectedCar--;
        if (selectedCar < 0)
        {
            selectedCar = cartList.Length - 1;
        }
      
    }

    public void SelectCar()
    {
        if(playerChossing == 0)
        {
            selectedCarObj = cartList[selectedCar];
            
            txtPlayer.text = "Player 2";
            playerChossing += 1;
        } else if(playerChossing == 1)
        {
            selectedCarObj2Player = cartList[selectedCar];
            SceneManager.LoadScene(SceneName);
        }
    }
}
