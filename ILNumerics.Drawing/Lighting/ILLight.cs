using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 
using ILNumerics.Drawing.Collections; 

namespace ILNumerics.Drawing.Lighting {
    public class ILLight {

        #region eventing
        public EventHandler Changed; 
        protected void OnChanged() {
            if (Changed != null) {
                Changed(this, new EventArgs()); 
            }
        }
        #endregion

        #region attributes
        private bool m_enabled;
        private int m_index;
        private ILPoint3Df m_position;
        private Color m_specular;
        private Color m_emission;
        private Color m_ambient;
        private Color m_diffuse;
        #endregion

        #region properties
        public bool Enabled {
            get { return m_enabled; }
            set { 
                m_enabled = value; 
                OnChanged(); 
            }
        }
        public int Index {
            get { return m_index; }
        }
        public ILPoint3Df Position {
            get { return m_position; }
            set { 
                m_position = value;  
                OnChanged(); 
            }
        }
        public Color Specular {
            get { return m_specular; }
            set { 
                m_specular = value;  
                OnChanged(); 
            }
        }
        public Color Emission {
            get { return m_emission; }
            set { 
                m_emission = value;  
                OnChanged(); 
            }
        } 
        public Color Ambient {
            get {
                return m_ambient; 
            } 
            set {
                m_ambient = value; 
                OnChanged(); 
            }
        }
        public Color Diffuse {
            get {
                return m_diffuse; 
            } 
            set {
                m_diffuse = value; 
                OnChanged(); 
            }
        }
        #endregion

        #region constructors
        public ILLight (int index) {
            m_enabled = index == 0; 
            m_index = index; 
            Position = new ILPoint3Df(-10f,-100f,200);
            Specular = Color.FromArgb(140,140,140);  Specular = Color.Black;  
            Emission = Color.Black; 
            Ambient = Color.FromArgb(130,130,130); 
            Diffuse = Color.FromArgb(255,255,255);  
        }
        #endregion

        #region public interface

        #endregion

        #region private helpers

        #endregion



    }
}
