using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_zombieController : MonoBehaviour {

    public Transform huntedEnemy;
    [Space(10)]
    public NavMeshAgent navAgent;

	void Update () {

        navAgent.SetDestination(huntedEnemy.position);
    }
}
