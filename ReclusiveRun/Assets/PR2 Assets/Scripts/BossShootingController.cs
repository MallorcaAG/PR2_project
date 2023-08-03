using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShootingController : MonoBehaviour
{

    [Header("GameObject/Component References")]
    [Tooltip("The projectile to be fired.")]
    public GameObject projectilePrefab = null;
    [Tooltip("The transform in the heirarchy which holds projectiles if any")]
    public Transform projectileHolder = null;


    public int MinFireRate = 6;
    public int MaxFireRate = 16;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(MinFireRate, MaxFireRate));
        SpawnProjectile();
        StartCoroutine(Attack());
    }

    public void SpawnProjectile()
    {
        // Check that the prefab is valid
        if (projectilePrefab != null)
        {
            // Create the projectile
            GameObject projectileGameObject = Instantiate(projectilePrefab, transform.position, transform.rotation, null);

            // Account for spread
            Vector3 rotationEulerAngles = projectileGameObject.transform.rotation.eulerAngles;
            projectileGameObject.transform.rotation = Quaternion.Euler(rotationEulerAngles);

            // Keep the heirarchy organized
            if (projectileHolder != null)
            {
                projectileGameObject.transform.SetParent(projectileHolder);
            }
        }
    }
}
