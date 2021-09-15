using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using DialogueSystem;

public class UIManager : MonoBehaviour
{
    //[SerializeField] private GameObject dialogueBox;

    private GameObject _mainCamera;
    private CameraHandler _cameraHandler;


    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _dialogueText;


    // Start is called before the first frame update
    void Awake()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        _cameraHandler = _mainCamera.GetComponent<CameraHandler>();
        _dialogueText.text = "Oh doctor, I think the patient is MonoBehaviour.Awake() now..."; // Sv startcoroutine?? . .. ...
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InteractWithNPC(string text, Vector3 pos)
    {
        _nameText.text = text;
        _cameraHandler.LookAtThis(pos);
    }

    public void ChangeDialogueText(string message)
    {
        _dialogueText.text = message;
    }

    public void ExitDialogue(string message)
    {
        _cameraHandler.UnlockCamera();
        _dialogueText.text = message;
    }
}


