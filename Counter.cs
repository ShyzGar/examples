using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public static Counter instance { get; private set; }

    public Text text;

    void Start()
    {
        instance = this;
        text.text = MonsterSpawn.instance.monsterCounter.ToString();
    }
}