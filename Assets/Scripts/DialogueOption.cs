using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueOption
    {
        public string response;
        public Vector3Int dialogueIndex; // ID and location on the dialogueIndex array in class "DialogueManager"

        public DialogueOption(string response, Vector3Int dialogueIndex)
        {
            this.response = response;
            this.dialogueIndex = dialogueIndex;
        }
    }
}
