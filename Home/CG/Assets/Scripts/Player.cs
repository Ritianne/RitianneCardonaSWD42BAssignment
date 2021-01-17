using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{     
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float padding = 0.7f;
    [SerializeField] float health = 50f;
    [SerializeField] int points = 0;

    [SerializeField] AudioClip collisionSound;
    [SerializeField] AudioClip noCollisionSound;
    [SerializeField] [Range(0, 1)] float SoundVolume = 0.75f;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;

    float xMin, xMax;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = transform.position.x + deltaX;
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);
        this.transform.position = new Vector2(newXPos, transform.position.y);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }

    // Reduces health when the player collides with an object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer dmgDealer = collision.gameObject.GetComponent<DamageDealer>();

        // If there is no dmgDealer in otherObject, end the method
        if (!dmgDealer) 
        {
            return;
        }

        ProcessHit(dmgDealer);
        Destroy(collision.gameObject);
        GameObject explosion = Instantiate(deathVFX, collision.gameObject.transform.position, Quaternion.identity);
    }

    // Send DamageDealer details
    private void ProcessHit(DamageDealer dmgDealer)
    {
        health -= dmgDealer.GetDamage();
        AudioSource.PlayClipAtPoint(collisionSound, Camera.main.transform.position, SoundVolume);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        // Instiantiate Explosion Effects
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        // Destroy after 1 second
        Destroy(explosion, explosionDuration);
        FindObjectOfType<Levels>().LoadGameOver();
    }
}
