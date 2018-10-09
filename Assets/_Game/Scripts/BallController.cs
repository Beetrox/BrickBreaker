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
        Vector2 size = new Vector2(Screen.width, Screen.height);
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(size);

        float cameraX = cameraSize.x;
        float cameraY = cameraSize.y;
        float cameraZ = cameraSize.z;

        float ballDiameter = cameraX / 13;

        rigidbody = gameObject.GetComponentInChildren<Rigidbody2D>() as Rigidbody2D;
        //Vector3 ballSize = new Vector3(ballDiameter, ballDiameter, ballDiameter);
        transform.localScale = new Vector3(ballDiameter, ballDiameter, ballDiameter);
        LeanTween.scale(gameObject, transform.localScale, 0.15f).setEaseInQuad();
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
