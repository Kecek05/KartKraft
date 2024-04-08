using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyBox : MonoBehaviour
{

    [SerializeField] private float speedRotation;

    public float amplitude; // Amplitude do movimento
    public float frequency; // Frequ�ncia do movimento
    public float verticalSpeed; // Velocidade vertical
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position; // Salva a posi��o inicial
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * speedRotation * Time.deltaTime);


        // Calcula o deslocamento vertical usando uma fun��o seno
        float verticalOffset = Mathf.Sin(Time.time * frequency) * amplitude;

        // Calcula a nova posi��o vertical
        float newYPosition = startPosition.y + verticalOffset;

        // Move o objeto para a nova posi��o vertical
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);

        // Move o objeto para cima e para baixo
        transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.parent != null)
        {
            // Obt�m o objeto pai do objeto que acionou o gatilho
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
