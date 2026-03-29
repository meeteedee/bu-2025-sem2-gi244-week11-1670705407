using UnityEngine;

public class StunPowerUp : MonoBehaviour
{
    public float stunDuration = 5f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Enemy[] allEnemies = FindObjectsOfType<Enemy>();

            foreach (Enemy enemy in allEnemies)
            {
                enemy.StunEnemy(stunDuration);
            }

            Destroy(gameObject);
        }
    }
}