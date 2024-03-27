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
        GameObject carselected = KartSelector.selectedCarObj;
        GameObject car = Instantiate(carselected, spawnPoints[0].position, spawnPoints[0].rotation);
        UIPowerUp uiP1 = car.transform.GetComponent<UIPowerUp>();
        uiP1.imagemUI = imagensUI[0];
        PlayerThrow throwP1 = car.transform.GetComponent<PlayerThrow>();
        throwP1.isP1 = true;

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

        virtualCameras[0].Follow = car.transform;
        virtualCameras[0].LookAt = cameraLook[0].transform;

        KeyboardInput input = car.GetComponent<KeyboardInput>();
        input.TurnInputName = "Horizontal";
        input.AccelerateButtonName = "Accelerate";
        input.BrakeButtonName = "Brake";

        GameObject carselected2 = KartSelector.selectedCarObj2Player;
        GameObject car2 = Instantiate(carselected2, spawnPoints[1].position, spawnPoints[1].rotation);
        UIPowerUp uiP2 = car2.transform.GetComponent<UIPowerUp>();
        uiP2.imagemUI = imagensUI[1];
        PlayerThrow throwP2 = car2.transform.GetComponent<PlayerThrow>();
        throwP2.isP1 = false;


        Transform[] children2 = car2.transform.GetComponentsInChildren<Transform>();
        cameraLook2 = new GameObject[children2.Length];
        int index2 = 0;
        foreach (Transform child2 in children2)
        {
            if (child2.name == "KartBouncingCapsule")
            {
                cameraLook2[index2++] = child2.gameObject;
                break;
            }
        }


        virtualCameras[1].Follow = car2.transform;
        virtualCameras[1].LookAt = cameraLook2[0].transform;

        KeyboardInput input2 = car2.GetComponent<KeyboardInput>();
        input2.TurnInputName = "HorizontalP2";
        input2.AccelerateButtonName = "AccelerateP2";
        input2.BrakeButtonName = "BrakeP2";
    }

}
