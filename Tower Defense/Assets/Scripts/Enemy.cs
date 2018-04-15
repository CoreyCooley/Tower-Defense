using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    GameObject pathGO;

    Transform targetPathNode;
    int pathNodeIndex = 0;

    public float speed = 5;

    public float health = 1;

    public int moneyValue = 1;

	// Use this for initialization
	void Start ()
    {
        pathGO = GameObject.Find("Path");
	}

    void GetNextPathNode()
    {
        if (pathNodeIndex < pathGO.transform.childCount)
        {
            targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
            pathNodeIndex++;
        }
        else
        {
            targetPathNode = null;
            ReachedGoal();
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPathNode == null)
        {
            GetNextPathNode();
            if(targetPathNode == null)
            {
                // Ran out of path!
                ReachedGoal();
                return;
            }
        }

        // Calc dir
        Vector3 dir = targetPathNode.position - this.transform.localPosition;

        float distThisFram = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFram)
        {
            // We reached the node
            targetPathNode = null;
        }
        else
        {
            // TODO: Consider ways to smooth this motion.

            // Move towards node
            transform.Translate(dir.normalized * distThisFram);

        }
    }

    void ReachedGoal()
    {
        GameObject.FindObjectOfType<ScoreManager>().LoseLife();
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // TODO: Do this more safely!
        GameObject.FindObjectOfType<ScoreManager>().money += moneyValue;
        Destroy(gameObject);
    }
}
