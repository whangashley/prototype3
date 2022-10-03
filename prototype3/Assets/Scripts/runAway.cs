using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runAway : MonoBehaviour
{
    public float speed;
    public float followStopDist;
    public float retreatDist;

    public Transform player;

    // public GameObject enemyObj;
    // enemyScript enemyNormalScript; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // enemyNormalScript = enemyObj.GetComponent<enemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (enemyNormalScript.currentHealth > 0) {
            //if the distance between the player's position is greater than the follow stop distance,
            if (Vector2.Distance(transform.position, player.position) > followStopDist)
            {
                //enemy moves towards the player's position
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, player.position, step);
                Debug.Log("follow");
            }
            //if the distance between the player's position is less than the retreat dist,
            else if (Vector2.Distance(transform.position, player.position) < retreatDist)
            {
                float step = -speed * Time.deltaTime;
                //enemy will move away
                transform.position = Vector2.MoveTowards(transform.position, player.position, step);
                Debug.Log("RUN AWAY");
            }
        // }            
    }

}
