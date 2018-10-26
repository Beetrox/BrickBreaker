using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameManager gameManager;
    PaddleController paddleController;
    LivesController livesController;
    Rigidbody2D rigidbody;
    public AudioSource collisionAudio;
    public AudioSource deathAudio;

    public bool hasPowerUp = false;
    public bool touchedPaddle = true;
    float constantSpeed = 6f;

    void Start()
    {
        GameObject managerObject = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();

        GameObject collisionAudioObject = GameObject.FindGameObjectWithTag("CollisionAudio");
        collisionAudio = collisionAudioObject.GetComponent<AudioSource>();

        GameObject deathAudioObject = GameObject.FindGameObjectWithTag("DeathAudio");
        deathAudio = deathAudioObject.GetComponent<AudioSource>();

        Vector2 size = new Vector2(Screen.width, Screen.height);
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(size);

        float cameraX = cameraSize.x;
        float cameraY = cameraSize.y;
        float cameraZ = cameraSize.z;

        float ballDiameter = cameraX / 13;

        rigidbody = gameObject.GetComponentInChildren<Rigidbody2D>() as Rigidbody2D;
        transform.localScale = new Vector3(ballDiameter, ballDiameter, ballDiameter);
        Vector3 growSize = transform.localScale;
        LeanTween.scale(gameObject, growSize, 0.15f).setEaseInQuad();

        GameObject paddle = GameObject.FindGameObjectWithTag("Paddle");
        paddleController = paddle.GetComponent<PaddleController>();

        if (GameObject.FindGameObjectWithTag("Lives"))
        {
            GameObject lives = GameObject.FindGameObjectWithTag("Lives");
            livesController = lives.GetComponent<LivesController>();
        }
    }

    void Update()
    {
        ConstantSpeed();
        float test = rigidbody.velocity.y;

        if (paddleController.ballReleased && test == 0)
        {
            float currentX = rigidbody.velocity.x;
            // pushing ball if stuck between two walls
            gameObject.GetComponentInChildren<Rigidbody2D>().AddForce(new Vector2(currentX, -6f), ForceMode2D.Impulse);
        }
    }

    void ConstantSpeed()
    {
        rigidbody.velocity = constantSpeed * (rigidbody.velocity.normalized);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bottom")
        {
            deathAudio.Play();

            if (!gameManager.endless)
            {
                livesController.RemoveLife();
            }
            
            paddleController.StartCoroutine("SpawnNewBall");
            Destroy(transform.parent.gameObject);
        }
        else
        {
            collisionAudio.Play();
        }
    }
}
