using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model{

    public struct ItemStat
    {
        public int feel;
        public int growth;
        public int hunger;

        public ItemStat(int f, int g, int h) {
            feel = f; growth = g; hunger = h;
        }
    }
}
