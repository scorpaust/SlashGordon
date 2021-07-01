using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField]
    private GameObject damageCollider;

    private Animator anim;

	private void Awake()
	{
		anim = GetComponent<Animator>();
	}

	public void PlayAttack()
	{
		anim.SetTrigger(TagManager.ATTACK_TRIGGER_PARAM);
	}

	public void PlayDeath()
	{
		anim.SetBool(TagManager.DEATH_ANIMATION_PARAM, true);
	}

	private void ActivateDamageDetector()
	{
		damageCollider.SetActive(true);
	}

	private void DeactivateDamageDetector()
	{
		damageCollider.SetActive(false);
	}
}
