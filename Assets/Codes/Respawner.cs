using Cinemachine;
using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Respawner : MonoBehaviour
{

    public GameObject[] carList;
    public Transform[] spawnPoints;
    public CinemachineVirtualCamera[] virtualCameras;
    public Image[] imagensUI;

    //Camera olhar para o objeto certo
    public GameObject[] cameraLook;
    public GameObject[] cameraLook2;
    void Start()
    {

        for (int i = 0; i < KartSelector.main.confirmedCars.Length; i++)
        {
            GameObject carselected = KartSelector.main.confirmedCars[i];
            GameObject car = Instantiate(carselected, spawnPoints[i].position, spawnPoints[i].rotation); // instanciate

            //scripts
            UIPowerUp ui = car.transform.GetComponent<UIPowerUp>();
            ui.imagemUI = imagensUI[i];
            if(i == 0)
            {
                PlayerThrow throwScript = car.transform.GetComponent<PlayerThrow>();
                throwScript.isP1 = true;
            }

            //camera
            Transform[] children = car.transform.GetComponentsInChildren<Transform>();
            cameraLook = new GameObject[children.Length];
            int index = 0;
            foreach (Transform child in children)
            {
                if (child.name == "KartBouncingCapsule")
                {
                    cameraLook[index++] = child.gameObject;
                    break;
                }
            }

            virtualCameras[i].Follow = car.transform;
            virtualCameras[i].LookAt = cameraLook[i].transform;

            //inputs
            KeyboardInput input = car.GetComponent<KeyboardInput>();
            if(i == 0)
            {
                input.TurnInputName = "Horizontal";
                input.AccelerateButtonName = "Accelerate";
                input.BrakeButtonName = "Brake";

            } else if (i == 1)
            {
                input.TurnInputName = "HorizontalP2";
                input.AccelerateButtonName = "AccelerateP2";
                input.BrakeButtonName = "BrakeP2";
            }




        }

        





        //GameObject carselected2 = KartSelector.selectedCarObj2Player;
        //GameObject car2 = Instantiate(carselected2, spawnPoints[1].position, spawnPoints[1].rotation);
        //UIPowerUp uiP2 = car2.transform.GetComponent<UIPowerUp>();
        //uiP2.imagemUI = imagensUI[1];
        //PlayerThrow throwP2 = car2.transform.GetComponent<PlayerThrow>();
        //throwP2.isP1 = false;


        //Transform[] children2 = car2.transform.GetComponentsInChildren<Transform>();
        //cameraLook2 = new GameObject[children2.Length];
        //int index2 = 0;
        //foreach (Transform child2 in children2)
        //{
        //    if (child2.name == "KartBouncingCapsule")
        //    {
        //        cameraLook2[index2++] = child2.gameObject;
        //        break;
        //    }
        //}


        //virtualCameras[1].Follow = car2.transform;
        //virtualCameras[1].LookAt = cameraLook2[0].transform;

        //KeyboardInput input2 = car2.GetComponent<KeyboardInput>();
        
    }

}
