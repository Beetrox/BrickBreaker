using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

    int lifeTime = 1;

    private void Awake()
    {
        Destroy(gameObject, lifeTime);
    }
}
