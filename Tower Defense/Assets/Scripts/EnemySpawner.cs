using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    float spawnCD = 0.25f;
    float spawnCDRemaining = 5; // Add time between waves

    [System.Serializable]
    public class WaveComponent
    {
        public GameObject enemyPrefab;
        public int num;
        [System.NonSerialized]  //Won't show up in insector
        public int spawned;
    }

    public WaveComponent[] waveComps;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        bool didSpawn = false;

        spawnCDRemaining -= Time.deltaTime;
        if(spawnCDRemaining <= 0)
        {
            spawnCDRemaining = spawnCD;

            // Go throught the wave comps until we find something to spawn
            foreach(WaveComponent wc in waveComps)
            {
                if (wc.spawned < wc.num)
                {
                    // Spawn it!!
                    Debug.Log("Spawned: " + wc.spawned);

                    Instantiate(wc.enemyPrefab, this.transform.position, this.transform.rotation);

                    wc.spawned++;

                    didSpawn = true;
                    break;
                }
            }

            if (didSpawn == false)
            {
                // Wave must be complete!
                // TODO: Instantiate next wave object!
                Debug.Log("Not spawning");

                if (transform.parent.childCount > 1)
                {
                    transform.parent.GetChild(1).gameObject.SetActive(true);   // Get next child
                }
                else
                {
                    // That was the last wave --- what do we want to do?
                    // What if instead of detroying wave objects,
                    // we just made them inactive, and then when we run
                    // out of waves, we restart at the first one,
                    // but double all enemy HPs or something?
                    // TODO: Optimize this!
                }
                Destroy(gameObject);
            }
        }
	}
}
