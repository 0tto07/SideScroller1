using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPost : MonoBehaviour
{
    public SceneManager mySceneLoader = null;
    public string NextScene = "MainMenu";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        mySceneLoader.LoadScene(NextScene);
        {
            var PlayerScript = collision.transform.gameObject.GetComponent<PhysicsCharacterController>();

            if (PlayerScript != null) ;
        }
    }

}
