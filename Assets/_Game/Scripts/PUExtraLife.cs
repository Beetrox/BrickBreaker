using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUExtraLife : PowerUpProperties
{
    LivesController livesController;
    GameManager gameManager;

    protected override void ExecutePowerUp()
    {
        GameObject managerObject = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();

        if (!gameManager.endless && !gameManager.survival)
        {
            GameObject lives = GameObject.FindGameObjectWithTag("Lives");
            livesController = lives.GetComponent<LivesController>();

            livesController.AddLife();
            EndPowerUp();
        }
        Destroy(gameObject);
    }
}
