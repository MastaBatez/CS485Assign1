using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformerPlayer : MonoBehaviour {

    public float walkSpeed;
    public float jumpHeight;

    bool isJumping = false;
    bool onPlatform = false;
    bool onGround;

    private Rigidbody rb;
    private new Collider collider;
    private Vector3 spawnPoint;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        spawnPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMovement();
        PlayerJump();
	}

    void PlayerMovement()
    {
        float moveDistance = walkSpeed * Time.deltaTime;

        float horizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontal * moveDistance, 0, 0);
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = currentPosition + movement;
        rb.MovePosition(newPosition);
    }

    void PlayerJump()
    {

        if (Input.GetButtonDown("Jump"))
        {
            if (!onPlatform)
                onGround = CheckOnGround();
            else
                onGround = true;
            if (!isJumping && onGround)
            {
                isJumping = true;
                Vector3 jumpVec = new Vector3(0, jumpHeight, 0);
                rb.velocity = rb.velocity + jumpVec;
            }
        }
        else
        {
            isJumping = false;
        }
    }

    bool CheckOnGround()
    {
        float sizeX = collider.bounds.size.x;
        float sizeZ = collider.bounds.size.z;
        float sizeY = collider.bounds.size.y;

        Vector3 corner1 = transform.position + new Vector3(sizeX / 2, -sizeY / 2 + 0.01f, sizeZ / 2);
        Vector3 corner2 = transform.position + new Vector3(-sizeX / 2, -sizeY / 2 + 0.01f, sizeZ / 2);
        Vector3 corner3 = transform.position + new Vector3(sizeX / 2, -sizeY / 2 + 0.01f, -sizeZ / 2);
        Vector3 corner4 = transform.position + new Vector3(-sizeX / 2, -sizeY / 2 + 0.01f, -sizeZ / 2);

        bool grounded1 = Physics.Raycast(corner1, new Vector3(0, -1, 0), 0.01f);
        bool grounded2 = Physics.Raycast(corner2, new Vector3(0, -1, 0), 0.01f);
        bool grounded3 = Physics.Raycast(corner3, new Vector3(0, -1, 0), 0.01f);
        bool grounded4 = Physics.Raycast(corner4, new Vector3(0, -1, 0), 0.01f);

        // If any corner is grounded, the object is grounded
        return (grounded1 || grounded2 || grounded3 || grounded4);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            GameManager.instance.IncreaseScore(100);
        }
        if (other.gameObject.tag == "DeathFloor")
        {
            transform.position = spawnPoint;
            GameManager.instance.DecreaseScore(500);
        }
        if (other.gameObject.tag == "FinishLine")
        {
            GameManager.instance.IncreaseScore(1000);
            GameManager.instance.finishedLevel = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
            onPlatform = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
            onPlatform = false;

        }
    }
}
