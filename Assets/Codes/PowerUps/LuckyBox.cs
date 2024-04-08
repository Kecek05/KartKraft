using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyBox : MonoBehaviour
{

    [SerializeField] private float speedRotation;

    public float amplitude; // Amplitude do movimento
    public float frequency; // Frequência do movimento
    public float verticalSpeed; // Velocidade vertical
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position; // Salva a posição inicial
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * speedRotation * Time.deltaTime);


        // Calcula o deslocamento vertical usando uma função seno
        float verticalOffset = Mathf.Sin(Time.time * frequency) * amplitude;

        // Calcula a nova posição vertical
        float newYPosition = startPosition.y + verticalOffset;

        // Move o objeto para a nova posição vertical
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);

        // Move o objeto para cima e para baixo
        transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
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
