using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    public GameObject towerPrefab;
    public Sprite[] towerSprite;

    GameObject tower;
    SpriteRenderer spriteRenderer;
    Sprite sprite;

    bool CanPlaceTower()
    {
        return tower == null && GM.instance.Gold >= ButtonTower.instance.gold;
    }

    void OnMouseUp()
    {
        if (CanPlaceTower())
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

            spriteRenderer = towerPrefab.GetComponent<SpriteRenderer>();
            sprite = towerSprite[ButtonTower.instance.i];
            spriteRenderer.sprite = sprite;

            tower = Instantiate(towerPrefab, transform.position, Quaternion.identity);
            tower.GetComponent<TowerShot>().damage = ButtonTower.instance.damage;
            tower.GetComponent<TowerShot>().interval = ButtonTower.instance.interval;

            GM.instance.Gold -= ButtonTower.instance.gold;
        }
    }
}