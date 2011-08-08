using System.Collections.Generic;
using System; 
using System.Text;
using System.Xml;
using System.Xml.XPath;

namespace HycalperConsole {
    public class Types {

        private Dictionary<string, string[]> m_pattern;
        private Dictionary<string, string> m_locate;
        private Dictionary<string, Dictionary<string,string>> m_attributes; 
        private int m_patternCount = 0;
        private string m_prefix = ""; 
        private Dictionary<string,string> m_endMarkOverride; 
        public Types(XmlDocument xml) {
            XmlNamespaceManager nsm = new XmlNamespaceManager(xml.NameTable); 
            m_pattern = new Dictionary<string, string[]>();
            m_locate = new Dictionary<string, string>();
            m_attributes = new Dictionary<string,Dictionary<string,string>>(); 
            m_endMarkOverride = new Dictionary<string,string>(); 
            XmlNodeList nl = xml.SelectNodes("hycalper/type", nsm);
            int lastLength = -1;
            foreach (XmlNode n in nl) {
                XmlNodeList destNodes = n.SelectNodes("destination",nsm);
                XmlNode srcNode = n.SelectNodes("source", nsm)[0];
                string key = ((string)srcNode.InnerText).Trim();
                string[] dest = new string [destNodes.Count];
                if (lastLength > -1) {
                    if (dest.Length != lastLength)
                        throw new Exception("The number of destination pattern "
                                    + "must be the same for all search patterns! Check number of patternd given for: '" 
                                    + (n["source"].InnerText).Trim().Replace(Environment.NewLine,"")
                                    + "'! It was expected to contain exact " + lastLength 
                                    + " destination definitions (according to the first type definition in the block!");
                } else {
                    lastLength = dest.Length;
                }
                for (int i = 0; i < dest.Length; i++) {
                    dest[i] = ((string)destNodes[i].InnerText); 
                }
                m_pattern.Add(key,dest); 
                XmlAttribute loc = srcNode.Attributes["locate"]; 
                if (loc != null && loc.Value != "") {
                    m_locate.Add(key,loc.Value); 
                } else {
                    m_locate.Add(key,"after"); 
                }
                if (!m_attributes.ContainsKey(key)) 
                    m_attributes.Add(key,new Dictionary<string,string>()); 
                foreach (XmlAttribute att in srcNode.Attributes) {
                    m_attributes[key].Add(att.Name,att.Value); 
                }
                XmlAttribute prefix = srcNode.Attributes["prefix"];
                if (prefix != null) {
                    m_prefix = (string)prefix.Value; 
                }
                XmlAttribute endMarkOverrideAttr = srcNode.Attributes["endmark"]; 
                if (!m_endMarkOverride.ContainsKey(key))
                    m_endMarkOverride.Add(key,HycalperConsole.DEFAULT_ENDREGION_CHARS); 
                if (endMarkOverrideAttr != null && !string.IsNullOrEmpty(endMarkOverrideAttr.Value)) {
                    m_endMarkOverride[key] = endMarkOverrideAttr.Value; 
                }
            }
            m_patternCount = lastLength; 
        }
        public string this[string key, int idx] {
            get {
                try {
                    return m_pattern[key][idx];
                } catch (Exception e) {
                    if (e is KeyNotFoundException) {
                        Console.Out.WriteLine("invalid key found: " + key);
                    } else if (e is IndexOutOfRangeException) {
                        Console.Out.WriteLine("invalid index specified for key '" + key + "' -> " + idx);
                    }
                    return null;
                }
            }
        }
        public Dictionary<string, Dictionary<string,string>> Attributes {
            get {
                return m_attributes; 
            } 
        }
        public Dictionary<string,string> EndMark {
            get {
                return m_endMarkOverride; 
            }
        }
        public Dictionary<string, string[]> Pattern {
            get {
                return m_pattern;
            }
        }
        public int CountKey {
            get {
                return m_pattern.Count;
            }
        }
        public int CountPattern {
            get {
                return m_patternCount;
            }
        }
        public string Location(string key) {
            return m_locate[key];
        }
    }
}
