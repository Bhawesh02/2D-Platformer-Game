using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;
    [SerializeField]
    private float speed = 2f;

    private int currentWaypointIndex = 0;

    private void Update()
    {

        Patrol();

    }

    private void Patrol()
    {
        Transform wp = waypoints[currentWaypointIndex];
        if (Vector2.Distance(transform.position, wp.position) < 0.01f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, wp.position, speed * Time.deltaTime);
            if (currentWaypointIndex == 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControler>() != null)
        {
            collision.gameObject.GetComponent<PlayerControler>().DecreaseHealth();
            AudioManager.Instance.PlaySfxMusic(SoundType.EnemyDeath);
            Destroy(gameObject);
        }
    }
}
