using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    private void Awake()
    {
        // Mant�m este GameObject ativo entre as cenas
        DontDestroyOnLoad(gameObject);
    }
}
