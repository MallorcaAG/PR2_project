using System.Collections;
using UnityEngine;

public class HealthRegeneration : MonoBehaviour
{
    public float healthRegenRate = 1.0f; // Health regenerated per second while standing still
    public float timeToStartRegen = 2.0f; // Time in seconds required to start health regeneration

    private Health playerHealth;
    private PlayerController playerController;
    private float timeSinceLastMove = 0.0f;

    public AudioSource regenSound;

    private void Start()
    {
        playerHealth = GetComponent<Health>();
        playerController = GetComponent<PlayerController>();

    }

    private void Update()
    {
        if (playerController.grounded && playerController.horizontalMovementInput == 0)
        {
            timeSinceLastMove += Time.deltaTime;
        }
        else
        {
            timeSinceLastMove = 0.0f;
        }

        if (timeSinceLastMove >= timeToStartRegen && playerHealth.currentHealth < playerHealth.maximumHealth)
        {
            RegenerateHealth();
            regenSound.Play();
        }
    }

    private void RegenerateHealth()
    {
        playerHealth.ReceiveHealing(Mathf.CeilToInt(healthRegenRate * Time.deltaTime));
    }
}
