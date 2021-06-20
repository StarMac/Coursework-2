using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;

    [SerializeField]
    AudioSource ballsound;
    [SerializeField]
    private float moveSpeed = 10;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = rigidbody2D.velocity.normalized * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //ballsound.PlayOneShot(ballsound.clip);
        ballsound.Play();
    }
}
