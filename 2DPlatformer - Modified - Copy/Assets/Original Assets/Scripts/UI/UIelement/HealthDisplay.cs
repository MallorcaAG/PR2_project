using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class intended to work with grid layout groups to create an image based health bar
/// </summary>
public class HealthDisplay : UIelement
{
    [Header("Settings")]
    [Tooltip("The image which represents one unit of health (heart sprite)")]
    public GameObject healthDisplayImage = null;

    // The previous health value to track changes in health
    private int previousHealth = -1;

    /// <summary>
    /// Description:
    /// Updates this UI element
    /// Input: 
    /// none
    /// Return: 
    /// void (no return)
    /// </summary>
    public override void UpdateUI()
    {
        if (GameManager.instance != null && GameManager.instance.player != null)
        {
            Health playerHealth = GameManager.instance.player.GetComponent<Health>();
            if (playerHealth != null)
            {
                if (playerHealth.currentHealth != previousHealth)
                {
                    SetChildImageNumber(playerHealth.currentHealth);
                    previousHealth = playerHealth.currentHealth;
                }
            }
        }
    }

    /// <summary>
    /// Description:
    /// Deletes and spawns images until this game object has as many children as the player has health
    /// Input: 
    /// int
    /// Return: 
    /// void (no return)
    /// </summary>
    /// <param name="number">The number of images that this object should have as children</param>
    private void SetChildImageNumber(int number)
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        if (healthDisplayImage != null)
        {
            for (int i = 0; i < number; i++)
            {
                Instantiate(healthDisplayImage, transform);
            }
        }
    }
}

