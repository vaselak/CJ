using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    public void Collect(GameObject collector)
    {
        if (collector.tag == "Enemy")
        {
            transform.position = collector.GetComponent<Enemy>().dragPoint.position;
            transform.parent = collector.GetComponent<Enemy>().dragPoint;
        }

        if (collector.tag == "Player")
        {
            transform.parent = null;
            transform.position = startPos;
        }
    }

}
