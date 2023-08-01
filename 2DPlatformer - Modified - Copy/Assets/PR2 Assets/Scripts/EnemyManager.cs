using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

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

        yield return new WaitForSeconds(Random.Range(8, 12));

        StartCoroutine(Taunt());
    }

}
