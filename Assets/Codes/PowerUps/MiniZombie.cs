using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MiniZombie : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField]private GameObject father;
    [SerializeField] private GameObject target;
    [SerializeField] private float speed;
    [SerializeField] float dieTime;

    void Start()
    {
        FindFather();
        FindTarget();
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
        if (touchable != null && collision.gameObject.tag == "Player")
        {
            touchable.touch(2);
            Destroy(this.gameObject);
        }
    }



    private void FindTarget()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        // Verifica se h� pelo menos dois jogadores
        if (players.Length > 0)
        {
            // Cria uma lista para armazenar as dist�ncias dos jogadores
            List<Tuple<GameObject, float>> distances = new List<Tuple<GameObject, float>>();

            // Calcula a dist�ncia de cada jogador para o inimigo e adiciona ao lista
            foreach (GameObject player in players)
            {
                float distance = Vector3.Distance(transform.position, player.transform.position);
                distances.Add(new Tuple<GameObject, float>(player, distance));
            }

            // Ordena a lista de acordo com as dist�ncias
            distances.Sort((x, y) => x.Item2.CompareTo(y.Item2));

            // O segundo jogador mais pr�ximo � o segundo item na lista (�ndice 1)
            target = distances[3].Item1;
        }
        print(target + " TARGET");
    }

    private void FindFather()
    {
        //GameObject[] playersTarget = GameObject.FindGameObjectsWithTag("Player");
        //if (playersTarget.Length > 0)
        //{
        //    float shortestDistance = Vector3.Distance(transform.position, playersTarget[0].transform.position);
        //    for (int i = 0; i < playersTarget.Length; i++)
        //    {
        //        float distance = Vector3.Distance(transform.position, playersTarget[i].transform.position);
        //        if (distance < shortestDistance)
        //        {
        //            shortestDistance = distance;
        //            father = playersTarget[i];
        //        }
        //    }
        //}


        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        // Verifica se h� pelo menos dois jogadores
        if (players.Length > 0)
        {
            // Cria uma lista para armazenar as dist�ncias dos jogadores
            List<Tuple<GameObject, float>> distances = new List<Tuple<GameObject, float>>();

            // Calcula a dist�ncia de cada jogador para o inimigo e adiciona ao lista
            foreach (GameObject player in players)
            {
                float distance = Vector3.Distance(transform.position, player.transform.position);
                distances.Add(new Tuple<GameObject, float>(player, distance));
            }

            // Ordena a lista de acordo com as dist�ncias
            distances.Sort((x, y) => x.Item2.CompareTo(y.Item2));

            // O segundo jogador mais pr�ximo � o segundo item na lista (�ndice 1)
            father = distances[0].Item1;
        }
        print(father + " FATHER");
    }
}
