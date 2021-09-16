using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DialogueSystem
{
    public class GameState
    {
        public int currentlyTalkingToIndex = 0;
        public GameState(int currentlyTalkingToIndex)
        {
            this.currentlyTalkingToIndex = currentlyTalkingToIndex;
        }
        public int talkToNextNPCQue = 2; // Start talking to the doctor in this case when a counter in DialogueManager reaches this number
        public List<string> nPCNames = new List<string>();
        public List<string> allDialogueHistory = new List<string>();

    }

    public class DialogueManager : MonoBehaviour
    {
        public GameState gameState;
        private readonly string _nurse = "Nurse";
        private readonly string _doctor = "Doctor";

        public GameObject optionGO; // Assigned in inspector
        public Text[] optionTexts = new Text[3]; // Assigned in inspector, index = 0 is the top one
        public GameObject continueButton;
        public Button[] optionButtons = new Button[3];

        private readonly int lengthDialogueArray = 4;

        #region Dialogue lines
        public string[,,] dialogueLines = new string[4, 4, 4] { {       { "This is not being used...", "Mäöm, I dont wanna go to school today...", "I remember coding a game, then I talked to a rubber duck...", "[Sad] I miss my rubber duck..." }, // 000, 001, 002, 003
                                                                        { "Who are you?", "The last thing that I heard was someone saying 'What the f*ck', then it all went black.", "I think I am a student... at Hackerman University!", "But doc, tell me what I should do!" }, // 010, 011, 012, 103
                                                                        { "Why do you look like a cylinder?", "Yeah, I think I remember having some drinks now...", "The word 'Arboga' just hit my mind, can that mean something?", "Is it serious, can I die from this head trauma?" }, // 020, 021, 022, 023
                                                                        { "I can only see simple shapes, like cubes and cylinders, whats going on?", "I think I was in Huddinge...", "I dont want to be mortal...", "033" } }, // 030, 031, 032, 033

                                                                {
                                                                        { "Where am I?", "The only thing I remember was listening to AC/DC and someone giving me a drink...", "Do we need a for-loop to solve this?", "No need for you to be rude... rudey!" }, // 100, 101, 102, 103
                                                                        { "No I dont even know who I am. Wait, am I the Hackerman?", "I think I am a student at Future Games...", "I think I have a deadline tomorrow, I am tucked!", "I dont know, what should I look for?" }, // 110, 111, 112, 113
                                                                        { "I am confused, is this a some kind of a shit-faced game?", "Do you have any pretzels, I am kind of hungry?", "Wait, can I die? Can the hackerman die?", "Cant you make me immortal doc? I'll do anything for you!" }, // 120, 121, 122, 123
                                                                        { "Yeah you like a character from a shitty game!", "I dont need help, I am fine, Google will help us!", "Its where you learn how to hack in to mainframes and become memes!", "133" } }, // 130, 131, 132, 133

                                                                {       { "No I dont remember any thing...", "Why cant I remember anything?", "Who are you?", "I wanna go home!" }, // 200, 201, 202, 203
                                                                        { "Whatever I dont care, where is my phone? I wanna check some memes on Discord.", "My head feels kind of sore, is that helpful?", "I dont wanna die!, Help me, treat me doc!", "[Senses the trap] No, YOU explain the concept of a school to ME!" }, // 210, 211, 212, 213
                                                                        { "Sry, I am just confused...", "Does anyone really understand how Git works?", "What is that stick next to you?", "223" }, // 220, 221, 222, 223
                                                                        { "Your mama is so fat...", "Boooooooooooooooooooring!", "232", "233" } }, // 230, 231, 232, 233

                                                                {
                                                                        { "What is going on, is this a dream?", "I can honestly dont remember anything...", "Why is that, what is wrong, where is everyone else?", "303" }, // 300, 301, 302, 303
                                                                        { "One does not just simply wait for memes!", "I dont wanna play this any more!", "Its a building with walls and doctors, nurses and.. patients!", "313" }, // 310, 311, 312, 313
                                                                        { "What the hell is going on?", "The rubber ducks know where I live! [Horrified]", "322", "323" }, // 320, 321, 322, 323
                                                                        { "330", "331", "332", "333" } // 330, 331, 332, 333
                                                                }};

        public string[,,] answerLines = new string[4, 4, 4] { {         { "This is not being used...", "Uhm... Okay, you are at a hospital.", "Do not worry you feel confused, you have suffered from severe head trauma.", "We all have to cope with loss, pal..." }, // 000, 001, 002, 003
                                                                        { "I am a nurse, you are at a hospital.", "Oh my, the tox screen showed a severe intake of alcohol, but not close to being lethal.", "Oh yeah, and I am the plucking dean of medicine of Princeton!", "Ah, well, this 'doc' [points at himself]´dont know whats wrong with you." }, // 010, 011, 012, 103
                                                                        { "A cylinder? [looks worrying towards the doctor in the room] I am a human, not a cylinder!", "But you had no drugs, or anything like that? Any exotic travels receently?", "Of course you are mortal, who do you think you are?", "Yes, people die from head traumas all the time, they are more commonly knowns as idiots!" }, // 020, 021, 022, 023
                                                                        { "Cool... that means an injury to the occipital lobe. [Doctor is Intrigued]", "Huddinge, that sounds... well, made up... [sighs]", "Well it isnt really a choice is it, is not like you can just say; 'I am pro-life' and no one else will have a problem with that, right?", "033" } },// 030, 031, 032, 033

                                                                {
                                                                        { "You are at a hospital.", "Well ok, but you dont remember your name or anything useful?", "What is that, some cool programming-thingy?", "Yeah, there is no need for you to behave like an idiot either, but here we are!" }, // 100, 101, 102, 103
                                                                        { "Oh, I am over 30 years old, I dont get that reference...", "Oh my, you are a drunken fool and also a student, thats an odd couple.", "And if we dont figure out whats wrong with you, that deadline might seem miniscule to you...", "[Sighs] Is it anything you feel that would may be of interest to me, perhaps? I have no machine to help me, we only have the MRI nearby. It showed nothing." }, // 110, 111, 112, 113
                                                                        { "Aha, you really think I would appear in this shitty game?", "Pretzels, are you mad? You dont know who you are and you want pretzels?", "True memes never die, kid! But you will, well... you know eventually...", "Nah, even if i could, I probably would'nt..." }, // 120, 121, 122, 123
                                                                        { "Well, this character from that shitty game is the only one to help you!", "Everyone thinks they are a doctor or a programmer when Google came out, trust me, I know...", "You've been watching to many movies...", "133" } }, // 130, 131, 132, 133

                                                                {       { "Okay, dont worry, you have suffered from head trauma, a temporary loss of memory is usual.", "I put this in words you'll understand: Since you had an auchie in your headthingy, your memory have been compromised.", "[Annoyed] Dont worry your forgetful head about that...", "Me too, I was gonna order in some chinese tonight, and I dont mean the food. But those plans are in the dumpster now because of you..." },  // 200, 201, 202, 203
                                                                        { "Your memes can wait!", "[Sighs] We established a head injury already, where in the head does it hurt?", "Okay, as if the salary wasnt enough of an enticement to try to heal you!", "[Gives no shit about your trap and sighs] Is that how you gonna play this game, huh?" }, // 210, 211, 212, 213
                                                                        { "'Sry'? You know there is an 'o' and an additional 'r' in that word too?", "[Touches your forehead] Good news, you dont have a fever, you are just crazy!", "Oh its nothing [thumbles] its a baseball bat, I play with the Mets! Oh wait, you cant see what this is? [strunta i följdfråga]", "223" }, // 220, 221, 222, 223
                                                                        { "What, so fat that I got diabetes? You need to work on your insults...", "Yes, school seems to be 'boooooooring' - for stupid people! See what I did there? [Looks at the nurse]", "232", "233" } }, // 230, 231, 232, 233

                                                                {
                                                                        { "Why do you ask that, does something look weird to you?", "Well that concludes with the definition of memery loss...", "Theres a storm outside and its superbowl, why should you care? Worry about yourself right now and try to remember something.", "303" }, // 300, 301, 302, 303
                                                                        { "Oh, great, a millennial... just great.", "Niether do I, but atleast I get paid, so I am a bit happy.", "No... why do you think that?", "313" }, // 310, 311, 312, 313
                                                                        { "I dont know, but I can tell you whats off: my mood and your health! [Doctor mood: off]", "Yeah, you must watch out after them... [Sighs and scratches his head]", "322", "323" }, // 320, 321, 322, 323
                                                                        { "330", "331", "332", "333" } // 330, 331, 332, 333
                                                                }};

        // List of additional lines from NPCs, gets moved one index every time a NPC says something, leave a index empty
        // if they have nothing more to say than the reply from the 3D array above:
        private string[] additionalNPCLines = new string[] { // Nurse lines:
            "We found you at Åsögatan passed out, do you remember anything?", 
            "Now you just rest, the doctor will take care of you and figure out what is wrong.", 
            // Then doctor lines:
            "If you cant tell my anything useful, then just shut up! I need to think...",
            "My team cant help us now, its just you, me and a semi-decent med-student here to help you.",
            "Well whatever, how much memory-recollection do you have? Can you explain the concept of... a school for me?",
            "Ah... [sighs] Now leave me alone, talk to the nurse or something, I need some... where is my ball?"};


        #endregion

        private Vector3Int _currentDialogueIndex;
        private DialogueOption _currentOption;
        private List<DialogueOption> _currentOptions = new List<DialogueOption>();

        private GameObject _uIGO;
        private UIManager _uIManager;
        private string[,,] _currentDialogueLines = new string[4, 4, 4];
        private string[,,] _currentAnswerLines = new string[4, 4, 4];


        private int _currentIndex = 0;

        private int _counter = 0;
        private int _addLinesCounter = 0;

        void Awake()
        {
            _uIGO = GameObject.FindGameObjectWithTag("Canvas");
            _uIManager = _uIGO.GetComponent<UIManager>();
            // This instance keeps track of dialouge history and a list of those to talk to, put them in order of apperance:
            gameState = new GameState(0);
            gameState.nPCNames.Add(_nurse);
            gameState.nPCNames.Add(_doctor);
        }

        // Reset to start the dialogue, added with string arrays so the demo will work:
        public void ResetDialogue()
        {
            gameState.currentlyTalkingToIndex = 0;
            _addLinesCounter = 0;
            _currentDialogueIndex = Vector3Int.zero;

            _currentDialogueLines = dialogueLines;
            _currentAnswerLines = answerLines;
        }

        public void GetNewDialogue(int index)
        {
            _currentIndex = index;
            optionGO.SetActive(true);
            DialogueNode node;

            if (_addLinesCounter != additionalNPCLines.Length) // If we havent reached the end:
            {
                node = new DialogueNode(index, FindOptions(_currentDialogueIndex));
            }
            else
            {
                node = new DialogueNode(index, GetEndingOptions());
            }

            int optionIndex = 0;
            foreach (DialogueOption item in node.options)
            {
                // Check to see if this answer/question has already been given/said:
                if (gameState.allDialogueHistory.Contains(item.message)) 
                {
                    optionButtons[optionIndex].interactable = false;
                }
                else
                {
                    optionButtons[optionIndex].interactable = true;
                }
                optionTexts[optionIndex].text = item.message;
                optionIndex++;
            }
            optionGO.SetActive(false);
            continueButton.SetActive(true);
        }

        private List<DialogueOption> FindOptions(Vector3Int v3)
        {
            _currentOptions = new List<DialogueOption>();
            Vector3Int newOptionLocation = new Vector3Int(v3.x + 1, v3.y + 1, v3.z + 1);
            // If the dialogue in this class is complete:
            if (newOptionLocation.x >= lengthDialogueArray || newOptionLocation.y >= lengthDialogueArray || newOptionLocation.z >= lengthDialogueArray)
            {
                ExtraDialogue extraDialogue = new ExtraDialogue();
                _currentDialogueLines = extraDialogue.dialogueLines;
                _currentAnswerLines = extraDialogue.answerLines;
                _currentIndex = 0;
                v3 = Vector3Int.zero;
                newOptionLocation = new Vector3Int(v3.x + 1, v3.y + 1, v3.z + 1);
            }

            // Create a list with the options for the given dialogue node, adding with one for every dimension (x, y or z) and possibility
            _currentOptions.Add(AddNewOption(new Vector3Int(newOptionLocation.x, v3.y, v3.z)));
            _currentOptions.Add(AddNewOption(new Vector3Int(v3.x, newOptionLocation.y, v3.z)));
            _currentOptions.Add(AddNewOption(new Vector3Int(v3.x, v3.y, newOptionLocation.z)));

            return _currentOptions;
        }
        // Make sure the player has conversation-ending options at the end:
        private List<DialogueOption> GetEndingOptions()
        {
            _currentOptions = new List<DialogueOption>();
            ExtraDialogue extraDialogue = new ExtraDialogue();
            _currentDialogueLines = extraDialogue.dialogueLines;
            _currentOptions.Add(AddNewOption(new Vector3Int(1, 1, 2)));
            _currentOptions.Add(AddNewOption(new Vector3Int(1, 2, 1)));
            _currentOptions.Add(AddNewOption(new Vector3Int(2, 1, 1)));

            return _currentOptions;
        }

        private DialogueOption AddNewOption(Vector3Int v3)
        {
            DialogueOption option = new DialogueOption(_currentDialogueLines[v3.x, v3.y, v3.z], v3);
            return option;
        }


        public void ChooseOption(int index) // Activated through buttons in "optionsGO"
        {
            if (_addLinesCounter >= additionalNPCLines.Length) // Done with the conversation:
            {
                // ugly quick-fix to change the doctor's mood:
                GameObject doc = GameObject.FindGameObjectWithTag("Doctor");
                OtherPlayer op = doc.GetComponent<OtherPlayer>();
                op.mood = OtherPlayer.Mood.Busy;

                EndDialogue(additionalNPCLines[additionalNPCLines.Length - 1]);
                return;
            }
            if (_currentIndex < lengthDialogueArray)
            {
                _currentIndex++;
            }
            _currentOption = _currentOptions[index];
            gameState.allDialogueHistory.Add(_currentOption.message);

            _currentDialogueIndex = _currentOption.dialogueIndex;

            _uIManager.ChangeDialogueText(_currentAnswerLines[  
                _currentOption.dialogueIndex.x, 
                _currentOption.dialogueIndex.y, 
                _currentOption.dialogueIndex.z   ] + " " + additionalNPCLines[_addLinesCounter]);

            _addLinesCounter++;
            
            if (_counter < gameState.nPCNames.Count)
            {
                _counter++;
            }
            
            if (NewInteractNPC(_counter))
            {
                _uIManager.InteractWithNPC(gameState.nPCNames[gameState.currentlyTalkingToIndex], 
                    GameObject.FindGameObjectWithTag(gameState.nPCNames[gameState.currentlyTalkingToIndex]).transform.position);
            }

            GetNewDialogue(_currentIndex);
        }

        private bool NewInteractNPC(int counter)
        {
            if (counter < gameState.talkToNextNPCQue)
            {
                return false;
            }
            this._counter = 0;
            if (gameState.currentlyTalkingToIndex < gameState.nPCNames.Count - 1)
            {
                gameState.currentlyTalkingToIndex++;
            }
            return true;
        }


        public void ContinueDialogue()
        {
            continueButton.SetActive(false);
            optionGO.SetActive(true);
        }

        public void EndDialogue(string message)
        {
            continueButton.SetActive(false);
            optionGO.SetActive(false);
            _uIManager.ExitDialogue(message);
        }

    }
}
