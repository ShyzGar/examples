using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public static MonsterSpawn instance { get; private set; }

    public GameObject[] waypoints;
    public GameObject monster;

    public float spawnInterval;
    public byte monsterCounter;

    float spawn;

    void Awake()
    {
        instance = this;
        spawn = Time.time;
    }

    void FixedUpdate()
    {
        if ( ((Time.time - spawn) > spawnInterval) && (monsterCounter > 0) && (GM.instance.currentHealth > 0) )
        {
            monsterCounter -= 1;
            spawn = Time.time;
            Instantiate(monster).GetComponent<Monster>().waypoints = waypoints;
            Counter.instance.text.text = monsterCounter.ToString();
        }
    }
}