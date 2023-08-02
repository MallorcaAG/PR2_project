using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [Header("GameObject/Component References")]
    [Tooltip("The projectile to be fired.")]
    public GameObject projectilePrefab = null;
    [Tooltip("The transform in the heirarchy which holds projectiles if any")]
    public Transform projectileHolder = null;

    private Animator enemyAnim;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();

        StartCoroutine(Taunt());
    }

    private IEnumerator Taunt()
    {
        enemyAnim.SetTrigger("Taunt");

        yield return new WaitForSeconds(Random.Range(2, 6));

        StartCoroutine(Taunt());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Projectile")
        {
            enemyAnim.SetTrigger("Hurt");
        }
        
    }
}
