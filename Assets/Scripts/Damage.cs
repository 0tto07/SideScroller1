using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public bool IsPlayer = false;
    public int DamageValue = -1;

    private void OnCollisionEnter2D(Collision2D collision2d)
    {
        if (IsPlayer)
        {
            var enemyScript = collision2d.transform.gameObject.GetComponent<GoombaEnemy>();

            if (enemyScript != null)
            {
                enemyScript.TakeDamage(DamageValue);
            }
        }
        else
        {
            var PlayerScript = collision2d.transform.gameObject.GetComponent<PhysicsCharacterController>();

            if (PlayerScript != null)
            {
                PlayerScript.TakeDamage(DamageValue);
            }
        }
     

     }
}        
