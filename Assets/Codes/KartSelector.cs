using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KartSelector : MonoBehaviour
{

    public GameObject[] cartList;
    public int selectedCar = 0;
    public GameObject currentCar;
    public GameObject carousel;
    public string SceneName;
    public static GameObject selectedCarObj;

    private void Update()
    {
        currentCar = cartList[selectedCar];
        carousel.transform.position = Vector3.Lerp(carousel.transform.position,new Vector3(selectedCar * -7,0,0), Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightKartSelector();
        } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftKartSelector();
        }
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
        selectedCarObj = cartList[selectedCar];
        SceneManager.LoadScene(SceneName);
    }
}
