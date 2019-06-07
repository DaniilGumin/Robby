using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class Skills : MonoBehaviour
    {
        static sbyte JumpPowerLvl = 0;
        public static float JumpPower = 2000f;
        static sbyte SpeedLvl = 0;
        public static float Speed = 20f;
        public static bool Shield = false;

        public void upJumpPowerLvl()
        {
            if (JumpPowerLvl<2) 
            {
                JumpPowerLvl += 1;
                JumpPower = 2000f + 150 * JumpPowerLvl;
            }
            else
            {
                Debug.Log("U can't do this");
            }
        }
        public void upSpeedLvl()
        {
            if (SpeedLvl<2) 
            {
                SpeedLvl += 1;
                Speed = 20f + 1 * SpeedLvl;
            }
            else
            {
                Debug.Log("U can't do this");
            }
        }
        public void addShield()
        {
            Shield = true;
        }
    }
}