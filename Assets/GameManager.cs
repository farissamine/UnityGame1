using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private bool gameEnded = false;
    public float restartDelay;

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
            Invoke("Restart", restartDelay);
            
            //Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

