using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

    public GameManager gameManager;
    public GameObject ballPrefab;
    public GameObject brickPrefab;

    //int bricks = 11;
    float startPositionX = -8;
    float startPositionY = 3.5f;
    float brickSpacingX = 1.6f;
    float brickSpacingY = 0.5f;
    int gridRows = 11;
    int gridColumns = 3;

    private void Start()
    {
        SetUpBricks();

        //for (int i = 1; i < bricks; i++)
        //{
        //    // distribute evenly
        //    // multiple rows
        //    GameObject newBrick = Instantiate(transform.GetChild(0).gameObject);
        //    newBrick.transform.SetParent(transform);
        //    Vector3 pos = newBrick.transform.position;
        //    pos.x += (i * brickSpacing);
        //    newBrick.transform.position = pos;
        //}
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SetUpBricks()
    {
        for (int y = 0; y < gridColumns; y++)
        {
            for (int x = 0; x < gridRows; x++)
            {
                Vector3 spawnPosition = new Vector3(startPositionX + x * (brickSpacingX), startPositionY + y * (brickSpacingY), 0);
                GameObject brick = Instantiate(brickPrefab, spawnPosition, Quaternion.identity) as GameObject;
                brick.name = x + "/" + y;
                brick.transform.parent = gameObject.transform;
            }
        }
    }

    //public void SetUpBricks()
    //{
    //    foreach (Transform child in transform)
    //    {
    //        child.gameObject.SetActive(true);
    //        // add "brick" tag
    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("collided");
    //    if(collision.gameObject.tag == "Ball")
    //    {
    //        Debug.Log("hit ball");
    //    }
    //    Destroy(gameObject, 0.5f);
    //    Instantiate(explosion, transform.position, explosion.transform.rotation);
    //}

    //public bool IsTouchedByBall(GameObject brick)
    //{
    //    LayerMask mask = LayerMask.GetMask("Ball");
    //    RaycastHit2D hit = Physics2D.Raycast(brick.transform.position, Vector2.down, Mathf.Infinity, mask);
    //    if (hit.collider != null)
    //    {
    //        return false;
    //    }
    //    else
    //    {
    //        gameManager.DestroyObject(brick);
    //        return true;
    //    }

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
    //}
}
