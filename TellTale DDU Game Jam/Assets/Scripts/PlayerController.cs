using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 3f;
    public Animator animator;

    float velX;
    float velY;
    bool facingRight = true;
    Rigidbody2D rigBody;

	// Use this for initialization
	void Start () {
        rigBody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
        velX = Input.GetAxisRaw ("Horizontal");
        velY = rigBody.velocity.y;
        rigBody.velocity = new Vector2(velX * moveSpeed, velY);

        animator.SetFloat("Speed", Mathf.Abs (velX));
	}

    void LateUpdate()
    {
        Vector3 localScale = transform.localScale;
        if (velX > 0)
        {
            facingRight = true;
        } else if (velX < 0)
        {
            facingRight = false;
        }
        if (((facingRight) && (localScale.x <0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }
}
