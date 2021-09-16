using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueOption
    {
        public string message;
        public Vector3Int dialogueIndex; // ID and location on the dialogueIndex array in class "DialogueManager"

        public DialogueOption(string message, Vector3Int dialogueIndex)
        {
            this.message = message;
            this.dialogueIndex = dialogueIndex;
        }
    }
}
