using UnityEngine;
using System.Collections;

public class TowerUpgrade : MonoBehaviour {

    public GameObject upgradeTower;

    Vector3 curLocation;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseUp()
    {
        Debug.Log("Tower Clicked to upgrade!");

        if (upgradeTower != null)
        {
            ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();
            Debug.Log("Upgrade Cost: " + upgradeTower.GetComponent<Tower>().cost);
            if (sm.money < upgradeTower.GetComponent<Tower>().cost)
            {
                Debug.Log("Not enough money to upgrade!");
                return;
            }
            else
            {
                sm.money -= upgradeTower.GetComponent<Tower>().cost;
            }

            curLocation = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

            // FIXME: Right now we assume that we're an object nested in a parent.
            Instantiate(upgradeTower, curLocation, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
