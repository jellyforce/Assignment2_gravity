using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;

    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // jump
        if (rb.velocity.y < 0)
        {
<<<<<<< Updated upstream
            // Debug.Log("velocity smaller as 0");
=======
>>>>>>> Stashed changes

            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        // fall and not pressing jump-button
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
<<<<<<< Updated upstream
            //Debug.Log("velocity bigger as 0 & no jumpbutton pressed");
=======
>>>>>>> Stashed changes

            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

        }
    }
}

