using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PhysicsCharacterController : MonoBehaviour
{
    public SpriteRenderer mySpriteRenderer = null;
    public List<Sprite> sprites = new List<Sprite>();
    public int HP = 1;

    //Refrence to rigidbody on same object
    public Rigidbody2D myRigidBody = null;

    public CharacterState JumpingState = CharacterState.Airborne;
    //Is Our character on the ground or in the air?

    //Gravity
    public float GravityPerSecond = 160.0f; //Falling Speed
    public float GroundLevel = 0.0f; //Ground Value

    //Jump
    public float JumpSpeedFactor = 3.0f; //How much faster is the jump than the movespeed?
    public float JumpMaxHeight = 150.0f;
    [SerializeField]
    private float JumpHeightDelta = 0.0f;
    private float JumpStartingY = 0.0f;
    //Movement
    public float MovementSpeedPerSecond = 10.0f; //Movement Speed


    private void Update()

    {
        if (Input.GetKeyDown(KeyCode.W) && JumpingState == CharacterState.Grounded)
        {
            JumpingState = CharacterState.Jumping; //Set character to jumping
            JumpHeightDelta = 0.0f; //Restart Counting Jumpdistance

        }
        if (HP <= 0)
        {
            SceneManager  MySceneLoader = gameObject.GetComponent<SceneManager>();
        }

        int hpCopy = HP - 1;
        if (hpCopy < 0)
        {
            hpCopy = 0;

        }
        if (hpCopy >= sprites.Count)
        {
            hpCopy = sprites.Count - 1;
        }
        mySpriteRenderer.sprite = sprites[hpCopy];



    }


    void FixedUpdate()
    {
        Vector3 characterVelocity = myRigidBody.velocity;
        characterVelocity.x = 0.0f;


        if (JumpingState == CharacterState.Jumping)
        {

            float totalJumpMovementThisFrame = MovementSpeedPerSecond * JumpSpeedFactor;
            characterVelocity.y = totalJumpMovementThisFrame;

            JumpHeightDelta += totalJumpMovementThisFrame * Time.deltaTime;

            if (JumpHeightDelta >= JumpMaxHeight)
            {
                JumpingState = CharacterState.Airborne;
                JumpHeightDelta = 0.0f;
                characterVelocity.y = 0.0f;
            }
        }

        //Left
        if (Input.GetKey(KeyCode.A))
        {
            characterVelocity.x -= MovementSpeedPerSecond;
        }
        //Right
        if (Input.GetKey(KeyCode.D))
        {
            characterVelocity.x += MovementSpeedPerSecond;
        }
        myRigidBody.velocity = characterVelocity;

        if (HP <= 0)
        {
            SceneManager mySceneLoader = gameObject.GetComponent<SceneManager>();
            if (mySceneLoader != null)
            {
                mySceneLoader.LoadScene("GameOver");
            }
        }
    }

    public void TakeDamage(int aHPValue)
    {
        HP += aHPValue;
    }
      
}