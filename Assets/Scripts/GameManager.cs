using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _diaManagerGO; // Assign this in inspector
    private DialogueManager _dialogueManager;

    private GameObject _nurse;


    private GameObject _uIGO;
    private UIManager _uIManager;

    void Awake()
    {
        _dialogueManager = _diaManagerGO.GetComponent<DialogueManager>();


        _uIGO = GameObject.FindGameObjectWithTag("Canvas");
        _uIManager = _uIGO.GetComponent<UIManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _nurse = GameObject.FindGameObjectWithTag("Nurse");
        // Game starts:
        StartDialogue(_nurse, 0);
    }

    public void StartDialogue(GameObject go, int index)
    {
        _uIManager.InteractWithNPC(go.tag, go.transform.position);
        _dialogueManager.ResetDialogue();
        _dialogueManager.GetNewDialogue(index);
    }

    public void BusyNPC(string message)
    {
        _dialogueManager.EndDialogue(message);
    }
}
