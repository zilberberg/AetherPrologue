using UnityEngine;
using System.Collections;
using System;

public class Bird : MonoBehaviour 
{
    public static Bird instance;
    public float upForce;					//Upward force of the "flap".
	private bool isDead = false;			//Has the player collided with a wall?

	private Animator anim;					//Reference to the Animator component.
	private Rigidbody2D rb2d;				//Holds a reference to the Rigidbody2D component of the bird.


    //public BoxCollider2D leftFly, rightFly;

	void Start()
	{
        //Get reference to the Animator component attached to this GameObject.
        anim = GetComponent<Animator> ();
		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();
    }

	void Update()
	{
        if (GameControl.instance.bicarusBurned && !isDead)
        {
            burn();
        }
		//Don't allow control if the bird has died.
		if (isDead == false) 
		{
            if (Input.GetMouseButtonDown(0)) 
			{
                var touch = Input.GetTouch(0);
                if (touch.position.x > Screen.width / 2)
                {
                    //...tell the animator about it and then...
                    anim.SetTrigger("Flap");
                    //...zero out the birds current y velocity before...
                    rb2d.velocity = Vector2.zero;
                    //	new Vector2(rb2d.velocity.x, 0);
                    //..giving the bird some upward force.
                    rb2d.AddForce(new Vector2(0, upForce));
                    rb2d.AddForce(new Vector2(upForce/2, 0));

                }

                if (touch.position.x < Screen.width / 2)
                {
                    //...tell the animator about it and then...
                    anim.SetTrigger("Flap");
                    //...zero out the birds current y velocity before...
                    rb2d.velocity = Vector2.zero;
                    //	new Vector2(rb2d.velocity.x, 0);
                    //..giving the bird some upward force.
                    rb2d.AddForce(new Vector2(0, upForce));
                    rb2d.AddForce(new Vector2(-upForce/2, 0));
                }                

			}
		}
	}

    internal void burn()
    {
        anim.SetTrigger("Burn");
        isDead = true;
        GameControl.instance.BirdDied();
    }

    void OnCollisionEnter2D(Collision2D other)
	{
        if (other.gameObject.name == "Ground" || other.gameObject.name == "bottomEdge" ||
            other.gameObject.name == "ABombs")
        {
            // Zero out the bird's velocity
            rb2d.velocity = Vector2.zero;
            // If the bird collides with something set it to dead...
            isDead = true;
            //...tell the Animator about it...
            anim.SetTrigger("Die");
            //...and tell the game control about it.
            GameControl.instance.BirdDied();


        }
        

    }
}
