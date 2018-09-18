using UnityEngine;
using System.Collections;

public class Press_Space_to_Fire : MonoBehaviour
{
    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject Bullet_Emitter;



    // //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;

    //Enter the Speed of the Bullet from the Component Inspector.
    [Range(0, 10000)]
    public float bulletForce = 2000;

    // max of 3 bullets alowed at the time
    private int bulletCounter = 3;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //left mouse button
        if (Input.GetMouseButtonDown(0) && bulletCounter != 0)
        {
            StartCoroutine(ShootBullet());
        }

<<<<<<< Updated upstream
            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            // Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);
=======
    }
>>>>>>> Stashed changes


<<<<<<< Updated upstream
            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
            Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);
            //Temporary_RigidBody.AddTorque(new Vector3(transform.position.x + 90, transform.position.y, transform.position.z) * Time.deltaTime, ForceMode.Force);
            Temporary_RigidBody.AddTorque(transform.right * 2 * Time.deltaTime);


=======
>>>>>>> Stashed changes




    IEnumerator ShootBullet()
    {

        Debug.Log("?");
        // a gameobject is needed for instantiating objects
        GameObject TempBulletHandler;
        // set: object to be shoot, position of shootingpoint, rotation of shootingpoint
        TempBulletHandler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
        // shoot a bullet
        bulletCounter -= 1;
        Debug.Log("counter: " + bulletCounter);



        //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
        //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
        //Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);



        //Retrieve the Rigidbody component from the instantiated Bullet and control it.
        Rigidbody TempRigidBody;
        TempRigidBody = TempBulletHandler.GetComponent<Rigidbody>();
        //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force.
        TempRigidBody.AddForce(transform.forward * bulletForce);
        print("waiting for 1 second");
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(DestroyBullet(TempBulletHandler));

    }

    IEnumerator DestroyBullet(GameObject bullet)
    {
        print("start destroying bullet");
        Destroy(bullet);
        // add bullet to magazine
        bulletCounter += 1; ;
        Debug.Log("counter - after delete: " + bulletCounter);
        yield return null;
        print("done coroutine DestroyBullet()");
    }
}



