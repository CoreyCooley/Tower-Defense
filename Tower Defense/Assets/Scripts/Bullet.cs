using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float speed = 15f;

    public Transform target;

    public float damage = 1.0f;
    public float radius = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(target == null)
        {
            // Our enemy went away!
            Destroy(gameObject);
            return;
        }

        // Calc dir
        Vector3 dir = target.position - this.transform.localPosition;

        float distThisFram = speed * Time.deltaTime;

        if (dir.magnitude <= distThisFram)
        {
            // We reached the node
            DoBulletHit();
        }
        else
        {
            // TODO: Consider ways to smooth this motion.

            // Move towards node
            transform.Translate(dir.normalized * distThisFram);
            //Quaternion targetRotation = Quaternion.LookRotation(dir);
            //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime*5);
        }

    }

    void DoBulletHit()
    {
        // TODO: What if it's an exploding bullet with an AoE
        
        if(radius == 0)
        {
            target.GetComponent<Enemy>().TakeDamage(damage);
        }
        else
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius);

            foreach (Collider2D c in cols)
            {
                Debug.Log("Collider2D : " + c);
                Enemy e = c.GetComponent<Enemy>();
                Debug.Log("Enemy(s) to damage: " + e);
                if(e != null)
                {
                    // TODO: Could add fall off damage
                    e.GetComponent<Enemy>().TakeDamage(damage);
                }                
            }
        }
        
        // TODO: Explosion anim
        Destroy(gameObject);
    }
}
