using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeiaScript : MonoBehaviour, ITouchable
{
    public void touch(int type)
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameObject obj = other.transform.parent.gameObject;
            ITouchable touchable = obj.gameObject.GetComponent<ITouchable>();
            if (touchable != null)
            {
                touchable.touch(3);
                Destroy(this.gameObject);
            }

        } else
        {
            ITouchable touchable = other.gameObject.GetComponent<ITouchable>();
            if (touchable != null)
            {
                touchable.touch(3);
                Destroy(this.gameObject);
            }
        }
        
    }

    
}
