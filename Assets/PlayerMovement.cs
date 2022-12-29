using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float movementSpeed = 6f;
    private ScoreManager sm;
    public bool playerIsGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && playerIsGrounded)
        {
            Jump();
        }
        
    }
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);

    }

    private void OnCollisionStay(Collision Coll)
    {
        if (Coll.gameObject.tag == "Platform")
        {
            playerIsGrounded = true;

        }


    }
    private void OnCollisionExit(Collision Coll)
    {
        if (Coll.gameObject.tag == "Platform")
        {
            playerIsGrounded = false;

        }


    }
    void OnTriggerEnter(Collider Coll)
    {
        sm = FindObjectOfType<ScoreManager>();
        if (Coll.gameObject.tag == "Coin" && sm.score >= 3)
        {
	    SceneManager.LoadScene("scene2");
        }

    }
}
