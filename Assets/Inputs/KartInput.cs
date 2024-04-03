using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class KartInput : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private PlayerThrow playerScript;
    [SerializeField] private ArcadeKart kartScript;

    public bool accelerateBool;
    public bool brakeBool;
    public bool firingBool;

    public Vector2 turnFloat;

    private PlayerInput playerInputScript;

    private void Awake()
    {
        playerInputScript = GetComponent<PlayerInput>();
        
    }

    void Update()
    {
        kartScript.acceInput = accelerateBool;
    }

    public void OnAccelerate(CallbackContext ctx)
    {
        accelerateBool = ctx.performed;

    }
    public void OnBreak (CallbackContext ctx)
    {
        brakeBool = ctx.performed;
    }
    public void OnFire(CallbackContext ctx)
    {
        firingBool = ctx.performed;
    }

    public void OnTurn(CallbackContext ctx)
    {
        turnFloat = ctx.ReadValue<Vector2>();
    }
}
