using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory : MonoBehaviour
{
    public abstract IZombie Spawn(Vector3 position);
 // shared method with all factories
 
}
