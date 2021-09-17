using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class NPC : MonoBehaviour
    {
        public enum Mood { Angry, Intrigued, Busy, Casual};
        public Mood mood = Mood.Casual;
        
        private GameObject _gMGO;
        private GameManager _gameManager;

        [SerializeField] private bool _isDoctor = true; // Simple boolean to tell the 2 NPCs a part

        public bool speaking = false;
        // Start is called before the first frame update
        void Awake()
        {
            _gMGO = GameObject.FindGameObjectWithTag("GameController");
            _gameManager = _gMGO.GetComponent<GameManager>();
            if (!_isDoctor)
            {
                tag = "Nurse";
            }
        }


        void OnMouseUp()
        {
            if (!speaking && mood != Mood.Busy)
            {
                _gameManager.StartDialogue(this.gameObject, 0);
                speaking = true;
            }
            else if (!speaking && mood == Mood.Busy)
            {
                _gameManager.BusyNPC("Stop talking to me, waste the nurses time instead, not mine!");
            }
        }

    }
}