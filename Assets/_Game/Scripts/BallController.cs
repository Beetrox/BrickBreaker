using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameManager gameManager;

    Rigidbody2D rigidbody;
    //Vector2 constantVelocity = new Vector2(1f, 1f);
    float constantSpeed = 6f;

    void Start()
    {
        rigidbody = gameObject.GetComponentInChildren<Rigidbody2D>() as Rigidbody2D;
        Vector3 size = new Vector3(0.7f, 0.7f, 0.7f);
        LeanTween.scale(gameObject, size, 0.15f).setEaseInQuad();
    }

    void Update()
    {
        //rigidbody.velocity = constantVelocity;
        //rigidbody.AddForce(constantVelocity);
        ConstantSpeed();
    }

    void ConstantSpeed()
    {
        rigidbody.velocity = constantSpeed * (rigidbody.velocity.normalized);
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
}
