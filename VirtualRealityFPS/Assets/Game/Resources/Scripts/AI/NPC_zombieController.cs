using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_zombieController : MonoBehaviour {

    public Transform huntedEnemy;
    public Transform zombieChar;
    public float zombieSpeed;
    [Space(10)]
    public Transform[] missingGroup1;
    public Transform[] missingGroup2;
    public Transform[] missingGroup3;
    [Space(10)]
    public NavMeshAgent navAgent;

    void Start()
    {
        Animator NPCAnimator = zombieChar.GetComponent<Animator>();
        float NPCSpeedVariation = zombieSpeed / 1.5f;
        float NPCScaleVariation = Random.Range(0.9f, 1.1f);

        navAgent.speed = Random.Range(zombieSpeed - NPCSpeedVariation, zombieSpeed + NPCSpeedVariation);
        zombieChar.localScale = new Vector3(NPCScaleVariation, NPCScaleVariation, NPCScaleVariation);
        NPCAnimator.Play("zombieFastWalk", 0, Random.Range(zombieSpeed - NPCSpeedVariation, zombieSpeed + NPCSpeedVariation) / zombieSpeed);


        List<int> list = new List<int>();   //  Declare list

        for (int n = 0; n < 3; n++)    //  Populate list
        {
            list.Add(n);
        }

        int index = Random.Range(0, list.Count);    //  Pick random element from the list
        int i = list[index];    //  i = the number that was randomly picked
        list.RemoveAt(index);   //  Remove chosen element

        int NPCGoreSet = i;

        switch (NPCGoreSet)
        {
            case 0:
                SetGore(missingGroup1);
                break;
            case 1:
                SetGore(missingGroup2);
                break;
            case 2:
                SetGore(missingGroup3);
                break;
        }
    }

    void SetGore(Transform[] goreSet)
    {
        for (int i = 0; i < goreSet.Length; i++)
        {
            goreSet[i].gameObject.SetActive(false);
        }
    }


    void Update () {

        navAgent.SetDestination(huntedEnemy.position);
    }
}
