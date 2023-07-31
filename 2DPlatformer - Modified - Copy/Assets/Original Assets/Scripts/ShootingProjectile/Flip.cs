using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{

    public SpriteRenderer PlayerSprite;
    public GameObject FirePointLeft;
    public GameObject FirePointRight;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if((PlayerSprite.flipX == true))  //Facing Left
        {
            FirePointLeft.SetActive(true);
            FirePointRight.SetActive(false);
        }
        if ((PlayerSprite.flipX == false))  //Facing Left
        {
            FirePointLeft.SetActive(false);
            FirePointRight.SetActive(true);
        }
    }

 
}
