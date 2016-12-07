using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgetNLP.MemorySDK
{
    [Serializable]
    public class MemoryMDL
    {
        private double _ValidCount = 0;
        /// <summary>
        /// 遗忘累频
        /// </summary>
        public double ValidCount
        {
            get { return _ValidCount; }
            set { _ValidCount = value; }
        }
        private double _TotalCount = 0;
        /// <summary>
        /// 累计次数
        /// </summary>
        public double TotalCount
        {
            get { return _TotalCount; }
            set { _TotalCount = value; }
        }

        private double _UpdateOffsetCount = 0;
        /// <summary>
        /// 最后一次更新时的系统总偏移量（用于模拟计时）
        /// </summary>
        public double UpdateOffsetCount
        {
            get { return _UpdateOffsetCount; }
            set { _UpdateOffsetCount = value; }
        }
         
        private double _ValidDegree = 1;
        /// <summary>
        /// 有效程度（成熟度）
        /// </summary>
        /// <remarks>成熟度的物理含义：成熟的标志是遗忘的量与出现的量基本一致 </remarks>
        public double ValidDegree
        {
            get { return _ValidDegree; }
            set { _ValidDegree = value; }
        }
    }
}
