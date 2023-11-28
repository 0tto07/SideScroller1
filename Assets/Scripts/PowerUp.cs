using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int AddHealth = 1;
    private void OnCollisionEnter2D (Collision2D collision2d)
    {
        var PlayerScript = collision2d.transform.gameObject.GetComponent<PhysicsCharacterController>();

        if (PlayerScript != null)
        {
            PlayerScript.HP += 1;
            AddHealth = 0;
            GameObject.Destroy(gameObject);
        }
    }
}
