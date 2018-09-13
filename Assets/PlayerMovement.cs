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
        if (Input.GetButtonDown("Jump"))
        {
            //transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpPower, 0), ForceMode.Force);
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
            Debug.Log("Velocity of RB: " + GetComponent<Rigidbody>().velocity.ToString());
        }


        // restarting game
        if(Input.GetButton("restartGame")){

            // punt waar hij is
            // punt waarnartoe
            // bereken hoek
            // geef hem deze rotatie en hou de framerate in de gaten voor een smooth overgang


            // QUICK SOLUTION
            transform.position = startingPosition;
        }


    }

    private void FixedUpdate() {
                // Walking
        // ==================================================================
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            // create new vector without changing the x-/z-axis and let the object rotate on
            // the new obtained y-axis based on player-input
            // transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * movementSpeed * Time.deltaTime);
        
            // horizontale & verticale waarde vd input vd player
            float h = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
            float v = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

            Debug.Log(h);
            Debug.Log(v);

            rb.AddForce(transform.right * h, ForceMode.Impulse);
            rb.AddForce(transform.forward * v, ForceMode.Impulse);
        
        
        }
    }
}
