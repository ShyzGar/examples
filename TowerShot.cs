using System.Collections.Generic;
using UnityEngine;

public class TowerShot : MonoBehaviour
{
    public List<GameObject> enemiesInRange;

    public int damage;
    public float interval;

    float shotTime;

    void Start()
    {
        enemiesInRange = new List<GameObject>();
        shotTime = Time.time;
    }
    
    void Update()
    {
        GameObject target = null;

        float minimalEnemyDistance = float.MaxValue;

        foreach (GameObject enemy in enemiesInRange)
        {
            float distanceToGoal = enemy.GetComponent<Monster>().DistanceToGoal();

            if (distanceToGoal < minimalEnemyDistance)
            {
                target = enemy;
                minimalEnemyDistance = distanceToGoal;
            }
        }

        if (target != null && (Time.time - shotTime > interval))
        {
            target.GetComponent<Monster>().Wound(damage);
            shotTime = Time.time;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject);
        }
    }

    public void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }
}