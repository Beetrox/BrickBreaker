using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameManager gameManager;

    Rigidbody2D rigidbody;
    //Vector2 constantVelocity = new Vector2(1f, 1f);
    float constantSpeed = 6f;
    bool isFastBall = false;
    bool isFireBall = false;
    bool isGhostBall = false;
    bool isSplitBall = false;

    // Use this for initialization
    void Start()
    {
        rigidbody = gameObject.GetComponentInChildren<Rigidbody2D>() as Rigidbody2D;
    }

    // Update is called once per frame
    void Update()
    {
        //rigidbody.velocity = constantVelocity;
        //rigidbody.AddForce(constantVelocity);
        rigidbody.velocity = constantSpeed * (rigidbody.velocity.normalized);

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collided");
        if (collision.gameObject.tag == "Bottom")
        {
            //Debug.Log("hit bottom");
            //gameManager.DestroyObject(gameObject);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    public void FastBall()
    {
        // change speed of ball
        isFastBall = true;
    }

    public void FireBall()
    {
        // make ball burn adjacent bricks
        isFireBall = true;
    }

    public void GhostBall()
    {
        // make ball ignore walls
        isGhostBall = true;
    }

    public void SplitBall()
    {
        // spawn second ball from original ball
        isSplitBall = true;
    }
}
