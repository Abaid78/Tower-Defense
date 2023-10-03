using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wavepointIndex=0;
    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.point[0];
        
    }

    // Update is called once per frame
    void Update()
    {
       //calculate thpe position enemy to waypoint
        Vector3 dir = target.position - transform.position;
        
      //move anmey
        transform.Translate(dir.normalized* speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            if(wavepointIndex>=Waypoints.point.Length-1)
            {
                Destroy(gameObject);
                return;
            }
            wavepointIndex++;
            target = Waypoints.point[wavepointIndex];
        }
       
    }
}
