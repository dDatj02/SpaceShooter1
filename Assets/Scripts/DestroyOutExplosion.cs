using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutExplosion : MonoBehaviour
{
    public float timeOut;
    void Start()
    {
        Destroy(gameObject, timeOut);
    }
}
