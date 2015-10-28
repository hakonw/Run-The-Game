using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameGameGameV1GernGame {
    class Input {
        
        //list of avilable keyboard buttons
        // https://msdn.microsoft.com/en-us/library/system.collections.hashtable%28v=vs.110%29.aspx 
        //this was done to be more flexible instead of a bool pr key 
        private static System.Collections.Hashtable keyTable = new System.Collections.Hashtable();
    
        //check state of key
        public static bool KeyPressed(Keys key) {
            if (keyTable[key] == null) {
                return false;
            }
            return (bool)keyTable[key];
        }

        //change state of key
        public static void ChangeState(Keys key, bool state) {
            keyTable[key] = state;
        }


    }
}
