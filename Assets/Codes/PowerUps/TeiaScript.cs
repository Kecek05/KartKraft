using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeiaScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.transform.parent.gameObject;
        if(obj != null)
        {
            ITouchable touchable = obj.gameObject.GetComponent<ITouchable>();
            if (touchable != null && obj.gameObject.tag == "Player")
            {
                touchable.touch(3);
                Destroy(this.gameObject);
            }

        }
    }

    
}
