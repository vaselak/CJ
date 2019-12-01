using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public Transform[] itens;
    public Transform item;
    public Transform player;
    public Transform[] endPoints;
    public Transform endPoint;
    public float range;
    NavMeshAgent agent;
    public Transform dragPoint;
    public float atackRange;
    private bool canAtack = true;

    private bool dead = false;


    //vida
    public int life;

    //animator
    Animator anim;

    void Start()
    {
        player = GameObject.Find("Player").transform;

        itens[0] = GameObject.Find("item").transform;
        itens[1] = GameObject.Find("item2").transform;
        itens[2] = GameObject.Find("item3").transform;

        endPoints[0] = GameObject.Find("Ponto1").transform;
        endPoints[1] = GameObject.Find("Ponto2").transform;
        endPoints[2] = GameObject.Find("Ponto3").transform;
        endPoints[3] = GameObject.Find("Ponto4").transform;
        agent = GetComponent<NavMeshAgent>();
        item = itens[Random.Range(0, itens.Length)];
        target = item;
        agent.SetDestination(target.position);
        endPoint = endPoints[Random.Range(0, endPoints.Length)];
        
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {

        if (dead == false)
        {
            //Se estiver com o item
            if (dragPoint.childCount > 0)
            {
                agent.destination = target.position;
                
                if (transform.position.x == endPoint.position.x && transform.position.z == endPoint.position.z)
                {
                    GameObject.Find("Player").GetComponent<Player>().gameLife--;
                    Destroy(gameObject);
                }
            }
            else
            {
                //Seguir o player
                if (Vector3.Distance(transform.position, player.position) < range)
                {

                    target = player;
                    agent.SetDestination(target.position);
                    if (Vector3.Distance(transform.position, player.position) < atackRange)
                    {
                        if (canAtack)
                        {
                            Atack();
                            StartCoroutine(AtackCooldown());
                        }
                        agent.isStopped = true;
                    }
                    else
                    {
                        agent.isStopped = false;
                    }
                }
                //Seguir o item
                else
                {
                    target = item;
                    agent.SetDestination(target.position);
                }

                //Pegar o item ao chegar perto
                if (target == item && transform.position.x == agent.destination.x && transform.position.z == agent.destination.z)
                {
                    SoundsEffects.Instance.MakeAlertSound();
                    SoundsEffects.Instance.MakePegaSound();
                    item.GetComponent<Item>().Collect(this.gameObject);
                    target = endPoint;
                    agent.SetDestination(target.position);
                }

                //detecção de final

            }
           
        
        }
        else
        {
            agent.isStopped = true;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" && !dead)
        {
            life--;
            SoundsEffects.Instance.MakeTakeDamage();
            anim.SetTrigger("TakeDamage");
           
            if (life <= 0)
            {
                Die();
            }
        }

    }



    void Die()
    {
        //aqui coloco a animaçao
        if (dragPoint.childCount > 0)
        {
            dragPoint.GetChild(0).position = transform.position;
            dragPoint.GetChild(0).parent = null;
            anim.SetTrigger("Die");
           
        }

        dead = true;
        anim.SetTrigger("Die");
        StartCoroutine(Dead());

    }

    IEnumerator AtackCooldown()
    {
        yield return new WaitForSeconds(3.0f);
        canAtack = true;

    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);

    }

    IEnumerator Speak()
    {
        yield return new WaitForSeconds(2.0f);
        SoundsEffects.Instance.MakeMovimentada();
    }



    void Atack()
    {
        anim.SetTrigger("Atack");
        StartCoroutine(Damage());
        canAtack = false;
    }

    IEnumerator Damage()
    {
        yield return new WaitForSeconds(0.5f);
        if (Vector3.Distance(transform.position, player.position) < atackRange)
        {
            GameObject.Find("Player").GetComponent<Player>().life--;
            SoundsEffects.Instance.MakeAiSound();
            StartCoroutine(Speak());
            GameObject.Find("Main Camera").GetComponent<Animator>().SetTrigger("Shake");
            

        }
    }

   

    



}

