using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnowBall : MonoBehaviour, ITouchable
{
    [SerializeField] private GameObject father;
    [SerializeField] private float speed;

    [SerializeField] private Rigidbody rb;
    [SerializeField] float dieTime;

    void Start()
    {
        FindFather();
        rb.velocity = transform.forward * speed;
        Destroy(this.gameObject, dieTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == father)
            return;
        ITouchable touchable = collision.gameObject.GetComponent<ITouchable>();
        if (touchable != null)
        {
            touchable.touch(1);
            Destroy(this.gameObject);
        }
    }

    public void touch(int type)
    {
        Destroy(this.gameObject);
    }


    private void FindFather()
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
        }
    }
}
