using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float tempo;
    //private UIManager UIManager;
    public float bala;

    //public GameObject sangue;
    //public GameObject terra;


    //public GerenciadorInimigos _gerenciadorInimigos;
    void Start()
    {
        //_gerenciadorInimigos = GameObject.FindWithTag("gerenciador").GetComponent<GerenciadorInimigos>();
        //UIManager = GameObject.FindWithTag("score").GetComponent<UIManager>();
        GetComponent<Rigidbody>().AddForce(transform.forward * bala);
        


    }

    void FixedUpdate()
    {
        
    }

    void Update()
    {
        //transform.Translate(0, 0, bala * Time.deltaTime);
        //GetComponent<Rigidbody>().velocity = transform.forward * bala * Time.deltaTime;

        tempo += Time.deltaTime;

        if (tempo >= 4)
        {

            Destroy(this.gameObject);
        }
    }


   /* void OnCollisionEnter(Collision objetoColidido)
    {
        if (objetoColidido.gameObject.tag == "Enemy")
        {

            Instantiate(sangue, transform.position, transform.rotation);
            Destroy(objetoColidido.gameObject);
            _gerenciadorInimigos.quantidadeInimigos--;
            UIManager.ScoreUp();

        }
        if (objetoColidido.gameObject.tag == "terreno")
        {
            Instantiate(terra, transform.position, transform.rotation);
        }
        Destroy(this.gameObject);


    } */
}
