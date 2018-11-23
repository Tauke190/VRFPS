using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcProperties : MonoBehaviour {

    public enum entitieTypes { human, zombie, ghoul }

    public entitieTypes entitieType;
    public entitieTypes[] hostileEntities;
    public entitieTypes[] alliedEntities;
}
