using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorInimigos : MonoBehaviour
{
    // Start is called before the first frame update

    public int quantidadeInimigos = 1;

    public int qtdMaxima = 5;

    public float tempoSpawn;
    private float tempo;

    public GameObject inimigo;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        tempo += Time.deltaTime;
        if (tempo > tempoSpawn)
        {

            Instantiate(inimigo, this.transform.position, this.transform.rotation);
            tempo = 0;
        }

    }
}
