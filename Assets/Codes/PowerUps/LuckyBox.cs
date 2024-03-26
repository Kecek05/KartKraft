using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyBox : MonoBehaviour
{





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
                gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        //StartCoroutine(SkillsManager.main.reactive(this.gameObject));
        ReactiveLuckyBlock.main.startDeactive(this.gameObject);
    }


}
