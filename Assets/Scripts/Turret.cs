

using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Attributes")]
    public float range = 15f;
    public float turnSpeed = 10f;
    public float fireRate = 1f;
    public float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    private Transform target;
    public Transform partToRotate;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffact;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if(useLaser){
                if(lineRenderer.enabled){

                    lineRenderer.enabled=false;
                    impactEffact.Stop();
                }
            }
            return;
        }
        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                shoot();
                fireCountdown = 1 / fireRate;

            }
            fireCountdown -= Time.deltaTime;
        }
        LookOnTarget();


    }
    void Laser()
    {
        if(!lineRenderer.enabled){

            lineRenderer.enabled=true;
            impactEffact.Play();
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
        Vector3 dir=firePoint.position-target.position;

        impactEffact.transform.position=target.transform.position+dir.normalized;
        impactEffact.transform.rotation=Quaternion.LookRotation(dir);
    }   

    void LookOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 roation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, roation.y, 0f);
    }
    private void OnDrawGizmosSelected()
    {


        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
}
