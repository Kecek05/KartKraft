using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KartSelector : MonoBehaviour
{

    public static KartSelector main;

    [SerializeField] private GameObject BlinkObj;
    private int playerChossing = 0; 
    public GameObject[] cartList;
    public int selectedCar = 0;

    public bool canSelect;
    
    public GameObject currentCar;
    public GameObject carousel;
    public string SceneName;

    public GameObject[] confirmedCars;

    [SerializeField] private GameObject[] lblPlayer;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        canSelect = true;
    }

    private void Update()
    {
        currentCar = cartList[selectedCar];
        carousel.transform.position = Vector3.Lerp(carousel.transform.position,new Vector3(selectedCar * -7,0,0), Time.deltaTime * 3);

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
        if(playerChossing == 0 && canSelect)
        {
            confirmedCars[0] = cartList[selectedCar];
            canSelect = false;
            StartCoroutine(blinkChoice());
           
        } else if(playerChossing == 1 && canSelect)
        {
            confirmedCars[1] = cartList[selectedCar];
            canSelect = false;
            SceneManager.LoadScene(SceneName);
        }
    }

    private IEnumerator blinkChoice()
    {
        BlinkObj.SetActive(true);
        yield return new WaitForSeconds(2f);
        lblPlayer[0].SetActive(false);
        lblPlayer[1].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        playerChossing += 1;
        BlinkObj.SetActive(false);
        canSelect = true;
    }
}
