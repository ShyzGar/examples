using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public static GM instance { get; private set; }

    public Text goldLabel;

    GameObject obj;

    public int maxHealth;
    public int gold;
    public int currentHealth;
    public int Gold { get { return gold; } set {gold = value; goldLabel.GetComponent<Text>().text = gold.ToString(); } }

    void Start()
    {
        instance = this;

        currentHealth = maxHealth;
        goldLabel.GetComponent<Text>().text = gold.ToString();

        obj = GameObject.Find("Final_Image");
        obj.SetActive(false);
    }

    void FixedUpdate()
    {
        if (currentHealth <= 0)
        {
            obj.SetActive(true);
            obj.GetComponentInChildren<Text>().text = "ПОРАЖЕНИЕ!!!";
        }

        else if ( (MonsterSpawn.instance.monsterCounter == 0) && FindObjectOfType<Monster>() is null )
        {
            obj.SetActive(true);
            obj.GetComponentInChildren<Text>().text = "ПОБЕДА!!!";
        }
    }

    public void ChangeHealth(int attack)
    {
        currentHealth = Mathf.Clamp(currentHealth + -attack, 0, maxHealth);
        HealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }
}