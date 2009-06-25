#region Copyright GPLv3
//
//  This file is part of ILNumerics.Net. 
//
//  ILNumerics.Net supports numeric application development for .NET 
//  Copyright (C) 2007, H. Kutschbach, http://ilnumerics.net 
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  Non-free licenses are also available. Contact info@ilnumerics.net 
//  for details.
//
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing; 
using System.Runtime.InteropServices; 
using ILNumerics.Drawing.Interfaces;

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
