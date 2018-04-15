using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour {

    public GameObject WinUI;

    public bool paused = false;

	// Use this for initialization
	void Start () {
        WinUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        EnemySpawner[] spawners = GameObject.FindObjectsOfType<EnemySpawner>();

        if (spawners.Length <= 0)
        {
            if (enemies.Length <= 0)
            {
                paused = !paused;
            }
        }

        //if (Input.GetButtonDown("Pause"))
        //{
        //    paused = !paused;
        //}

        if (paused)
        {
            WinUI.SetActive(true);    // Display pause menu
            //Time.timeScale = 0;         // Set time to zero
        }
        //if (!paused)
        //{
        //    WinUI.SetActive(false);
        //    Time.timeScale = 1;         // Set time to normal time // set to 0.3 for slow mode :)
        //}

    }

    public void Restart()
    {
        paused = false;
        WinUI.SetActive(false);
        Time.timeScale = 1;         // Set time to normal time // set to 0.3 for slow mode :)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);

    }
}
