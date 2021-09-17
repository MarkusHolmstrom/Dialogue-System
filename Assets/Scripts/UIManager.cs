using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using DialogueSystem;

public class UIManager : MonoBehaviour
{
    private GameObject _mainCamera;
    private CameraHandler _cameraHandler;

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _dialogueText;

    [SerializeField] private float _typingSpeed = 0.3f;
    [SerializeField] private bool _letterAnimationActivated = true;


    // Start is called before the first frame update
    void Awake()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        _cameraHandler = _mainCamera.GetComponent<CameraHandler>();
        ChangeDialogueText("Oh doctor, I think the patient is MonoBehaviour.Awake() now..."); 
    }


    public void InteractWithNPC(string text, Vector3 pos)
    {
        _nameText.text = text;
        _cameraHandler.LookAtThis(pos);
    }

    public void ChangeDialogueText(string message)
    {
        if (_letterAnimationActivated)
        {
            StartCoroutine(BuildText(message));
        }
        else
        {
            _dialogueText.text = message;
        }
    }

    private IEnumerator BuildText(string message)
    {
        _dialogueText.text = "";
        for (int i = 0; i < message.Length; i++)
        {
            _dialogueText.text = string.Concat(_dialogueText.text, message[i]);
            yield return new WaitForSeconds(_typingSpeed * Time.deltaTime);
        }
    }

    public void ExitDialogue(string message)
    {
        _cameraHandler.UnlockCamera();
        _dialogueText.text = message;
    }
}


