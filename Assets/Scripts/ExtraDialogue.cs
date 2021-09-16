using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class ExtraDialogue
    {
        public string[,,] dialogueLines = new string[4, 4, 4] { {       { "...", "Why is everything cubey and cylindery, and you know, boxy...", "I been to hospitals before, you know...", "[Sad] I really miss my rubber duck... the only true friend I ever had..." }, // 000, 001, 002, 003
                                                                        { "Everything looks weird, like a game, you know?", "What am I?", "Its full of cheerful students and drunk teachers...", "2nd 013" }, // 010, 011, 012, 103
                                                                        { "What is a 'med-student'?", "My head go: aow, aow!", "2nd 22", "2nd o23" }, // 020, 021, 022, 023
                                                                        { "This room have more decorations than our school...", "2nd 31", "2nd 032", "2nd 033" } }, // 030, 031, 032, 033

                                                                {
                                                                        { "Who the puck are you?", "[Dramatic] I think I can only explain myself in memes from now on...", "Racoons are awesome bruh!", "Ah, so I need to create a Singleton to solve this?" }, // 100, 101, 102, 103
                                                                        { "A 'doctor' what is that?", "Future games is the best one there is! [Proud]", "Well thanks for nothing doc! [End conversation]", "2nd 113" }, // 110, 111, 112, 113
                                                                        { "I am too old for that!", "I got your ball right here! [End conversation]", "2nd 122", "2nd 123" }, // 120, 121, 122, 123
                                                                        { "2nd 130", "2nd 131", "2nd 132", "2nd 133" } }, // 130, 131, 132, 133

                                                                {       { "I thought you be taller...", "It is place where you learn stuff...", "Thank you so much, may god be with you! [End conversation]", "2nd 203" }, // 200, 201, 202, 203
                                                                        { "Its a thing I am too cool for!", "Ok thanks doc! [End conversation]", "2nd 212", "2nd 213" }, // 210, 211, 212, 213
                                                                        { "2nd 220", "2nd 221", "2nd 222", "2nd 223" }, // 220, 221, 222, 223
                                                                        { "2nd 230", "2nd 231", "2nd 232", "2nd 233" } }, // 230, 231, 232, 233

                                                                {
                                                                        { "Its a place where you get drunk and makes mistakes?", "2nd 301", "2nd 302", "2nd 303" }, // 300, 301, 302, 303
                                                                        { "I wanna go home...", "2nd 311", "2nd 312", "2nd 313" }, // 310, 311, 312, 313
                                                                        { "2nd 320", "2nd 321", "2nd 322", "2nd 323" }, // 320, 321, 322, 323
                                                                        { "2nd 330", "2nd 331", "2nd 332", "2nd 333" } // 330, 331, 332, 333
                                                                }};

        public string[,,] answerLines = new string[4, 4, 4] { {         { "...", "Uh, cool... How do I look like?", "Ill bet you have, hopefully you wont be here for much longer...", "Are you still drunk, how is that even possible?" }, // 000, 001, 002, 003
                                                                        { "No I dont know, I cant see with your eyes dimwit!", "You are a human and a patient, happy?", "Hmm, at least one of thse statements are correct... [takes notes]", "2nd 013" }, // 010, 011, 012, 103
                                                                        { "I refer to the nurse you have been talking to, but if you want a real medical opnion, dont ask her, ask me, OK?", "[Sighs] Uh, mine too...", "2nd 22", "2nd o23"  }, // 020, 021, 022, 023
                                                                        { "[Intriged] Was that sarcasm?", "2nd 31", "2nd 032", "2nd 033" } },// 030, 031, 032, 033

                                                                {
                                                                        { "I am the doctor that can help you. The rest are occupied with more interesting cases...", "Well ok, but you dont remember your name or anything useful?", "They sure are, 'bruh', I like them more than I like patients, thats for sure.", "2nd 103" }, // 100, 101, 102, 103
                                                                        { "That is a person in this room that is about to lose its patience!", "Huh, how come I never heard of it? Sounds made up", "[End conversation]", "2nd 113" }, // 110, 111, 112, 113
                                                                        { "Really, you think?", "[End conversation]", "2nd 122", "2nd 123" }, // 120, 121, 122, 123
                                                                        { "2nd 130", "2nd 131", "2nd 132", "2nd 133" } }, // 130, 131, 132, 133

                                                                {       { "Okay, dont worry, you suffered from head trauma, a temporary loss of memory is usual.", "Okay, so your memory is not on a complete zero, close, but not zero, at least.", "Oh just luck off, and take that god with you! [End conversation]", "2nd 203" },  // 200, 201, 202, 203
                                                                        { "Oh, really, if you spent more time at schools you would be able to come up with a smarter reply than that.", "[End conversation]", "What does it look like, I am wearing these 'listen-to-your-heart-thingies' here!", "2nd 213" }, // 210, 211, 212, 213
                                                                        { "[Mutters something] why doesnt he return my messages? Ah, were you saying something?", "2nd 221", "2nd 222", "2nd 223" }, // 220, 221, 222, 223
                                                                        { "2nd 230", "2nd 231", "2nd 232", "2nd 233" } }, // 230, 231, 232, 233

                                                                {
                                                                        { "Yeah, well... thats partly correct, wouldnt you say nurse?", "2nd 301", "2nd 302", "2nd 303" }, // 300, 301, 302, 303
                                                                        { "2nd 310", "2nd 311", "2nd 312", "2nd 313" }, // 310, 311, 312, 313
                                                                        { "2nd 320", "2nd 321", "2nd 322", "2nd 323" }, // 320, 321, 322, 323
                                                                        { "2nd 330", "2nd 331", "2nd 332", "2nd 333" } // 330, 331, 332, 333
                                                                }};

    }
}
