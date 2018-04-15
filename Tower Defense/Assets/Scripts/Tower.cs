using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

    Transform turretTransform;

    public float range = 10f;

    public GameObject bulletPrefab;

    public int cost = 5;

    public float fireCD = 1.0f;
    float fireCDLeft = 0;

    public float damage = 1;
    public float radius = 0;

	// Use this for initialization
	void Start () {
        turretTransform = transform.Find("Turret");
	}
	
	// Update is called once per frame
	void Update () {
        // TODO: Optimize this!
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();

        Enemy nearestEnemy = null;
        float dist = Mathf.Infinity;

        foreach(Enemy e in enemies)
        {
            float d = Vector2.Distance(this.transform.position, e.transform.position);
            if(nearestEnemy == null || d < dist)
            {
                nearestEnemy = e;
                dist = d;
            }
        }

        if(nearestEnemy == null)
        {
            Debug.Log("No enemies?");
            return;
        }

        Vector3 dir = nearestEnemy.transform.position - this.transform.position;

        ////Quaternion lookRot = Quaternion.LookRotation(dir);

        ////Debug.Log(lookRot.eulerAngles);
        ////turretTransform.rotation = Quaternion.Euler(lookRot.eulerAngles.x, 0, 0);


        fireCDLeft -= Time.deltaTime;

        if(fireCDLeft <= 0 && dir.magnitude <= range)
        {
            fireCDLeft = fireCD;
            ShootAt(nearestEnemy);
        }

	}

    void ShootAt(Enemy e)
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        Bullet b = bulletGO.GetComponent<Bullet>();
        b.target = e.transform;
        Debug.Log(b);
        b.damage = damage;  // Damage from the tower
        b.radius = radius;
    }
}
