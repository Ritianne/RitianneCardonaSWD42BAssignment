using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{     
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float padding = 0.7f;
    [SerializeField] float health = 5f;

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
    }

    // Send DamageDealer details
    private void ProcessHit(DamageDealer dmgDealer)
    {
        health -= dmgDealer.GetDamage();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
