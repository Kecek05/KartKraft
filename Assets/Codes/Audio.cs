using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    private void Awake()
    {
        // Mantém este GameObject ativo entre as cenas
        DontDestroyOnLoad(gameObject);
    }
}
