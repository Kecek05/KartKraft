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
    void Start()
    {

        for (int i = 0; i < KartSelector.main.confirmedCars.Length; i++)
        {
            GameObject carselected = KartSelector.main.confirmedCars[i];
            GameObject car = Instantiate(carselected, spawnPoints[i].position, spawnPoints[i].rotation); // instanciate

            //scripts
            PlayerThrow throwScript = car.transform.GetComponent<PlayerThrow>();
            if(i == 0)
            {
                throwScript.isP1 = 0;
            } else
            {
                throwScript.isP1 = 1;
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
            virtualCameras[i].LookAt = cameraLook[0].transform;

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

    }

}
