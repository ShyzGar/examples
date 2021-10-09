using UnityEngine;
using UnityEngine.UI;

public class ButtonTower : MonoBehaviour
{
    public static ButtonTower instance { get; private set; }

    public Texture2D texture;

    Vector2 hotSpot = Vector2.zero;

    public int i;
    public int gold;
    public int damage;
    public float interval;

    void Start()
    {
        GetComponentInChildren<Text>().text = gold.ToString();
    }

    public void PressedTower()
    {
        instance = this;
        Cursor.SetCursor(texture, hotSpot, CursorMode.Auto);
    }
}