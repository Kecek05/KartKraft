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
    // Start is called before the first frame update
    void Start()
    {
        GameObject carselected = KartSelector.selectedCarObj;
        GameObject car = Instantiate(carselected, spawnPoints[0].position, spawnPoints[0].rotation);
        virtualCamera.Follow = car.transform;
        virtualCamera.LookAt = car.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
