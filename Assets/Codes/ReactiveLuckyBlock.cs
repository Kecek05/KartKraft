using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveLuckyBlock : MonoBehaviour
{
    public static ReactiveLuckyBlock main;

    public float delayReactive;

    private void Awake()
    {
        main = this;
    }
    public IEnumerator reactive(GameObject obj)
    {
        yield return new WaitForSeconds(delayReactive);
        obj.gameObject.SetActive(true);
    }
    public void startDeactive(GameObject obj)
    {
        StartCoroutine(reactive(obj));
    }
}
