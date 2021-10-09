using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject[] waypoints;
    public Sprite[] monsterSprite;

    SpriteRenderer spriteRenderer;
    Sprite sprite;
    Transform healthBar;

    public float[] monsterSpeed;
    public int[] monsterAttack;
    public int[] monsterHitPoints;
    
    int currentWaypoint = 0;
    int i;

    float lastWaypointSwitchTime;
    float originalScale;

    float speed;
    int attack;
    int hitpoints;
    int curHitpoints;

    void Start()
    {
        lastWaypointSwitchTime = Time.time;

        i = Random.Range(0, monsterSprite.Length);

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        sprite = monsterSprite[i];
        spriteRenderer.sprite = sprite;

        healthBar = gameObject.transform.GetChild(0);
        originalScale = healthBar.localScale.x;

        speed = monsterSpeed[i];
        hitpoints = monsterHitPoints[i];
        curHitpoints = hitpoints;
        attack = monsterAttack[i];
    }

    void Update()
    {
        Vector3 startPosition = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;

        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;

        gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);

        if (gameObject.transform.position.Equals(endPosition))
        {
            if (currentWaypoint < waypoints.Length - 2)
            {
                currentWaypoint++;
                lastWaypointSwitchTime = Time.time;
            }
            else
            {
                GM.instance.ChangeHealth(attack);
                Destroy(gameObject);
            }
        }
    }

    public void Wound(int damage)
    {
        if (healthBar.localScale.x > 0)
        {
            curHitpoints -= damage;

            Vector3 tmpScale = healthBar.localScale;
            tmpScale.x = (float)curHitpoints / hitpoints * originalScale;

            healthBar.localScale = tmpScale;
        }
        else Destroy(gameObject);
    }

    public float DistanceToGoal()
    {
        float distance = 0;

        distance += Vector2.Distance(
            gameObject.transform.position,
            waypoints[currentWaypoint + 1].transform.position);

        for (int i = currentWaypoint + 1; i < waypoints.Length - 1; i++)
        {
            Vector3 startPosition = waypoints[i].transform.position;
            Vector3 endPosition = waypoints[i + 1].transform.position;
            distance += Vector2.Distance(startPosition, endPosition);
        }

        return distance;
    }
}