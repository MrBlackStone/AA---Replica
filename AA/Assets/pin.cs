using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pin : MonoBehaviour
{
    private bool isPinned = false;
    public float speed = 80f;
    public Rigidbody2D rb;
    Score score;
    private void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();
    }
    private void Update()
    {
        if(!isPinned)
        rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Rotator")
        {
            transform.SetParent(collision.transform);
            score.PinCount++;
            isPinned = true;
        }
        else if (collision.tag =="Pin")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
