using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyBox : MonoBehaviour
{



    private void Update()
    {
        transform.Rotate(Vector3.up * 30 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.parent != null)
        {
            // Obtém o objeto pai do objeto que acionou o gatilho
            GameObject parentObject = other.transform.parent.gameObject;
            //print(parentObject.name);
            ITouchable touchable = parentObject.GetComponent<ITouchable>();
            if (touchable != null)
            {
                touchable.touch(0);
                ReactiveLuckyBlock.main.startDeactive(this.gameObject);
                gameObject.SetActive(false);
            }
        }
    }


}
