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
using System.Diagnostics; 

namespace ILNumerics.Drawing {
    /// <summary>
    /// This class represents the camera's positioning and aiming direction.
    /// </summary>
    [DebuggerDisplay("dist={m_distance},rot={m_phiDebugDisp}°,pitch={m_rhoDebugDisp}°")]
    public class ILCamera {

        #region event handling 
        /// <summary>
        /// fires, if the position of the camera has changed
        /// </summary>
        public event EventHandler Changed;
        /// <summary>
        /// Fires a Changed event
        /// </summary>
        public virtual void OnChange() {
            if (Changed != null && !m_suspended)
                Changed(this,new EventArgs()); 
        }
        #endregion

        #region attributes 
        private bool m_suspended = false;
        private float m_distance = 1.0f; 
        private float m_phi = (float)(Math.PI / 2.0); 
        private float m_rho = 0.0f; 
        /// <summary>
        /// Offset angle for 2nd cached triangular phi value (needed for surface plots)
        /// </summary>
        internal float Offset = (float)(Math.PI / 4); 
        /// <summary>
        /// cachced triangular phi value with offset (needed for surface plots)
        /// </summary>
        internal float CosPhiShift; 
        /// <summary>
        /// cachced triangular phi value with offset (needed for surface plots)
        /// </summary>
        internal float SinPhiShift; 
        /// <summary>
        /// cached value for cosine of phi - this is readonly and for performance only.
        /// </summary>
        internal float CosPhi; 
        /// <summary>
        /// cached value for sine of phi - this is readonly and for performance only.
        /// </summary>
        internal float SinPhi; 
        /// <summary>
        /// cached value for cosine of rho - this is readonly and for performance only.
        /// </summary>
        internal float CosRho; 
        /// <summary>
        /// cached value for sine of rho - this is readonly and for performance only.
        /// </summary>
        internal float SinRho; 
        private CameraQuadrant m_quadrant;
        #endregion

        #region properties 
        /// <summary>
        /// distance from the scene
        /// </summary>
        public float Distance {
            get {
                return m_distance; 
            }
            set {
                m_distance = value; 
                OnChange(); 
            }
        }
        /// <summary>
        /// debugger helper: display phi in degrees
        /// </summary>
        private int m_phiDebugDisp {
            get {
                return (int)Math.Round(m_phi * 180 / Math.PI); 
            }
        }
        /// <summary>
        /// debugger helper: display rho in degrees
        /// </summary>
        private int m_rhoDebugDisp {
            get {
                return (int)Math.Round(m_rho * 180 / Math.PI); 
            }
        }
        /// <summary>
        /// rotation of the scene (seen from above) [radians]
        /// </summary>
        public float Phi {
            get {
                return m_phi; 
            }
            set {
                m_phi = (float)((value + (Math.PI * 2)) % (Math.PI * 2)); 
                computeQuadrant();
                CosPhi = (float)Math.Cos(m_phi); 
                SinPhi = (float)Math.Sin(m_phi);
                SinPhiShift = (float)Math.Sin(m_phi + Offset); 
                CosPhiShift = (float)Math.Cos(m_phi + Offset); 
                OnChange(); 
            }
        }
        /// <summary>
        /// pitch of the scene [radians]
        /// </summary>
        public float Rho {
            get {
                return m_rho; 
            }
            set {
                if (value < 0.0f)
                    m_rho = 0.0f;
                else if (value > Math.PI)
                    m_rho = (float)Math.PI; 
                else 
                    m_rho = value; 
                computeQuadrant();
                CosRho = (float)Math.Cos(m_rho); 
                SinRho = (float)Math.Sin(m_rho); 
                OnChange(); 
            }
        }
        /// <summary>
        /// Quadrant the camera is currently watching the scene from
        /// </summary>
        public CameraQuadrant Quadrant {
            get{
                return m_quadrant; 
            }
        }
        /// <summary>
        /// Determine, if camera is placed in an upper quadrant of the scene
        /// </summary>
        public bool LooksFromTop {
            get {
                return m_rho < Math.PI/2; 
            }
        }
        /// <summary>
        /// Determine, if camera is located in an left quadrant of the scene
        /// </summary>
        public bool LooksFromLeft {
            get {
                return Math.Sin(m_phi) < 0; 
            }
        }
        /// <summary>
        /// Determine, if camera is located in an front quadrant of the scene
        /// </summary>
        public bool LooksFromFront {
            get {
                return Math.Cos(m_phi) >= 0; 
            }
        }
        /// <summary>
        /// true, when looking from top on the un-rotated scene (common for 2D plots)
        /// </summary>
        public bool Is2DView {
            get {
                return Math.Abs(SinPhi) < 1e-5 && Math.Abs(SinRho) < 1e-5; 
            }
        }
        #endregion 

