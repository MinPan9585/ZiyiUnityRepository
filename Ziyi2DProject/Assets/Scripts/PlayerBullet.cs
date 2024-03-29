using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Animator playerBulletAnim;
    Rigidbody2D rb2d;

    private void Awake()
    {
        playerBulletAnim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb2d.velocity = new Vector3(0, 0, 0);
        playerBulletAnim.SetTrigger("Hit");
        if (collision.CompareTag("Door") || collision.CompareTag("Enemy"))
        {
            print(collision.transform.parent.gameObject);
            Destroy(collision.transform.parent.gameObject);
        }
        Destroy(gameObject, 0.7f);
        
    }
}
