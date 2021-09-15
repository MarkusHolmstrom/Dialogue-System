using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueList : MonoBehaviour
    {
        #region
        private readonly string line1 = "Hello world, lolz";

        #endregion

        public string name;
        public List<Dialogue> dialogues = new List<Dialogue>();


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    public class Dialogue
    {

        public List<DialogueNode> Nodes = new List<DialogueNode>();
    }
}


