using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
	Rigidbody2D rb;
	Vector2 fly_enemy_see;
	Transform player_pos;
	public float timer_y, timer_for_attack, flop_x, flop_y;
	public bool i_hit_player;
	private float timer_true_y, timer_for_attack_true;

	private EnemyStats stats;

	void Start()
	{
		stats = GetComponent<EnemyStats>();
		rb = GetComponent<Rigidbody2D>();
		GameObject player = GameObject.Find("Player");
		player_pos = player.GetComponent<Transform>();
		timer_true_y = timer_y;
		timer_for_attack_true = timer_for_attack;
	}

	void FixedUpdate()
	{
		if(timer_true_y <= 0){
			flop_y *= -1;
			timer_true_y = timer_y;
		}
		else
			timer_true_y -= Time.fixedDeltaTime;
		
		if(timer_for_attack_true <= 0){
			attack();
		}
		else {
        	Vector2 step = new Vector2(player_pos.position.x + flop_x, player_pos.position.y + flop_y + 2);
			fly_enemy_see = Vector2.MoveTowards(transform.position, step, stats.speed * Time.fixedDeltaTime);
		}
		rb.MovePosition(fly_enemy_see);
		timer_for_attack_true -= Time.fixedDeltaTime;
	}

	void attack()
	{
		Vector2 attack = new Vector2(player_pos.position.x, player_pos.position.y);
		fly_enemy_see = Vector2.MoveTowards(transform.position, attack, stats.speed * Time.fixedDeltaTime);
		if(Vector2.Distance(transform.position, player_pos.position) < 0.20f || i_hit_player){
			flop_x *= -1;
			timer_for_attack_true = timer_for_attack;
		}
	}
}