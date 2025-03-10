using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserDatabase;
public enum ItemType { Heart, Jump }
public class ItemScript : MonoBehaviour
{
    public ItemType itemType;
    [SerializeField]
    private Data data;
    public int maxCount;
    private void Awake()
    {
        data = Resources.Load<Data>("Data/Data");
    }
    public void TouchItem()
    {
        switch (itemType)
        {
            case ItemType.Heart:
                HeartItem();
                break;

            case ItemType.Jump:
                JumpItem();
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") { TouchItem(); }
    }
    void HeartItem()
    {
        if (data.maxHP < maxCount) { data.maxHP++; }
        DestroyItem();
    }
    void JumpItem()
    {
        if (data.jumpCount < maxCount) { data.jumpCount++; }
        else { data.maxHP++; }
        DestroyItem();
    }
    void DestroyItem()
    {
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        Destroy(gameObject, 1f);
    }
}
