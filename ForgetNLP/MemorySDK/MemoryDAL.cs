using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForgetNLP.MemorySDK
{
    /// <summary>
    /// 遗忘算法（牛顿冷却定律）
    /// </summary>

    public class MemoryDAL
    {
        #region 牛顿冷却

        /// <summary>
        /// 牛顿冷却公式
        /// </summary>
        /// <param name="parameter">冷却系数</param>
        /// <param name="interval">时间间隔</param>        
        /// <returns></returns>
        /// <remarks>
        /// 建议遗忘系数：-Math.Log(0.254, Math.E) / (6天 * 24小时 * 60分钟 *60秒 *7每秒阅读字数);  
        /// </remarks>
        public static double CalcNetonCooling(double parameter, double interval)
        {
            return Math.Exp(-1 * parameter * interval);
        }


        #endregion

        #region 遗忘公式（调用牛顿冷却）

        /// <summary>
        /// 以偏移量模拟时间流逝的遗忘公式
        /// </summary>
        /// <param name="dOffsetCount">偏移量</param>
        /// <param name="dMinuteOffsetSize">单个周期容量，建议值为：6天 * 24小时 * 60分钟 *60秒 *7每秒阅读字数</param>
        /// <returns>返回记忆剩余量</returns>
        /// <remarks>
        /// 此处第二个参数没有使用，原因是已经将相关计算合并进遗忘系数中，此处保留为兼容代码。
        /// 使用艾宾浩斯曲线计算系数时是以分钟为单位，此处的系数已经转换为按字符计时，故无需再将字符转时间。
        /// </remarks>
        public static double CalcRemeberValue(double dOffsetCount, double dMinuteOffsetSize)
        {
            double parameter = -Math.Log(0.254, Math.E) / (6 * 24 * 60 * 60 * 7);
            return CalcNetonCooling(parameter, dOffsetCount);           
        }

        #endregion


    }
}
