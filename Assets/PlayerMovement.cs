using UnityEngine;

public class PlayerMovement : MonoBehaviour
{




    public int movementSpeed = 5;


    [Range(5, 10)]//slider
    public float jumpVelocity;

    Rigidbody rb;
    Vector3 startingPosition; // to restart the game

    // private float horizontal;
    // private float vertical;
    void Start()
    {
        // obtain Rigidbody from player when starting
        rb = GetComponent<Rigidbody>();
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {





        // jumping
        // ==================================================================
        // player upward force may not be applied if player is at a certain height or when below ground (you will need to be able to fall down)
        if (Input.GetButtonDown("Jump") && CanMyPlayerJump() == true)
        {
            //transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpPower, 0), ForceMode.Force);
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
            // Debug.Log("Velocity of RB: " + GetComponent<Rigidbody>().velocity.ToString());
        }


        // restarting game
        if (Input.GetButton("restartGame"))
        {

            // punt waar hij is
            // punt waarnartoe
            // bereken hoek
            // geef hem deze rotatie en hou de framerate in de gaten voor een smooth overgang


            // QUICK SOLUTION
            transform.position = startingPosition;
        }



        
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            // create new vector without changing the x-/z-axis and let the object rotate on
            // the new obtained y-axis based on player-input
            // transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * movementSpeed * Time.deltaTime);
            rb.drag = 0;


            // horizontale & verticale waarde vd input vd player
            float h = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
            float v = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

            //Debug.Log(h);
            //Debug.Log(v);
<<<<<<< Updated upstream
=======

            rb.useGravity = false;
>>>>>>> Stashed changes

            rb.AddForce(transform.right * h, ForceMode.Impulse);
            rb.AddForce(transform.forward * v, ForceMode.Impulse);

            rb.useGravity = true;


        }


    }

    private void FixedUpdate()
    {
        // Walking
        // ==================================================================
        // w-a-s-d




        if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            //rb.AddForce(0, -5000, 0);
            rb.drag = 500;
            Debug.Log("stopped pressing movement");

        }

    }

    // player mayb only jump on groundLevel. when below ground, jump = off. when exceeding a certain height:  jump = off
    private bool CanMyPlayerJump()
    {
        bool canJump;
        if (transform.position.y > -0.1f && transform.position.y < 0.4f)
        {
            canJump = true;
            Debug.Log("can jump");
        }
        else
        {
            canJump = false;
            Debug.Log("NO JUMPING");
        }
        return canJump;
    }
}
