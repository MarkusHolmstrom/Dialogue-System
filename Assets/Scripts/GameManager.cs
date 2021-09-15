using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem;


public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _diaManagerGO; // Assign this in inspector
    private DialogueManager _dialogueManager;

    private GameObject _nurse;

    private GameObject _mainCamera;
    private CameraHandler _cameraHandler;

    private GameObject _uIGO;
    private UIManager _uIManager;

    void Awake()
    {
        _dialogueManager = _diaManagerGO.GetComponent<DialogueManager>();

        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        _cameraHandler = _mainCamera.GetComponent<CameraHandler>();

        _uIGO = GameObject.FindGameObjectWithTag("Canvas");
        _uIManager = _uIGO.GetComponent<UIManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _nurse = GameObject.FindGameObjectWithTag("Nurse");
        // Game starts:
        LookForNPC(_nurse, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LookForNPC(GameObject go, int index)
    {
        _uIManager.InteractWithNPC(go.tag, go.transform.position);
        _dialogueManager.ResetDialogue();
        _dialogueManager.StartDialogue(index);
    }

    public void BusyNPC(string message)
    {
        _dialogueManager.EndDialogue(message);
    }
}
