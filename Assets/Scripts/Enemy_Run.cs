using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Run : StateMachineBehaviour
{

	public float speed = 3.5f;
	public float attackRange = 3f;
	public float sightRange = 0f;
	Transform player;
	Rigidbody2D rb;
	Enemy enemy;
	public Transform attackPoint;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = animator.GetComponent<Rigidbody2D>();
		enemy = animator.GetComponent<Enemy>();
		attackPoint = enemy.attackPoint;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		sightRange = 20f;
		if (Vector2.Distance(player.position, rb.position) <= sightRange)
		{
			animator.SetTrigger("EnemyRun");

			enemy.LookAtPlayer();
			speed = 3f;
			Vector2 target = new Vector2(player.position.x, rb.position.y);
			Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
			rb.MovePosition(newPos);
		}
		else
		{
			animator.ResetTrigger("EnemyRun");
			
			animator.SetTrigger("EnemyIdle");
			
			Debug.Log("Disabled trigger 1 ");
		}

		if (Vector2.Distance(player.position, rb.position) <= attackRange)
		{
			animator.SetTrigger("EnemyKatanaAttack");
			//Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
			
			
			//player.GetComponent<Control>().
		}
        
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.ResetTrigger("EnemyKatanaAttack");
	}
	private void OnDrawGizmosSelected()
	{
		if (attackPoint == null)
		{
			return;
		}
		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}
}