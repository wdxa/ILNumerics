using System;
using System.Collections.Generic;
using System.Text;

namespace HycalperConsole {
    public class Hycalper {
        private readonly string m_startTagLoop = "!HC:START";
        private readonly string m_endTagLoop = "!HC:END"; 

        private Types m_pattern;
        public Hycalper(Types pattern) {
            m_pattern = pattern;
        }

        /// <summary>
        /// replace all occurences of all pattern keys in input and give back 
        /// all enumerations appendes after each other
        /// </summary>
        /// <param name="input"></param>
        /// <returns>the appended loops. kim: -> the original will not be given back!</returns>
        public string replaceAll(string input) {
            StringBuilder sbuild = new StringBuilder();
            for (int i = 0; i < m_pattern.Count; i++) {
                
            }
        }

    }
}
