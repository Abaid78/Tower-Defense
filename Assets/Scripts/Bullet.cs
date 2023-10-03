using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public GameObject impactEffact;
    public float speed = 70f;
    public float explosionRadios = 0f;
    public void Seek(Transform  _tartget)
    {
        target = _tartget;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) {
            Destroy(gameObject);
            return;
        }
        Vector3 dir=target.position-transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if(dir.magnitude <= distanceThisFrame )
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized*distanceThisFrame,Space.World);
        transform.LookAt(target);
    }
    void HitTarget()
    {
        GameObject impactIns=Instantiate(impactEffact,transform.position, Quaternion.identity);
        Destroy(impactIns, 6f);
        if(explosionRadios>0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
       
        Destroy(gameObject);
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadios);
        foreach(Collider collider in colliders) 
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadios);
    }
     
}
