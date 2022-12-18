using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Enum;

namespace Model{
    public class Message
    {
        private static string[] all_messages = {"feeding", "washing", "cleaning", "playing"};
        private static string[] chick_messages = { "egging" };
        private static string[] duck_messages = { "egging", "swimming" };
        private static string[] goat_messages = { "milk" };
        private static string[] pig_messages = { "swim dirt", "feed fruit" };
        private static string[] horse_messages = { "feed fruit", "walking", "racing", "riding" };
        private static string[] cow_messages = { "digging", "fighting" };



        private static int[] getLength(string name) {
            int[] length = new int[2];
            length[0] = System.Enum.GetValues(typeof(Behave_all)).Length;
            
            switch (name)
            {
                case "Pig":
                    length[1] = System.Enum.GetValues(typeof(Behave_pig)).Length;
                    break;
                case "Cow":
                    length[1] = System.Enum.GetValues(typeof(Behave_cow)).Length;
                    break;
                case "Chicken":
                    length[1] = System.Enum.GetValues(typeof(Behave_chick)).Length;
                    break;
                case "Goat":
                    length[1] = System.Enum.GetValues(typeof(Behave_goat)).Length;
                    break;
                case "Duck":
                    length[1] = System.Enum.GetValues(typeof(Behave_duck)).Length;
                    break;
                case "Horse":
                    length[1] = System.Enum.GetValues(typeof(Behave_horse)).Length;
                    break;
            }
            return length;
        }
        
        private static int[] getInts(int n) {
            int[] rand = new int[3];
            for (int i = 0; i < 3; i++) rand[i] = -1;
            int temp;
            while(true) {
                temp = Random.Range(0, n);
                for (int i = 0; i < 3; i++) {
                    if (rand[i] == -1){
                        rand[i] = temp;
                        break;
                    }
                    else if(rand[i] == temp) {
                        break;
                    }
                }

                bool check = true;
                for (int i = 0; i < 3; i ++) {
                    if (rand[i] == -1) {
                        check = false;
                        break;
                    }
                }
                if (check) break;
            }
            return rand;
        }

        private static string getAnimalMessage(string animal, int n) {
            switch (animal)
            {
                case "Cow":
                    return Message.cow_messages[n];
                case "Goat":
                    return Message.goat_messages[n];
                case "Chicken":
                    return Message.chick_messages[n];
                case "Horse":
                    return Message.horse_messages[n];
                case "Duck":
                    return Message.duck_messages[n];
                case "Pig":
                    return Message.pig_messages[n];
            }
            return "";
        }

        private static string getAllMessage(int n) {
            return Message.all_messages[n];
        }
        public static string[] getMessage(string animal) {
            int[] len = getLength(animal);
            int[] nums = getInts(len[0] + len[1]);
            // foreach (var i in nums) { Debug.Log(i); }
            string[] messages = new string[3];
            for (int i = 0; i < 3; i++) {
                messages[i] = nums[i] < len[0] ? getAllMessage(nums[i]) : getAnimalMessage(animal, nums[i]-len[0]);
                // Debug.Log(messages[i]);
            }
            return messages;
        }
    }
}
