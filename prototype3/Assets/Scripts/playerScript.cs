using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{

    public float speed;

    public Animator playerAnimator;

    // public bool isInteracting;
    // Start is called before the first frame update
    void Start()
    {
        // isInteracting = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerAnimator.SetFloat("speed", speed);

        if (DialogueManager.GetInstance().dialogueIsPlaying) {
            return;
        }

        if (Input.GetKey(KeyCode.W)) {
                if (transform.position.y < 3f) {
                    //then player 1 will move up
                    Move(Vector3.up);
                    }
                }
        else if (Input.GetKey(KeyCode.S)) {
                        //and if the player's y position is above the bottom of the screen
                if (transform.position.y > -4f) {
                    //then player 1 will move down
                    Move(Vector3.down);
                    }
                }

        if (Input.GetKey(KeyCode.D)) {
                if (transform.position.x < 5.5f) {
                    Move(Vector3.right);
                    }
                }
        else if (Input.GetKey(KeyCode.A)) {
                if (transform.position.x > -5.5f) {
                    Move(Vector3.left);
                    }
                }
        
        // if (Input.GetKey(KeyCode.I)) {
        //     isInteracting = true;
        //     Debug.Log("pressed I");
        // }
        // else {
        //     isInteracting = false;
        // }
    }

    //move function
    void Move(Vector3 direction) {
        transform.position += direction * speed;
        playerAnimator.SetFloat("speed", speed);
        // Debug.Log("moved");
    }
}