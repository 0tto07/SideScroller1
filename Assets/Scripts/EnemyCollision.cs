using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] GoombaEnemy myEnemyScript = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 enemyscale = myEnemyScript.transform.localScale;
        enemyscale.x = -enemyscale.x;
        myEnemyScript.transform.localScale = enemyscale;
        myEnemyScript.MovementSign *= -1;
    }
}



