using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private bool right = true;
    private Vector3 checkpoint;
    private Animator animator;
    private int jumpCount = 0;
    private int keyCount = 0;
    private TextMeshPro keyText;
    private int totalKeys;
    public ParticleSystem explosionParticle;
    
    // Start is called before the first frame update
    void Start()
    {
        checkpoint = transform.position;
        animator = GetComponent<Animator>();
        totalKeys = GameObject.FindGameObjectsWithTag("Key").Length;
        keyText = GameObject.Find("Score Text").GetComponent<TextMeshPro>();
        keyText.SetText("{0}/{1} keys", keyCount, totalKeys);
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Change direction
        if ((horizontalInput < 0 && right) || (horizontalInput > 0 && !right))
        {
            right = !right;
            transform.Rotate(Vector3.up * 180);
        }

        // Set run animation and physics
        if (horizontalInput != 0)
        {
            animator.SetBool("Run", true);
            transform.Translate(Vector3.forward * Time.deltaTime * Mathf.Abs(horizontalInput) * speed);
        }
        else
        {
            animator.SetBool("Run", false);
        }

        // Handle jump animation
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && jumpCount < 2)
        {
            if (jumpCount == 0)
            {
                animator.SetTrigger("Jump");
            }
            else
            {
                animator.SetTrigger("Double_jump");
            }
            jumpCount++;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = checkpoint;
        }

        // Set boundaries
        if (transform.position.z < -1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        }

        // Set fall boundaries
        if (transform.position.y < -3)
        {
            transform.position = checkpoint;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        jumpCount = 0;
        animator.SetBool("Double_jump", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            keyCount++;
            keyText.SetText("{0}/{1} keys", keyCount, totalKeys);
            explosionParticle.Play();
            checkpoint = transform.position;
            Destroy(other.gameObject);
        }
    }
}
