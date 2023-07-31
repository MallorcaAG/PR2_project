using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullHealPickup : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            Health PlayerHP = collision.gameObject.GetComponent<Health>();
            PlayerHP.ReceiveHealing(PlayerHP.maximumHealth);
            Destroy(this.gameObject);
        }
    }

}
