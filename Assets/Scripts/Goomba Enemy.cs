using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoombaEnemy : MonoBehaviour
    
{
    public int HP = 0;

    public void TakeDamage(int aHPValue)
    {
        HP += aHPValue;

        if (HP < 0)
        {
            GameObject.Destroy(gameObject);


        }

    }
        
    

   



    public Rigidbody2D myRigidBody = null;

    public float MovementSpeedPerSecond = 10.0f; //Movement Speed
    public float MovementSign = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 characterVelocity = myRigidBody.velocity;
        characterVelocity.x = 0.0f;

        characterVelocity += MovementSign * MovementSpeedPerSecond * transform.right.normalized;

        myRigidBody.velocity = characterVelocity;
    }
}
