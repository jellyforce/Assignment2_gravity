using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    // door needs to know what an enemy is
    public GameObject EnemyPrefab;
    public GameObject PlayerTargetOfEnemy;

    private int EnemyCount = 0;

    [Range(0.001f, 1)]
    public float EnemyMovementspeedInitial = 1;



    // check for door opening/closing animation
    private bool isOpenForward = false;
    private bool isOpenSideways = false;
    private bool isClosedForward = false;
    private bool isClosedSideways = false;


    // Use this for initialization
    void Start()
    {
        print("start");
        StartCoroutine(StartSpawnNewEnemy());
    }

    // Update is called once per frame
    void Update()
    {

        // if enemies.count < 4 {
        // start coroutine  spawn new enemy
    }

    IEnumerator StartSpawnNewEnemy()
    {


        // create enemies als er minder als 5 zijn
        if (EnemyCount != 3)
        {
            print("start coroutine OpenDoor()");
            // start openen deur
            StartCoroutine(OpenDoor());
            // wacht even op animatie van de deur
            // yield return new WaitForSeconds(2.0f);


            //StartCoroutine(MoveInitialEnemy());

            //StartCoroutine(CloseDoor());



            // start enemyspawn

            // enemy op locatie? => start coroutine sluitdeur

            // hierna moet de enemy vrij kunnen lopen


            yield return null;
        }



    }



    IEnumerator OpenDoor()
    {
        //transform of doorPanels
        var leftDoor = transform.parent.GetChild(0);
        var rightDoor = transform.parent.GetChild(1);
        Rigidbody rb_Left = leftDoor.GetComponent<Rigidbody>();
        Rigidbody rb_Right = rightDoor.GetComponent<Rigidbody>();

        print("start CoroutineDoor");


        if (!isOpenForward)
        {
            // add some forward force
            rb_Left.AddForce(leftDoor.forward * 50);
            rb_Right.AddForce(rightDoor.forward * 50);
            print("naar voren");

            // forward animation ends after 2 seconds
            yield return new WaitForSeconds(2.0f);
            isOpenForward = !isOpenForward;

            // slow down the object
            rb_Left.drag = 500;
            rb_Right.drag = 500;

            // make sure the object will be able to move again when closing the door
            rb_Left.drag = 1;
            rb_Right.drag = 1;

            // done
            yield return null;
        }

        if (!isOpenSideways)
        {
            // add sideway force to "open" the door
            rb_Left.AddForce(leftDoor.right * 120);
            rb_Right.AddForce(-rightDoor.right * 120);
            print("naar opzij");

            yield return new WaitForSeconds(2.5f);
            isOpenSideways = !isOpenSideways;
            rb_Left.drag = 500;
            rb_Right.drag = 500;

            rb_Left.drag = 1;
            rb_Right.drag = 1;

            // done
            yield return null;
        }



        // door is fully opened
        if (isOpenForward && isOpenSideways)
        {
            // enemy has to move trough the door
            StartCoroutine(MoveInitialEnemy());
            yield return new WaitForSeconds(2.0f);


            // start closing door
            StartCoroutine(CloseDoor(rb_Left, rb_Right));
            isOpenForward = !isOpenForward;
            isOpenSideways = !isOpenSideways;
            yield return null;
        }
        yield return null;
    }

    IEnumerator CloseDoor(Rigidbody leftDoor, Rigidbody rightDoor)
    {


        if (!isClosedSideways)
        {

            leftDoor.AddForce(-leftDoor.transform.right * 120);
            rightDoor.AddForce(rightDoor.transform.right * 120);
            print("door closed sideways");

            yield return new WaitForSeconds(2.5f);
            // slow down
            leftDoor.drag = 500;
            rightDoor.drag = 500;

            leftDoor.drag = 1;
            rightDoor.drag = 1;

            // false is set by door opener cause he will start a new routine
            isClosedSideways = !isClosedSideways;

            yield return null;
        }

        if (!isClosedForward)
        {
            // reverse sideway force to "close the door"
            leftDoor.AddForce(-leftDoor.transform.forward * 150);
            rightDoor.AddForce(-rightDoor.transform.forward * 150);
            print("naar achter");

            yield return new WaitForSeconds(3.0f);

            // slow down
            leftDoor.drag = 500;
            rightDoor.drag = 500;

            leftDoor.drag = 1;
            rightDoor.drag = 1;

            isClosedForward = !isClosedForward;

            yield return null;
        }

        yield return null;
    }

    IEnumerator MoveInitialEnemy()
    {
        // plek om enemies te spawnen
        GameObject Enemy_Emitter;
        Enemy_Emitter = Instantiate(EnemyPrefab, transform.position, transform.rotation);
        // set  player as target to the prefab that's being instantiated
        EnemyMovement enemy = Enemy_Emitter.GetComponent<EnemyMovement>();
        enemy.target = PlayerTargetOfEnemy;


        // push and slide
        print("enemy instantiated");
        Rigidbody tempRBEnemy = Enemy_Emitter.GetComponent<Rigidbody>();
        tempRBEnemy.AddForce(tempRBEnemy.transform.forward * 1000);
        yield return new WaitForSeconds(0.4f);
        tempRBEnemy.drag = 500;
        tempRBEnemy.drag = 1;
        yield return null;



        // all other movement will be done inside EnemyMovement script
    }
}
