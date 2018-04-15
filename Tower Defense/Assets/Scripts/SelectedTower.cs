using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectedTower : MonoBehaviour {

    public Image towerImg;
    public Text towerText;

    Sprite towerSprite;

    BuildingManager bm;

    // Use this for initialization
    void Start () {
	    bm = GameObject.FindObjectOfType<BuildingManager>();
        //GetComponent<SpriteRenderer>().sprite = towerSprite;
    }
	
	// Update is called once per frame
	void Update () {

        if (bm.selectedTower != null)
        {
            towerSprite = bm.selectedTower.GetComponent<Tower>().GetComponent<SpriteRenderer>().sprite;

            if(towerSprite != null)
            {
                GetComponent<SpriteRenderer>().sprite = towerSprite;
                towerText.text = "CHECK IT";
            }
        }
    }
}
