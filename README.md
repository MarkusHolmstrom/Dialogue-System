# Dialogue-System
School assignment

Hello! This is a dialogue system with an example scene. There is a multi-choice system with 3 different options for every reply,
and the NPC respond differently depending on what you chose. 

Story of the scene:
The player wakes up at a hospital with amnesia and ther is only a nurse and a doctor there to help you. The conversation starts with the
nurse and ends with the doctor. After the conversation the camera gets free, player can then look around (to look at nothing, really)
and go trough the conversation again starting with the nurse, excluding the question already been asked. The doctor wont talk to you
initially at this point, since he is busy at that time.

The dialogue lines are saved with a 3D array of strings and this is not a good solution when it comes to implementing dialogue to the game, but 
works with the story-navigation system. To get 3 options for every DialogueNode, it simply adds one for one of the index's in the array, you
either take a step in x, y or z in the array's index.

It would be better to replace this with a system that can read text files and create a Tree-like node system for the options and the navigation
along the tree, but I avoided this because the lack of time. I wanted to get a system that works and make it easy to configure, but the latter 
was not the case.
