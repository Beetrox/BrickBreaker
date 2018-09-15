using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameManager gameManager;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        //pos.x = Mathf.Clamp01(pos.x);
        //pos.y = Mathf.Clamp01(pos.y);
        //transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    bool IsBallOutsideArea()
    {
        if (false)
        {
            Debug.Log("ball dead");
            gameManager.DestroyObject(gameObject);
            return false;
        }
        else
        {
            Debug.Log("continue game");
            return false;
        }
    }
}