        #region constructors
        public ILCamera (ILCamera vport) {
            m_rho = vport.m_rho; 
            m_phi = vport.m_phi; 
            m_distance = vport.m_distance; 
            computeQuadrant();
        }
        /// <summary>
        /// Create a viewport: view at scene from top, no rotation
        /// </summary>
        public ILCamera () {
            m_quadrant = CameraQuadrant.TopLeftFront; 
        }
        public ILCamera (float Phi, float Rho, float Distance) {
            m_rho = Rho; 
            m_phi = Phi; 
            m_distance = Distance; 
            computeQuadrant();
        }
        #endregion

        #region public interface 
        /// <summary>
        /// suspend the firing of events until EventingResume() was called
        /// </summary>
        public void EventingSuspend() {
            m_suspended = true; 
        }
        /// <summary>
        /// Resume firing 'Change' events after it has been suspended
        /// </summary>
        public void EventingResume() {
            m_suspended = false; 
        }
        /// <summary>
        /// Set both angles and distances at once  
        /// </summary>
        /// <param name="phi">Rotation, radians</param>
        /// <param name="rho">Pitch, radians</param>
        /// <param name="distance">Distance from scene</param>
        public void Set(float phi, float rho, float distance) {
            if (distance < 0) 
                throw new Exceptions.ILArgumentException("Camera distance must be positive!"); 
            m_phi = (float)(phi % (Math.PI * 2)); 
            m_rho = (float)(rho % (Math.PI)); 
            m_distance = distance; 
            computeQuadrant();
            CosRho = (float)Math.Cos(m_rho); 
            SinRho = (float)Math.Sin(m_rho); 
            OnChange(); 
        }
        /// <summary>
        /// Set complete camera position (angles and distance) at once
        /// </summary>
        /// <param name="phi">Rotation (degrees)</param>
        /// <param name="rho">Pitch (degrees)</param>
        /// <param name="distance">Distance from scene</param>
        public void SetDeg(float phi,float rho, float distance) { 
            Set ((float)(phi/180.0 * Math.PI),(float)(rho / 180.0f * Math.PI),distance); 
            OnChange(); 
        }
        /// <summary>
        /// Convert camera position to string
        /// </summary>
        /// <returns>string display with distance,roatation and pitch</returns>
        public override string ToString() {
            return String.Format("Dist={0},Rot={1}°,Pitch={2}°",
                m_distance,m_phiDebugDisp,m_rhoDebugDisp);
        }
        #endregion

        #region private helper 
        private void computeQuadrant() {
            //if (m_phi == 0.0 && m_rho == 0.0) {
            //    m_quadrant = CameraQuadrant.TopLeftFront; 
            //    return; 
            //}
            if (m_rho < System.Math.PI / 2) {
                // top 
                if (m_phi < Math.PI) {
                    // right
                    if (m_phi < Math.PI / 2) {
                        // front
                        m_quadrant = CameraQuadrant.TopRightFront; 
                    } else {
                        // back
                        m_quadrant = CameraQuadrant.TopRightBack; 
                    }
                } else {
                    // left
                    if (m_phi > Math.PI / 2 * 3) {
                        // front
                        m_quadrant = CameraQuadrant.TopLeftFront;
                    } else {
                        // back
                        m_quadrant = CameraQuadrant.TopLeftBack;
                    }
                }
            } else {
                // bottom
                if (m_phi < Math.PI) {
                    // right
                    if (m_phi < Math.PI / 2) {
                        // front
                        m_quadrant = CameraQuadrant.BottomRightFront; 
                    } else {
                        // back
                        m_quadrant = CameraQuadrant.BottomRightBack; 
                    }
                } else {
                    // left
                    if (m_phi > Math.PI / 2 * 3) {
                        // front
                        m_quadrant = CameraQuadrant.BottomLeftFront; 
                    } else {
                        // back
                        m_quadrant = CameraQuadrant.BottomLeftBack; 
                    }
                }
            }
        }
        #endregion
    }
}
