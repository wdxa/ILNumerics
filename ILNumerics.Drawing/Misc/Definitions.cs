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
using ILNumerics.Drawing.Graphs; 


namespace ILNumerics.Drawing {
    /// <summary>
    /// Orientation for labels and other purposes
    /// </summary>
    public enum TextOrientation {
        Horizontal,
        Vertical
    }
    /// <summary>
    /// Alignment for 
    /// </summary>
    public enum VerticalAlignment {
        Lower,
        Middle,
        Upper
    }
 
    /// <summary>
    /// Suggest, how label positions for axis ticks are to be choosen
    /// </summary>
    public enum TickLabelRenderingHint {
        /// <summary>
        /// tick labels will optimally fill the whole axis length
        /// </summary>
        Filled, 
        /// <summary>
        /// multiples of 10^n will be prefered for label steps
        /// </summary>
        Multiple1,
        /// <summary>
        /// multiples of 2*10^n will be prefered for label steps
        /// </summary>
        Multiple2,
        /// <summary>
        /// multiples of 5*10^n will be prefered for label steps
        /// </summary>
        Multiple5,
        /// <summary>
        /// Try to find the optimal division for tick label steps [default]
        /// </summary>
        /// <remarks>This method is the most computational intensive one.</remarks>
        Auto
    }
    
    /// <summary>
    /// Names for all 3 axes 
    /// </summary>
    public enum AxisNames {
        XAxis = 0,
        YAxis = 1,
        ZAxis = 2
    }

    /// <summary>
    /// simple single unlabled tick
    /// </summary>
    public struct UnlabeledTick {
        /// <summary>
        /// Position of tick
        /// </summary>
        public float Position; 
    }
    /// <summary>
    /// Axis ticks spacing type: linear, logarithmic
    /// </summary>
    public enum AxisType {
        /// <summary>
        /// linear axis tick spacing
        /// </summary>
        Linear,
        /// <summary>
        /// logarithmic axis tick spacing
        /// </summary>
        Logarithmic
    }
    /// <summary>
    /// On which sides ticks will be displayed
    /// </summary>
    public enum TickDisplay {
        /// <summary>
        /// ticks for axis will be displayed on label side only
        /// </summary>
        LabelSide, 
        /// <summary>
        /// ticks for axis will be displayed on label - and the opposite site 
        /// </summary>
        BothSides
    }
    /// <summary>
    /// how ticks are displayed (inside/outside)
    /// </summary>
    public enum TickDirection {
        /// <summary>
        /// Ticks will lay inside the rendering cube
        /// </summary>
        Inside, 
        /// <summary>
        /// Ticks will lay outside the rendering cube
        /// </summary>
        Outside
    }

    /// <summary>
    /// orientation for axis labels (not implemented)
    /// </summary>
    public enum ILAxisLabelOrientation {
        Normal, 
        Rotate90,
        Rotate180,
        Rotate270,
        Arbitrary
    }
    /// <summary>
    /// TickModes - automatic or manual axis tick positioning
    /// </summary>
    public enum TickMode {
        /// <summary>
        /// find tick positions automatically 
        /// </summary>
        Auto,
        /// <summary>
        /// manually create ticks 
        /// </summary>
        Manual
    }
    /// <summary>
    /// Alignments for axis labels 
    /// </summary>
    public enum AxisLabelAlign {
        /// <summary>
        /// align the axis label near the lower axis range limit
        /// </summary>
        Lower, 
        /// <summary>
        /// align the axis label in the center of axis
        /// </summary>
        Center,
        /// <summary>
        /// align the axis label near the upper axis range limit
        /// </summary>
        Upper
    }
    /// <summary>
    /// Possible alignments for tick labels
    /// </summary>
    /// <remarks>member of this enum can get bitwise combined. Default is: Top,Left</remarks>
    [FlagsAttribute]
    public enum TickLabelAlign {
        /// <summary>
        /// align the label to the left side
        /// </summary>
        left = 0,
        /// <summary>
        /// align the labels to the center
        /// </summary>
        center = 1,
        /// <summary>
        /// align the label to the right side
        /// </summary>
        right = 2, 
        /// <summary>
        /// align the label to top
        /// </summary>
        top = 0,
        /// <summary>
        /// align the label to center vertically 
        /// </summary>
        vertCenter = 4,
        /// <summary>
        /// align the label to bottom
        /// </summary>
        bottom = 16
    }

    /// <summary>
    /// projection types
    /// </summary>
    public enum Projection {
        /// <summary>
        /// 3D graphs will be distorted for opotimized 3D impression
        /// </summary>
        Perspective,
        /// <summary>
        /// graphs will not be distorted. objects in the front will get the same size as objects in the back
        /// </summary>
        Orthographic
    }

    /// <summary>
    /// valid marker styles (partially supported)
    /// </summary>
    public enum MarkerStyle {
        /// <summary>
        /// draw markers as dots
        /// </summary>
        Dot,
        /// <summary>
        /// draw markers as circle
        /// </summary>
        Circle, 
        /// <summary>
        /// draw markers as diamonds
        /// </summary>
        Diamond,
        /// <summary>
        /// draw markers as square
        /// </summary>
        Square,
        /// <summary>
        /// draw markers as up pointing triangles
        /// </summary>
        Triangle,
        /// <summary>
        /// draw markers as plus
        /// </summary>
        Plus,
        /// <summary>
        /// draw markers as cross
        /// </summary>
        Cross,
        /// <summary>
        /// do not draw markers
        /// </summary>
        None,
        /// <summary>
        /// draw markers as user defined bitmap
        /// </summary>
        Bitmap
    }
    /// <summary>
    /// Possible positions of the camera
    /// </summary>
    public enum CameraQuadrant {
        TopLeftFront,
        TopLeftBack,
        TopRightBack,
        TopRightFront,
        BottomLeftFront,
        BottomLeftBack,
        BottomRightBack,
        BottomRightFront
    }
    /// <summary>
    /// Shading styles for surface graphs
    /// </summary>
    public enum ShadingStyles {
        /// <summary>
        /// color will be interpolated between all corners 
        /// </summary>
        Interpolate, 
        /// <summary>
        /// same color for whole tile area
        /// </summary>
        /// <remarks>The resulting color will 
        /// reflect the average over all corner values for a rectangle</remarks>
        Flat   
    }

