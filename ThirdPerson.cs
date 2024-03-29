﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    public float distanceAway;          // distance from the back of the craft
    public float distanceUp;            // distance above the craft
    public float smooth;                // how smooth the camera movement is
    public float acima;

    private GameObject hovercraft;      // to store the hovercraft
    private Vector3 targetPosition;     // the position the camera is trying to be in

    Transform follow;

    void Start()
    {
        follow = GameObject.FindWithTag("Player").transform;
        follow.transform.position = new Vector3(follow.transform.position.x,
                                                 follow.transform.position.y,
                                                 follow.transform.position.z);
    }

    void LateUpdate()
    {
        follow.transform.position = new Vector3(follow.transform.position.x,
                                                 follow.transform.position.y,
                                                 follow.transform.position.z);
        // setting the target position to be the correct offset from the hovercraft
        targetPosition = follow.position + Vector3.up * distanceUp - follow.forward * distanceAway;

        // making a smooth transition between it's current position and the position it wants to be in
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);

        // make sure the camera is looking the right way!
        transform.LookAt(follow.position + Vector3.up * acima);
    }
}
