using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueNode
    {
        public int nodeID = -1; 
        public List<DialogueOption> options = new List<DialogueOption>();

        public DialogueNode(int nodeID, List<DialogueOption> options)
        {
            this.nodeID = nodeID;
            this.options = options;
        }

    }
}

