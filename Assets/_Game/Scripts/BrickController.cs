using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

    public GameManager gameManager;
    public GameObject ballPrefab;
    public GameObject brickPrefab;

    public int bricks = 11;
    public float brickDistance = 1.5f;

    private void Start()
    {
        for (int i = 1; i < bricks; i++)
        {
            // distribute evenly
            // multiple rows
            GameObject newBrick = Instantiate(transform.GetChild(0).gameObject);
            newBrick.transform.SetParent(transform);
            Vector3 pos = newBrick.transform.position;
            pos.x += (i * brickDistance);
            newBrick.transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SetUpBricks()
    {

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            // add "brick" tag
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("collided");
    //    if(collision.gameObject.tag == "Ball")
    //    {
    //        Debug.Log("hit ball");
    //    }
    //    //gameManager.DestroyObject();
    //}

    public bool IsTouchedByBall(GameObject brick)
    {
        LayerMask mask = LayerMask.GetMask("Ball");
        RaycastHit2D hit = Physics2D.Raycast(brick.transform.position, Vector2.down, Mathf.Infinity, mask);
        if (hit.collider != null)
        {
            return false;
        }
        else
        {
            gameManager.DestroyObject(brick);
            return true;
        }

        //Collider2D BallCollider = ballPrefab.GetComponentInChildren<Collider2D>();
        //Collider2D BrickCollider = brickPrefab.GetComponentInChildren<Collider2D>();

        //if (BallCollider == null || BrickCollider == null)
        //{
        //    Debug.Log("Collider not found");
        //}
        //if (BallCollider.IsTouching(BrickCollider))
        //{
        //    return false;
        //}
        //else
        //{
        //    Debug.Log("brick destroyed");
        //    gameManager.DestroyObject(brick);
        //    return true;
        //}
    }
}
