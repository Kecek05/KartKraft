using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Respawner : MonoBehaviour
{

    public GameObject[] carList;
    public Transform[] spawnPoints;
    public CinemachineVirtualCamera virtualCamera;


    //Camera olhar para o objeto certo
    public GameObject[] cameraLook;
    void Start()
    {
        GameObject carselected = KartSelector.selectedCarObj;
        GameObject car = Instantiate(carselected, spawnPoints[0].position, spawnPoints[0].rotation);

        Transform[] children = car.transform.GetComponentsInChildren<Transform>();
        cameraLook = new GameObject[children.Length];
        int index = 0;
        foreach (Transform child in children)
        {
            if (child.name == "KartBouncingCapsule")
            {
                cameraLook[index++] = child.gameObject;
            }
        }

        virtualCamera.Follow = car.transform;
        virtualCamera.LookAt = cameraLook[0].transform;
    }

}
