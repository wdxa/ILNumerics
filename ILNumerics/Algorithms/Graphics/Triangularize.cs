using System;
using System.Collections.Generic;
using System.Text;

namespace ILNumerics.Algorithms {
    public partial class Graphic {

        /// <summary>
        /// increase the number of triangles by doubling existing triangles
        /// </summary>
        /// <param name="vertices">vertices</param>
        /// <param name="triangles">triangle index definitions</param>
        /// <param name="iterations">number of iterations, each iteration will make 4 triangles out of each triangle</param>
        /// <param name="outVertices">output, vertices.</param>
        /// <param name="outTriangles">output, triangles</param>
        /// <remarks><para>Incoming triangles are expected not to be degenerated. This means:
        /// Every edge is used only twice at most. No triangle shares more than 2
        /// corners with some other triangle. </para>
        /// 	<para>None of the incoming arrays will get altered</para></remarks>
        public static void Triangularize(ILArray<float> vertices, ILArray<int> triangles,
                                        int iterations,
                                        out ILArray<float> outVertices,
                                        out ILArray<int> outTriangles) {
            int numVertices = vertices.Dimensions[1];
            int numTriangles = triangles.Dimensions[1];
            outVertices = vertices.C;
            outTriangles = triangles.C;
            // beeing pessimistic: expect to create a larger number of vertices than probable
            outVertices[0, numVertices * 2] = 0;
            outTriangles[0, numTriangles * 2] = 0;

            int triIndLast = numTriangles;
            int vertIndLast = numVertices;
            for (int it = 0; it < iterations; it++) {
                int triIndItEnd = triIndLast;

                for (int triInd = 0; triInd < triIndItEnd; triInd++) {
                    int vertInd0 = outTriangles.GetValue(0, triInd);
                    int vertInd1 = outTriangles.GetValue(1, triInd);
                    int vertInd2 = outTriangles.GetValue(2, triInd);
                    // create new vertices
                    float v0x = (outVertices.GetValue(0, vertInd0) + outVertices.GetValue(0, vertInd1)) / 2f;
                    float v0y = (outVertices.GetValue(1, vertInd0) + outVertices.GetValue(1, vertInd1)) / 2f;
                    float v0z = (outVertices.GetValue(2, vertInd0) + outVertices.GetValue(2, vertInd1)) / 2f;
                    float v1x = (outVertices.GetValue(0, vertInd1) + outVertices.GetValue(0, vertInd2)) / 2f;
                    float v1y = (outVertices.GetValue(1, vertInd1) + outVertices.GetValue(1, vertInd2)) / 2f;
                    float v1z = (outVertices.GetValue(2, vertInd1) + outVertices.GetValue(2, vertInd2)) / 2f;
                    float v2x = (outVertices.GetValue(0, vertInd2) + outVertices.GetValue(0, vertInd0)) / 2f;
                    float v2y = (outVertices.GetValue(1, vertInd2) + outVertices.GetValue(1, vertInd0)) / 2f;
                    float v2z = (outVertices.GetValue(2, vertInd2) + outVertices.GetValue(2, vertInd0)) / 2f;
                    #region new vertex exists already? TODO: This needs to be replaced with a b-tree implementation!!
                    int newVertID0 = -1;
                    int newVertID1 = -1;
                    int newVertID2 = -1;
                    for (int vi = 0; vi < vertIndLast; vi++) {
                        float tmpX = outVertices.GetValue(0, vi);
                        float tmpY = outVertices.GetValue(1, vi);
                        float tmpZ = outVertices.GetValue(2, vi);
                        if (tmpX == v0x && tmpY == v0y && tmpZ == v0z) {
                            newVertID0 = vi;
                        }
                        if (tmpX == v1x && tmpY == v1y && tmpZ == v1z) {
                            newVertID1 = vi;
                        }
                        if (tmpX == v2x && tmpY == v2y && tmpZ == v2z) {
                            newVertID2 = vi;
                        }
                        if (newVertID0 >= 0 && newVertID1 >= 0 && newVertID2 >= 0)
                            break;
                    }
                    #endregion

                    if (newVertID0 < 0) {
                        newVertID0 = vertIndLast++;
                        outVertices[0, newVertID0] = v0x;
                        outVertices[1, newVertID0] = v0y;
                        outVertices[2, newVertID0] = v0z;
                    }
                    if (newVertID1 < 0) {
                        newVertID1 = vertIndLast++;
                        outVertices[0, newVertID1] = v1x;
                        outVertices[1, newVertID1] = v1y;
                        outVertices[2, newVertID1] = v1z;
                    }
                    if (newVertID2 < 0) {
                        newVertID2 = vertIndLast++;
                        outVertices[0, newVertID2] = v2x;
                        outVertices[1, newVertID2] = v2y;
                        outVertices[2, newVertID2] = v2z;
                    }

                    // create new triangles 
                    outTriangles.SetValue(newVertID0, 1, triInd);
                    outTriangles.SetValue(newVertID2, 2, triInd);

                    outTriangles.SetValue(newVertID2, 0, triIndLast);
                    outTriangles.SetValue(newVertID1, 1, triIndLast);
                    outTriangles.SetValue(vertInd2, 2, triIndLast++);

                    outTriangles.SetValue(newVertID2, 0, triIndLast);
                    outTriangles.SetValue(newVertID0, 1, triIndLast);
                    outTriangles.SetValue(newVertID1, 2, triIndLast++);

                    outTriangles.SetValue(newVertID0, 0, triIndLast);
                    outTriangles.SetValue(vertInd1, 1, triIndLast);
                    outTriangles.SetValue(newVertID1, 2, triIndLast++);
                }

            }
            outVertices = outVertices[":;0:" + (vertIndLast - 1)];
            outTriangles = outTriangles[":;0:" + (triIndLast - 1)];
        }
    }
}
