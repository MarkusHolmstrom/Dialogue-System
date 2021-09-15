using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class OtherPlayer : MonoBehaviour
    {
        public enum Mood { Angry, Intrigued, Busy, Casual};
        public Mood mood = Mood.Casual;
        
        [SerializeField] private GameObject _gMGO; // Assign in inspector
        private GameManager _gameManager;

        [SerializeField] private bool _isDoctor = true;

        public bool speaking = false;
        // Start is called before the first frame update
        void Awake()
        {
            _gMGO = GameObject.FindGameObjectWithTag("Canvas");
            _gameManager = _gMGO.GetComponent<GameManager>();
            if (!_isDoctor)
            {
                tag = "Nurse";
            }
        }


        void OnMouseUp()
        {
            if (!speaking)
            {
                _gameManager.LookForNPC(this.gameObject, 0);
                speaking = true;
                Debug.Log("This is a " + tag);
            }
            if (!speaking && mood == Mood.Busy)
            {
                _gameManager.BusyNPC();
            }
        }

    }
}