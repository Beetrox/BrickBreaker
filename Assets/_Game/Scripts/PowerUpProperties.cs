using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpProperties : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

        StartCoroutine("PowerUpTime");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator PowerUpTime()
    {
        Debug.Log("power up");
        yield return new WaitForSeconds(5);
    }
}
