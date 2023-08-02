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

    // The coroutine handle for heart regeneration
    private Coroutine regenerationCoroutine;

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
                    if (regenerationCoroutine != null)
                    {
                        StopCoroutine(regenerationCoroutine);
                    }
                    regenerationCoroutine = StartCoroutine(RegenerateHearts(playerHealth.currentHealth));
                    previousHealth = playerHealth.currentHealth;
                }
            }
        }
    }

    /// <summary>
    /// Description:
    /// Initialize the health display with hearts based on the player's starting health
    /// Input: 
    /// none
    /// Return: 
    /// void (no return)
    /// </summary>
    private void Start()
    {
        InitializeHearts();
    }

    /// <summary>
    /// Description:
    /// Initialize the health display with hearts based on the player's current health
    /// Input: 
    /// none
    /// Return: 
    /// void (no return)
    /// </summary>
    private void InitializeHearts()
    {
        if (GameManager.instance != null && GameManager.instance.player != null)
        {
            Health playerHealth = GameManager.instance.player.GetComponent<Health>();
            if (playerHealth != null)
            {
                SetChildImageNumber(playerHealth.currentHealth);
            }
        }
    }

    /// <summary>
    /// Description:
    /// Coroutine to regenerate hearts one at a time with a delay between each heart
    /// Input: 
    /// int targetHealth
    /// Return: 
    /// IEnumerator (coroutine)
    /// </summary>
    /// <param name="targetHealth">The target health value to reach</param>
    private IEnumerator RegenerateHearts(int targetHealth)
    {
        int currentHealth = transform.childCount;

        // If the target health is less than the current health, remove hearts
        for (int i = currentHealth; i > targetHealth; i--)
        {
            Destroy(transform.GetChild(i - 1).gameObject);
            yield return new WaitForSeconds(1f);
        }

        // If the target health is more than the current health, add hearts
        for (int i = currentHealth; i < targetHealth; i++)
        {
            Instantiate(healthDisplayImage, transform);
            yield return new WaitForSeconds(1f);
        }
    }

    /// <summary>
    /// Description:
    /// Deletes and spawns images until this gameobject has as many children as the player has health
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
            if (number > 0)
            {
                for (int i = 0; i < number; i++)
                {
                    Instantiate(healthDisplayImage, transform);
                }
            }
        }
    }
}
