using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpProperties : MonoBehaviour {
    
	void Start ()
    {
        StartCoroutine("PowerUpTime");	
	}

    IEnumerator PowerUpTime()
    {
        Debug.Log("power up");
        yield return new WaitForSeconds(5);
    }
}
