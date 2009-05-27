using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 
using System.Runtime.InteropServices; 
using ILNumerics.Drawing.Interfaces;

namespace ILNumerics.Drawing.Interfaces {

    public interface IILVertexDefinition {
        bool StoresAlpha { get; }
        bool StoresColor { get; }
        bool StoresNormals { get; }
        byte Alpha { get; set; }
        Color Color { get; set; }
        ILPoint3Df Position { get; set; }
        ILPoint3Df Normal { get; set; }
        float XPosition { get; set; }
        float YPosition { get; set; } 
        float ZPosition { get; set; }
        /// <summary>
        /// size of single vertex in bytes
        /// </summary>
        int VertexSize { get; }
    }

}
namespace ILNumerics.Drawing.Shapes { 

    [StructLayout(LayoutKind.Sequential)]
    public struct C4bV3f : IILVertexDefinition {
        private byte R; 
        private byte G; 
        private byte B; 
        private byte A; 
        private float X; 
        private float Y; 
        private float Z;

        #region IILVertexDefinition Member

        public bool StoresAlpha {
            get { return true; }
        }

        public bool StoresColor {
            get { return true; }
        }

        public bool StoresNormals {
            get { return false; }
        }

        public int VertexSize { 
            get { return 16; } 
        }
        public byte Alpha {
            get { return A;  }
            set { A = value; }
        }
        public Color Color { 
            get { 
                return Color.FromArgb(A,R,G,B);  
            }
            set { 
                R = value.R; 
                G = value.G; 
                B = value.B;
                A = value.A; 
            }
        }
        public ILPoint3Df Position { 
            get {
                return new ILPoint3Df(X,Y,Z);    
            } 
            set{
                X = value.X; 
                Y = value.Y; 
                Z = value.Z; 
            }
        }
        public ILPoint3Df Normal { 
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }
        public float XPosition { 
            get { return X; }
            set { X = value; }
        }
        public float YPosition { 
            get { return Y; }
            set { Y = value; }
        }
        public float ZPosition { 
            get { return Z; }
            set { Z = value; }
        }
        #endregion
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct C4fN3fV3f : IILVertexDefinition {
        private float R; 
        private float G; 
        private float B; 
        private float A; 
        private float NX; 
        private float NY; 
        private float NZ; 
        private float X; 
        private float Y; 
        private float Z;

        #region IILVertexDefinition Member

        public bool StoresAlpha {
            get { return true; }
        }

        public bool StoresColor {
            get { return true; }
        }

        public bool StoresNormals {
            get { return true; }
        }

        public int VertexSize { 
            get { return 40; } 
        }
        public byte Alpha {
            get { return (byte)(A*255f);  }
            set { A = value/255f; }
        }
        public Color Color { 
            get { 
                return Color.FromArgb((int)(A*255),(int)(R*255),(int)(G*255),(int)(B*255));  
            }
            set { 
                R = value.R/255f; 
                G = value.G/255f; 
                B = value.B/255f;
            }
        }
        public ILPoint3Df Position { 
            get {
                return new ILPoint3Df(X,Y,Z);    
            } 
            set{
                X = value.X; 
                Y = value.Y; 
                Z = value.Z; 
            }
        }
        public ILPoint3Df Normal { 
            get { 
                return new ILPoint3Df(NX,NY,NZ); 
            }
            set { 
                NX = value.X; 
                NY = value.Y; 
                NZ = value.Z; 
            }
        }
        public float XPosition { 
            get { return X; }
            set { X = value; }
        }
        public float YPosition { 
            get { return Y; }
            set { Y = value; }
        }
        public float ZPosition { 
            get { return Z; }
            set { Z = value; }
        }
        #endregion
    }
}
