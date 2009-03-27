#region LGPL License
/*    
    This file is part of ILNumerics.Net Core Module.

    ILNumerics.Net Core Module is free software: you can redistribute it 
    and/or modify it under the terms of the GNU Lesser General Public 
    License as published by the Free Software Foundation, either version 3
    of the License, or (at your option) any later version.

    ILNumerics.Net Core Module is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with ILNumerics.Net Core Module.  
    If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ILNumerics.BuiltInFunctions; 
using ILNumerics.Exceptions; 

namespace ILNumerics.Algorithms {
    /// <summary>
    /// linear discriminant analysis
    /// </summary>
    public class LDA : ILAlgorithm {
        /// <summary>
        /// defines hyperplane c by the formula: c = wx + b
        /// </summary>
        public struct Hyperplane {
            /// <summary>
            /// hyperplane vector
            /// </summary>
            public ILArray<double> w;
            /// <summary>
            /// offset for hyperplane
            /// </summary>
            public ILArray<double> b;
        }
        /// <summary>
        /// create new LDA algorithm
        /// </summary>
        public LDA () : base() {
            m_name = "LDA"; 
        }
        /// <summary>
        /// train the LDA 
        /// </summary>
        /// <param name="X">data</param>
        /// <param name="Labels">labels</param>
        /// <returns>linear hyperplane wich best discriminates both classes</returns>
        /// <remarks> gamma will be set to 0.0</remarks>
        public Hyperplane TrainLDA (ILArray<double> X, ILLogicalArray Labels) {
            return TrainLDA(X,Labels,0.0); 
        }

        /// <summary>
        /// linear discriminant analysis 
        /// </summary>
        /// <param name="X">data matrix. Must be of size d x n, having samples arranged in columns </param>
        /// <param name="Labels">class labels for <paramref name="X"/>. </param>
        /// <param name="gamma">RLDA regularization parameter, with values between 0 and 1. 
        /// GAMMA=0 gives normal LDA, GAMMA=1 uses a multiple of the identity matrix instead 
        /// of the pooled covariance matrix.</param>
        /// <returns>cell array with discriminant hyperplane description</returns>
        /// <remarks><para><c>Labels</c> can be a vector of length n, having positive/negative values at indices 
        /// corresponding to data X. Alternatively it is a 2 row matrix of length n with 1's in the first row at positions 
        /// of data in the dirst class and 1's in the second row labeling the data in the second class.</para>
        /// <para>References: <list><item>J.H. Friedman, Regularized Discriminant Analysis, Journal
        /// of the Americal Statistical Association, vol.84(405), 1989. The method implemented here 
        /// is Friedman's method with LAMDBA==1. </item>
        /// <item>The algorithm is base on implementation of Fraunhofer FIRST.IDA (2004)</item></list></para></remarks>    
        public Hyperplane TrainLDA(ILArray<double> X, ILLogicalArray Labels, double gamma) {
            base.Run(); // <- will set state to 'Running'
            if (gamma > 1.0 || gamma < 0) 
                throw new ILArgumentException("Regularization parameter gamma must be in range 0...1!"); 
            // if size(yTr,1) == 1 yTr = [yTr<0; yTr>0]; end
            if (Labels.IsVector)
                Labels = new ILLogicalArray( vertcat(Labels < 0.0, Labels > 0.0)); 
            //ind = find(sum(abs(xTr),1)==inf);
            //ILArray<double> ind = Find(sum(abs(X),1) == double.PositiveInfinity);   // <- he? what if negative infinity ? Hm.
            //// xTr(:,ind) = [];
            //X[null,ind] = null; 
            //// yTr(:,ind) = [];
            //Labels[null,ind] = null; 

            // nClasses= size(yTr,1);
            int nClasses = Labels.Dimensions[0]; 
            // clInd= cell(nClasses,1);
            ILCell clInd = new ILCell(nClasses,1); 
            //N= zeros(nClasses, 1);
            int[] N = new int [nClasses]; 
            int sumN = 0; 
            //for ci= 1:nClasses,
            for (int ci = 0; ci < nClasses; ci++) {
                //  clInd{ci} = find(yTr(ci,:));
                clInd[ci] = find(Labels[ci,null]); 
                //  N(ci)= length(clInd{ci});
                N[ci] = clInd[ci].Dimensions.Longest; 
                sumN += N[ci]; 
            }
            //priorP = ones(nClasses,1)/nClasses;   
            ILArray<double> priorP = ones(nClasses,1) / nClasses; 
            //d= size(xTr,1);
            int d = X.Dimensions[0]; 
            //m= zeros(d, nClasses);
            ILArray<double> m = zeros(d,nClasses); 
            //Sq= zeros(d, d);
            ILArray<double> Sq = zeros(d,d);
            //for ci= 1:nClasses,
            for (int ci = 0; ci < nClasses; ci++) {
                //  cli= clInd{ci};
                ILArray<double> cli = (ILArray<double>)clInd[ci];         
                //  m(:,ci)= mean(xTr(:,cli),2);
                m[null,ci] = mean(X[null,cli],1); 
                //  % gleichanteil löschen: 
                //  yc= xTr(:,cli) - m(:,ci) * ones(1,N(ci));
                ILArray<double> yc = X[null,cli] - repmat(m[null,ci],1,N[ci]); 
                //  % yc sind xTr Daten des ersten merkmals mit mean = 0
                //  Sq = Sq + yc*yc';
                Sq = Sq + multiply(yc,yc.T);
            }
            //Sq= Sq/(sum(N)-1);
            Sq = Sq / (sumN-1); 
            //Sq = (1-gamma)*Sq + gamma/d*trace(Sq)*eye(d);
            Sq = (1-gamma) * Sq + gamma/(double)d * sum(diag(Sq))*eye(d,d); 
            //Sq = pinv(Sq);
            Sq = pinv(Sq); 
            //C.w = Sq*m;
            ILArray<double> Cw = multiply(Sq,m); 
            ILArray<double> Cb = -0.5 * sum(m*Cw,0).T + log(priorP); 
            //if nClasses==2
            if (nClasses == 2) {
                //  C.w = C.w(:,2) - C.w(:,1);
                Cw = Cw[null,1] - Cw[null,0]; 
                //  C.b = C.b(2)-C.b(1);
                Cb = Cb[1] - Cb[0];
            }
            Hyperplane C; 
            C.w = Cw; 
            //C.b = -0.5*sum(m.*C.w,1)' + log(priorP);
            C.b = Cb; 
            SetState(ILAlgorithmState.Finished); 
            return C; 
        }
    }
}
