using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_CharRandomizer : MonoBehaviour {

    public Transform npcChar;
    [Space(10)]
    public Transform[] missingLimbGroup1;
    public Transform[] missingLimbGroup2;
    public Transform[] missingLimbGroup3;

    void Start()
    {
        RandomizeChar();
    }

    void RandomizeChar()
    {
        Animator npcAnimator = npcChar.GetComponent<Animator>();
        NpcProperties npcController = GetComponent<NpcProperties>();

        float scaleVariation = Random.Range(0.9f, 1.1f);
        float npcSpeed = 1;

        npcChar.localScale *= scaleVariation;
        npcAnimator.Play("zombie_hunt", 0, npcSpeed);


        List<int> list = new List<int>();   //  Declare list

        for (int n = 0; n < 3; n++)    //  Populate list
        {
            list.Add(n);
        }

        int index = Random.Range(0, list.Count);    //  Pick random element from the list
        int i = list[index];    //  i = the number that was randomly picked
        list.RemoveAt(index);   //  Remove chosen element

        int npcGoreSet = i;

        switch (npcGoreSet)
        {
            case 0:
                SetGore(missingLimbGroup1);
                break;
            case 1:
                SetGore(missingLimbGroup2);
                break;
            case 2:
                SetGore(missingLimbGroup3);
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
}
