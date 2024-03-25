using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Run : StateMachineBehaviour
{

	public float speed = 3.5f;
	public float attackRange = 1f;
	public float sightRange = 0f;
	Transform player;
	Rigidbody2D rb;
	Enemy enemy;
	public Transform attackPoint;
	float nextAttackTime = 0f;
	public float attackRate = 2f;
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
		GameObject player1 = GameObject.Find("Character1");
		player = player1.transform;
		if (Vector2.Distance(player.position, rb.position) <= sightRange)
		{
			animator.SetTrigger("EnemyRun");

			enemy.LookAtPlayer();
			speed = 4.5f;
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
		attackRange = 1f;
		if (Vector2.Distance(player.position, rb.position) <= attackRange)
		{
			if (Time.time >= nextAttackTime)
			{
				animator.SetTrigger("EnemyKatanaAttack");
				//enemy.GetComponent<Enemy>().TakeKatanaDamage(5);
				player.GetComponent<HPBar>().TakeKatanaDamage(5f);
				nextAttackTime = Time.time + 1f / attackRate;
			}
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