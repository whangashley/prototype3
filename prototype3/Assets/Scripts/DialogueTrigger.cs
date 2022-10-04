using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    public GameObject visual;
    // [Header("Ink JSON")]
    // [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    // playerCombat playerScriptNormal;
    // public GameObject objPlayer;

    enemyScript enemyScriptNormal;
    public GameObject objEnemy;
    public bool readOnce;

    DialogueManager dialogueManagerScript;
    public GameObject objDialogueManager;

    public TextAsset inkJSON;
    private Story story;

    public bool angelAppear;
    public bool vizCueActivate;

    private void Awake () {
        playerInRange = false;
        visualCue.SetActive(false);
    }
    
    void Start() {
        // playerScriptNormal = objPlayer.GetComponent<playerCombat>();
        enemyScriptNormal = objEnemy.GetComponent<enemyScript>();
        dialogueManagerScript = objDialogueManager.GetComponent<DialogueManager>();
        // gameObject.SetActive(false);
        StartCoroutine(angelCountDown());
        visual.SetActive(false);
        angelAppear = false;
        vizCueActivate = false;
        // readOnce = false;
        story = new Story(inkJSON.text);
    }

    private void Update() {
        if (angelAppear == true)
        {
            // gameObject.SetActive(true);
            visual.SetActive(true);

            if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying && vizCueActivate) {
                visualCue.SetActive(true);
                if (InputManager.GetInstance().GetInteractPressed()) {
                    // Debug.Log(inkJSON.text);
                    // Debug.Log(story.Continue());
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                }
                // if (playerScriptNormal.isInteracting == true) {
                // Debug.Log(inkJSON.text);
                // }
            }
            else {
                visualCue.SetActive(false);
            }            
        }

        if (dialogueManagerScript.readOnce == true) {
            // gameObject.SetActive(false);
            visual.SetActive(false);
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            playerInRange = false;
        }
    }

    IEnumerator angelCountDown() {
        yield return new WaitForSeconds(30f);
        angelAppear = true;
        StartCoroutine(vizCueTrigger());
    }

    IEnumerator vizCueTrigger() {
        yield return new WaitForSeconds(20f);
        vizCueActivate = true;
    }
}