    /// <summary>
    /// line style
    /// </summary>
    public enum LineStyle {
        /// <summary>
        /// solid line
        /// </summary>
        Solid = Int32.MaxValue, 
        /// <summary>
        /// dashed line
        /// </summary>
        Dashed = Int16.MaxValue,
        /// <summary>
        /// point dashed line
        /// </summary>
        PointDash = unchecked((int)4294837760),
        /// <summary>
        /// dotted line
        /// </summary>
        Dotted = unchecked((int)3435973836),
        /// <summary>
        /// use user stipple pattern 
        /// </summary>
        UserPattern = -1,
        /// <summary>
        /// no line at all
        /// </summary>
        None = 0
    }
    /// <summary>
    /// Mouse interaction mode for subfigures (not implemented yet)
    /// </summary>
    public enum InteractiveModes {
        ZoomRectangle, 
        Rotating,
        Selecting,
        None
    }
    /// <summary>
    /// single precision 3D point definition
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ILPoint3Df {
        public float X;
        public float Y;
        public float Z;
        /// <summary>
        /// create point in single precision
        /// </summary>
        /// <param name="x">X coord</param>
        /// <param name="y">Y coord</param>
        /// <param name="z">Z coord</param>
        public ILPoint3Df (float x, float y, float z) {
            X = x; 
            Y = y; 
            Z = z; 
        }
        /// <summary>
        /// convert this point to string representation
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return "X:" + X.ToString() + " Y:" + Y.ToString() + " Z:" + Z.ToString(); 
        }
        /// <summary>
        /// Access to coords by index
        /// </summary>
        /// <param name="index">index number: 0=x, 1=y, 2=z</param>
        /// <returns>float value of coord specified</returns>
        public float this[int index] {
            get {
                switch (index) {
                    case 0:
                        return X;
                    case 1: 
                        return Y;
                    default: 
                        return Z;
                }
            }
        }
    }
    /// <summary>
    /// double precision 3D point definition
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ILPoint3Dd {
        /// <summary>
        /// X coord
        /// </summary>
        public double X;
        /// <summary>
        /// Y coord
        /// </summary>
        public double Y;
        /// <summary>
        /// Z coord
        /// </summary>
        public double Z;
    }
    /// <summary>
    /// supported graphics devices
    /// </summary>
    public enum GraphicDeviceType {
        /// <summary>
        /// DirectX based 
        /// </summary>
        Direct3D,
        /// <summary>
        /// OpenGL based (not supported yet)
        /// </summary>
        OpenGL,
        /// <summary>
        /// Windows native graphics device (not implemented)
        /// </summary>
        GDI,
        /// <summary>
        /// unknown graphics device (not used, errror)
        /// </summary>
        Unknown
    }
    /// <summary>
    /// valid types for plotting graphs
    /// </summary>
    public enum GraphType {
        Axis,
        Plot2D,
        Plot3D,
        Surf,
        Mesh,
        Waterfall,
        Ribbon,
        Image,
        Imagesc,
        PColor,
        Contour,
        CountourFilled,
        ContourSlice,
        Scatter,
        Scatter3,
        Errorbar,
        Stem,
        Stairs,
        Stem3,
        Bar,
        BarHorizontal,
        Auto
    }
    /// <summary>
    /// Coordinate systems for TextRenderer
    /// </summary>
    public enum CoordSystem {
        /// <summary>
        /// the location is expected to be specified into screen coords
        /// </summary>
        Screen, 
        /// <summary>
        /// the location is expected to be specified into world (3D) coords
        /// </summary>
        World3D
    }
    /// <summary>
    /// possible types of renderable items 
    /// </summary>
    public enum RenderItemType {
        /// <summary>
        /// the item defines a character 
        /// </summary>
        Character,
        /// <summary>
        /// the item defines a bitmap
        /// </summary>
        Bitmap
    }
    /// <summary>
    /// possible reason for an ILGraphCollectionChangedEvent to occur
    /// </summary>
    public enum GraphCollectionChangeReason {
        Added,
        Deleted,
        Changed
    }
    public class ILLayoutData {
        public ILLayoutData(ILCamera camera) {
            CameraPosition = camera; 
        }
        public ILCamera CameraPosition; 
        public ILLayoutData() {
        }
    }
}

namespace ILNumerics.Drawing.Labeling {
    /// <summary>
    /// simple single labeled tick
    /// </summary>
    public struct LabeledTick {
        /// <summary>
        /// tick label
        /// </summary>
        public readonly ILRenderQueue Queue; 
        /// <summary>
        /// tick position
        /// </summary>
        public readonly float Position; 
        /// <summary>
        /// create single labeled tick
        /// </summary>
        /// <param name="position">position</param>
        /// <param name="queue">render queue used to render the item</param>
        public LabeledTick(float position, ILRenderQueue queue) { 
            Position = position; 
            Queue    = queue; 
        }
    }
    

}
    
