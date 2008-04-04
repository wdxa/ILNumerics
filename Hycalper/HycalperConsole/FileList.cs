using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace HycalperConsole {
    public class FileList {

        public class TemplateLocation {
            private string m_path = null;
            public string Path {
                get {
                    return m_path;
                }
                set {
                    m_path = value; 
                }
            } 
            private int m_uptodate = 0; 
            public int Uptodate {
                get {
                    return m_uptodate; 
                }
                set {
                    m_uptodate = value;
                }
            }
            public TemplateLocation(string path) {
                m_path = path; 
            }

        }
        string m_path = null; 
        Dictionary<string,DateTime> m_oldFileList = new Dictionary<string,DateTime>(); 
        List<TemplateLocation>  m_filenames = new List<TemplateLocation>();
        public FileList(string path) {
            m_path = path; 
            Refresh(path);
        }
        public void Refresh() {
            Refresh(m_path); 
        }

        public void Refresh(string path) {
            m_filenames = recursiveFindFiles ( path ); 
            foreach(TemplateLocation file in m_filenames) {
                if (m_oldFileList.ContainsKey(file.Path) && 
                    m_oldFileList[file.Path] == File.GetLastWriteTime(file.Path))
                    file.Uptodate = 1; 
            }
        }
        private List<TemplateLocation> recursiveFindFiles(string path) {
            List<TemplateLocation> found = new List<TemplateLocation>();  
            recursiveFindFiles(path,found);
            return found; 
        }
        private void recursiveFindFiles(string path, List<TemplateLocation> foundFiles) {
            string [] dirs = Directory.GetDirectories ( path );
            foreach (string dir in dirs) {
                recursiveFindFiles ( dir, foundFiles );
            }
            string [] files = Directory.GetFiles ( path, "*.cs" );
            foreach (string file in files)
                foundFiles.Add ( new TemplateLocation( file ) ); 
        }
        public int Count {
            get {
                return m_filenames.Count;
            }
        }
        public string this[int i] {
            get {
                return m_filenames[i].Path;
            }
        }
        public List<TemplateLocation> Collection {
            get {
                return m_filenames;
            }
        }
        public void Setuptodate (string file) {
            try {
                if (m_oldFileList.ContainsKey(file)){
                    m_oldFileList[file] = File.GetLastWriteTime(file); 
                } else {
                    m_oldFileList.Add(file,File.GetLastWriteTime(file));
                }
            } catch (Exception e) {
                Console.Out.WriteLine ("Error accessing file: " + e.Message); 
            }
        }
    }
}
