using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npc_monster : MonoBehaviour {

    public float moveSpeed;
    public float rotationSpeed;
    [Space(10)]
    public float sightFOV;
    public float sightDistance;
    [Space(10)]
    public float hearingStrength;

    private GameObject focusObject;
    private NavMeshAgent navAgent;

    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Transform test = GameObject.FindGameObjectWithTag("player").transform;

        Vector3 focusPos = new Vector3(test.position.x, transform.position.y, test.position.z);

        LookTowards(focusPos);
        navAgent.Move(transform.forward * moveSpeed * Time.deltaTime);
    }

    void LookTowards(Vector3 focusPoint)
    {
        Vector3 focusVector = focusPoint - transform.position;
        Quaternion focusDirection = Quaternion.LookRotation(focusVector, Vector3.up);

        Vector3 bodyAngle = new Vector3(0, transform.eulerAngles.y, 0);
        Vector3 focusAngle = new Vector3(0, focusDirection.eulerAngles.y, 0);
        float bodyFocusDifference = Mathf.DeltaAngle(bodyAngle.y, focusAngle.y);
        bodyFocusDifference = Mathf.Abs(bodyFocusDifference);

        Debug.Log(bodyFocusDifference);

        transform.rotation = Quaternion.RotateTowards(Quaternion.Euler(bodyAngle), Quaternion.Euler(focusAngle), (bodyFocusDifference / 50f) * rotationSpeed * GameLogic.deltaMod());
    }
}
