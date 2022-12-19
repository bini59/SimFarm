using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Enum;



namespace Model{
    public class Message
    {
        private static string[] all_messages = {"먹이주기", "씻기기", "축사 청소하기", "놀아주기"};
        private static string[] chick_messages = { "알 낳기" };
        private static string[] duck_messages = { "알 낳기", "수영하기" };
        private static string[] goat_messages = { "젖 짜기" };
        private static string[] pig_messages = { "진흙 목욕 하기", "과일 주기" };
        private static string[] horse_messages = { "과일 주기", "산책하기", "승마" };
        private static string[] cow_messages = { "땅 갈기" };

        // stat : feel growth hunger
        private static ItemStat[] all_stat = { new ItemStat(0, 3, 4), new ItemStat(1, 0, 0), new ItemStat(2, 0, 0), new ItemStat(4, 0, 0) };
        private static ItemStat[] chick_stat = { new ItemStat(0, 5, 0)  };
        private static ItemStat[] duck_stat = { new ItemStat( 0, 5, 0 ), new ItemStat( 3, 0, 0 ) };
        private static ItemStat[] goat_stat = { new ItemStat( 0, 5, -2 ) };
        private static ItemStat[] pig_stat = { new ItemStat( 5, 0, 0), new ItemStat( 3, 0, 2) };
        private static ItemStat[] horse_stat = { new ItemStat( 3, 0, 2), new ItemStat( 6, 0, -2), new ItemStat( 1, 0, -1) };
        private static ItemStat[] cow_stat = { new ItemStat( -1, 2, -1) };

        public static ItemStat getStat(string animal, string message) {
            for (int i = 0; i < 4; i++) {
                if(message.Equals(all_messages[i])) return all_stat[i];
            }
            switch (animal)
            {
                case "Pig":
                    for (int i = 0; i < 2; i++) if(message.Equals(pig_messages[i])) return pig_stat[i];
                    break;
                case "Chicken":
                    for (int i = 0; i < 1; i++) if(message.Equals(chick_messages[i])) return chick_stat[i];
                    break;
                case "Duck":
                    for (int i = 0; i < 2; i++) if(message.Equals(duck_messages[i])) return duck_stat[i];
                    break;
                case "Goat":
                    for (int i = 0; i < 1; i++) if(message.Equals(goat_messages[i])) return goat_stat[i];
                    break;
                case "Horse":
                    for (int i = 0; i < 3; i++) if(message.Equals(horse_messages[i])) return horse_stat[i];
                    break;
                case "Cow":
                    for (int i = 0; i < 1; i++) if(message.Equals(cow_messages[i])) return cow_stat[i];
                    break;
            }
            return new ItemStat( 0, 0, 0 );
        }

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
                    if (n >= Message.cow_messages.Length) n = Message.cow_messages.Length - 1;
                    return Message.cow_messages[n];
                case "Goat":
                    if (n >= Message.goat_messages.Length) n = Message.goat_messages.Length - 1;
                    return Message.goat_messages[n];
                case "Chicken":
                    if (n >= Message.chick_messages.Length) n = Message.chick_messages.Length - 1;
                    return Message.chick_messages[n];
                case "Horse":
                    if (n >= Message.horse_messages.Length) n = Message.horse_messages.Length - 1;
                    return Message.horse_messages[n];
                case "Duck":
                    if (n >= Message.duck_messages.Length) n = Message.duck_messages.Length - 1; 
                    return Message.duck_messages[n];
                case "Pig":
                    if (n >= Message.pig_messages.Length) n = Message.pig_messages.Length - 1; 
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
