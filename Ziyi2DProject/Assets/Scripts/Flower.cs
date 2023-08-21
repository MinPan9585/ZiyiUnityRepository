using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public LayerMask playerLayer;
    Animator anim;
    public PlayerController player;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        print(player.currentEnergy);
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (Physics2D.OverlapCircle(transform.position, 1f, playerLayer))
            {
                if (player.currentEnergy < player.maxEnergy)
                {
                    player.currentEnergy++;
                }
                
                anim.SetTrigger("GetHit");
                //Destroy(gameObject);
                StartCoroutine(Respawn());
            }
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5);
        anim.SetTrigger("Respawn");
    }
}
