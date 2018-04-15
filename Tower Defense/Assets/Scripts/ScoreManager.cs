using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int money = 20;
    public int lives = 20;

    public Text moneyText;
    public Text livesText;

    public void LoseLife(int l = 1)
    {
        Debug.Log("Lives to lose" + l);
        lives -= l;
        if(lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        // TODO: Send the player to a game-over screen
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinGame()
    {
        
    }

    private void Update()
    {
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        EnemySpawner[] spawners = GameObject.FindObjectsOfType<EnemySpawner>();

        moneyText.text = "Money: $" + money.ToString();        
        livesText.text = "Lives: " + lives.ToString();

        if(spawners.Length <=0)
        {
            if(enemies.Length <=0)
            {

            }
        }
    }
}
