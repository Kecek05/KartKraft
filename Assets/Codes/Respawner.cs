using Cinemachine;
using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Respawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public CinemachineVirtualCamera[] virtualCameras;
    public Image[] imagensUI;
    public Image[] countDownImages;

    [SerializeField] private string p1FireButton;
    [SerializeField] private string p2FireButton;

    public Rigidbody p1Rigd;
    public Rigidbody p2Rigd;

    //Camera olhar para o objeto certo
    public GameObject[] cameraLook;
    void Start()
    {
        instantiatePlayers();
        StartCoroutine(CountDown());


    }

    private void instantiatePlayers()
    {
        for (int i = 0; i < KartSelector.main.confirmedCars.Length; i++)
        {
            GameObject carselected = KartSelector.main.confirmedCars[i];
            GameObject car = Instantiate(carselected, spawnPoints[i].position, spawnPoints[i].rotation); // instanciate

            //scripts
            PlayerThrow throwScript = car.transform.GetComponent<PlayerThrow>();
            if (i == 0)
            {
                throwScript.isP1 = 0;
                throwScript.fireButton = p1FireButton;
                p1Rigd = car.GetComponent<Rigidbody>();
            }
            else
            {
                throwScript.isP1 = 1;
                throwScript.fireButton = p2FireButton;
                p2Rigd = car.GetComponent<Rigidbody>();
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
            if (i == 0)
            {
                input.TurnInputName = "Horizontal";
                input.AccelerateButtonName = "Accelerate";
                input.BrakeButtonName = "Brake";

            }
            else if (i == 1)
            {
                input.TurnInputName = "HorizontalP2";
                input.AccelerateButtonName = "AccelerateP2";
                input.BrakeButtonName = "BrakeP2";
            }
        }
    }

    private IEnumerator CountDown()
    {
        p1Rigd.constraints = RigidbodyConstraints.FreezePosition;
        p2Rigd.constraints = RigidbodyConstraints.FreezePosition;
        countDownImages[0].gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        countDownImages[0].gameObject.SetActive(false);
        countDownImages[1].gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        countDownImages[1].gameObject.SetActive(false);
        countDownImages[2].gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        countDownImages[2].gameObject.SetActive(false);
        p1Rigd.constraints = RigidbodyConstraints.None;
        p2Rigd.constraints = RigidbodyConstraints.None;
    }
}
