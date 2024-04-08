using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MiniZombie : MonoBehaviour, ITouchable
{
    [SerializeField] private float rotationSpeed;
    [SerializeField]private GameObject father;
    [SerializeField] private GameObject target;
    [SerializeField] private float speed;
    [SerializeField] float dieTime;

    public void touch(int type)
    {
        Destroy(this.gameObject);
    }

    private void Awake()
    {
        FindAlvo();
    }
    void Start()
    {

        Destroy(this.gameObject, dieTime);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        Vector3 direction = target.transform.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print("COLISAO  " + collision.gameObject.name);
        if (collision.gameObject == father)
            return;
        ITouchable touchable = collision.gameObject.GetComponent<ITouchable>();
        if (touchable != null)
        {
            touchable.touch(2);
            Destroy(this.gameObject);
        }
    }

    private void FindAlvo()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        // Verifica se há pelo menos dois jogadores
        if (players.Length > 0)
        {
            // Cria uma lista para armazenar as distâncias dos jogadores
            List<Tuple<GameObject, float>> distances = new List<Tuple<GameObject, float>>();

            // Calcula a distância de cada jogador para o inimigo e adiciona ao lista
            foreach (GameObject player in players)
            {
                float distance = Vector3.Distance(transform.position, player.transform.position);
                distances.Add(new Tuple<GameObject, float>(player, distance));
            }

            // Ordena a lista de acordo com as distâncias
            distances.Sort((x, y) => x.Item2.CompareTo(y.Item2));

         
            father = distances[0].Item1;
            target = distances[3].Item1;
            
        }
    }

   
}
