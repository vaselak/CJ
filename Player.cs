using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private float speed;

    public float rotSpeed;

    public float jumpForce;

    //novo
    public GameObject Bullet;
    public GameObject Arma;

    public float tempoTiro = 0;

    //vidaJogo
    public int gameLife;
    public int life;
    public static Player instance;



    //animaator
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        instance = this;

    }



    void FixedUpdate()
    {
        //Movimentação
        transform.Translate(0, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        if (Input.GetAxis("Vertical") != 0 && !Input.GetButton("Run"))
        {

            speed = 3;
            anim.SetBool("andando", true);

        }
        else
            anim.SetBool("andando", false);

        //Direção
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime, 0);



    }


    void Update()
    {
        if (Input.GetButton("Run") && (Input.GetAxis("Vertical") != 0))
        {
            anim.SetBool("correndo", true);
            speed = 10;
            StartCoroutine("Esperar");


        }
        else
            anim.SetBool("correndo", false);


        // condiçoes de derrotas ou vitorias
        if (gameLife <= 0 || life <= 0)
        {
            SceneManager.LoadScene("Lose");

        }
        if (GM.instance.tempo <= 0)
        {
            SceneManager.LoadScene("Win");
        }


        // tiro
        tempoTiro += Time.deltaTime;

        if (tempoTiro > 0)
        {
            if (Input.GetButtonDown("Fire"))
            {
                anim.SetTrigger("atirando");
               

                tempoTiro = 0;
            }

        }



    }


    IEnumerator Esperar()
    {
        yield return new WaitForSeconds (0000.1f);
        anim.SetBool("andando", false);

    }

    void Atirar()
    {
        Instantiate(Bullet, Arma.transform.position, Arma.transform.rotation);
        SoundsEffects.Instance.MakeThroow();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            other.GetComponent<Item>().Collect(this.gameObject);
            SoundsEffects.Instance.MakeRecupItem();
        }
    }




}
