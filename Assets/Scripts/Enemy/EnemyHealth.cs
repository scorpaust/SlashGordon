using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private bool destroyEnemy;

    public void TakeDamage()
	{

        if (gameObject.CompareTag(TagManager.ENEMY_TAG))
		{
            SoundManager.instance.PlayEnemyDeathSound();
		}
        else
		{
            SoundManager.instance.PlayDestroyObstacleSound();
        }

        if (destroyEnemy)
            Destroy(gameObject);
        else
            gameObject.SetActive(false);
	}
}
