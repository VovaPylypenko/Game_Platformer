using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerJump : NetworkBehaviour
{
    private Rigidbody2D rb2D;
    
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (rb2D.velocity.y < 0)
        {
            rb2D.velocity += Time.deltaTime * Physics2D.gravity.y * (fallMultiplier - 1) * Vector2.up;
        } else if (rb2D.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space))
        {
            rb2D.velocity += Time.deltaTime * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Vector2.up;
        }
    }

    private void Jump()
    {
        rb2D.AddForce(transform.up * 18f, ForceMode2D.Impulse);
    }
}
