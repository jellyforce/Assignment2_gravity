using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // ==========================================================================================================
    //		With PathFinding
    // ==========================================================================================================


    // enemies fill follow you
    // this target variable is set by the enemyEmitter
    public GameObject target { get; set; }


    // first time instantiated? => walking will depend on it
    private bool isInitial { get; set; }




    // enemies need to walk with some speed
    [Range(3000, 10000)]
    public int enemyWalkingSpeed = 3500;

    // enemies have 3 lifepoints
    [Range(1, 30)]
    public int lifepoints = 3;



    Rigidbody rb;

    // ==========================================================================================================

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    // ==========================================================================================================


    // Use this for initialization
    void Start()
    {
        isInitial = true;
    }

    // ==========================================================================================================

    // Update is called once per frame
    void Update()
    {
        print("rb.transform" + rb.transform.position.ToString());
        print("target.transform: " + target.transform.position.ToString());
        Vector3 relPosition = target.transform.position - rb.transform.position;
        rb.transform.rotation = Quaternion.LookRotation(relPosition);
    }

    private void FixedUpdate()
    {
        //StartCoroutine(MovingTheEnemy());
    }



    IEnumerator MovingTheEnemy()
    {
        // wait 2 seconds before walking => enemy is being pushed to location by the Enemie_emitter
        if (this.isInitial == true)
        {
            yield return new WaitForSeconds(2.0f);
            this.isInitial = !this.isInitial;
        }
        else
        {
            rb.freezeRotation = true;
            rb.AddForce(transform.forward * 5000);
            rb.freezeRotation = false;
        }

    }

    // // ==========================================================================================================
    private void DealDamageToEnemy()
    {

    }
}
