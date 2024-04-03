using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class testeInput : MonoBehaviour
{
    [SerializeField] private PlayerThrow playerScript;
    [SerializeField] private ArcadeKart kartScript;
    PlayerInput controls;

    public bool accelerateBool;
    public bool brakeBool;
    public bool firingBool;

    public Vector2 turnFloat;

    private void Awake()
    {
        controls = new PlayerInput();

        controls.Gameplay.Turn.performed += ctx => turnFloat = ctx.ReadValue<Vector2>();
        controls.Gameplay.Turn.canceled += ctx => turnFloat = Vector2.zero;

        controls.Gameplay.Accelerate.performed += ctx => accelerateBool = true;
        controls.Gameplay.Accelerate.canceled += ctx => accelerateBool = false;

        controls.Gameplay.Brake.performed += ctx => brakeBool = true;
        controls.Gameplay.Brake.canceled += ctx => brakeBool = false;

        controls.Gameplay.Fire.performed += ctx => firingBool = true;
        controls.Gameplay.Fire.canceled += ctx => firingBool = false;
    }
    private void Update()
    {
        playerScript.atirando = firingBool;
        kartScript.turnotherInput = turnFloat.x;
        kartScript.brakeInput = brakeBool;
        kartScript.acceInput = accelerateBool;
        print(turnFloat + " VALOR TURN");
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
