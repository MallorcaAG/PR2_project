using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    public CutsceneTrigger PlayerTrigger;

    public CameraController cam;
    public Transform stage;

    public GameObject dropBoss;
    public GameObject turnOnInvisibleWall1;
    public GameObject turnOnInvisibleWall2;
    public GameObject gameMusic1;
    public GameObject gameMusic2;
    public GameObject activateFirePoint;
    public GameObject platform;

    public GameObject Win;

    


    private void Update()
    {
        try
        {
            GameObject[] boss = GameObject.FindGameObjectsWithTag("Boss");
            if (boss.Length == 0)
            {
                Win.SetActive(true);
            }
        }
        catch { }
        


        if(PlayerTrigger != null && PlayerTrigger.isActivated)
        {
            StartCoroutine(InitiateBossBattle());
            PlayerTrigger.isActivated = false;
        }

    }

    private IEnumerator InitiateBossBattle()
    {
        gameMusic1.SetActive(false);
        turnOnInvisibleWall1.SetActive(true);
        turnOnInvisibleWall2.SetActive(true);

        cam.target = stage.transform;

        yield return new WaitForSeconds(1);
        dropBoss.SetActive(false);
        yield return new WaitForSeconds(3);
        gameMusic2.SetActive(true);
        activateFirePoint.SetActive(true);

        //yield return new WaitForSeconds(1);
        //gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        platform.SetActive(false);
    }
}
