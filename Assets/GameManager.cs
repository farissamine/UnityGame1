using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool gameEnded = false;

    public bool gameHasEnded()
    {
        return gameEnded;
    }


    public void EndGame()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            Debug.Log("Game Over");
        }
    }
}

