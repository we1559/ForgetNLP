using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetNLP.MemorySDK;
namespace ForgetNLP.DictionarySDK
{
    public class DictionaryDAL
    {
        /// <summary>
        /// 计算当前关键词的成熟度
        /// </summary>
        /// <typeparam name="T">泛型，具体类别由调用者传入</typeparam>
        /// <param name="mdl">待计算的对象</param>
        /// <param name="dRemeberValue">记忆剩余量系数</param>
        /// <returns>当前成熟度</returns>
        /// <remarks>
        /// 1、成熟度这里用对象遗忘与增加的量的残差累和来表征；
        /// 2、已经累计的残差之和会随时间衰减；
        /// 3、公式的意思是： 成熟度 = 成熟度衰减剩余量 + 本次遗忘与增加量的残差的绝对值
        /// </remarks>
        public static double CalcValidDegree<T>(MemoryItemMDL<T> mdl, double dRemeberValue)
        {
            return mdl.ValidDegree * dRemeberValue + Math.Abs(1 - mdl.ValidCount * (1 - dRemeberValue));
        }
         
        /// <summary>
        /// 计算候选项记忆剩余量
        /// </summary>
        /// <typeparam name="T">泛型，具体类型由调用者传入</typeparam>
        /// <param name="key">候选项</param>
        /// <param name="objMemoryItemColl">候选项集合</param>
        /// <returns>返回记忆剩余量</returns>
        public static double CalcRemeberValue<T>(T key, MemoryItemColl<T> objMemoryItemColl)
        {
            if (!objMemoryItemColl.Contains(key)) return 0;
            MemoryItemMDL<T> mdl = objMemoryItemColl[key];
            double dRemeberValue = MemoryDAL.CalcRemeberValue(objMemoryItemColl.OffsetTotalCount - mdl.UpdateOffsetCount, objMemoryItemColl.MinuteOffsetSize);
            return mdl.ValidCount * dRemeberValue;
        }
        /// <summary>
        /// 计算邻键首项记忆剩余量
        /// </summary>
        /// <typeparam name="T">泛型，具体类别由调用者传入</typeparam>
        /// <param name="key">相邻两项的首项</param>
        /// <param name="objMemoryBondColl">邻键集合</param>
        /// <returns>返回记忆剩余量</returns>
        public static double CalcRemeberValue<T>(T key, MemoryBondColl<T> objMemoryBondColl)
        {
            if (!objMemoryBondColl.Contains(key)) return 0;
            MemoryBondMDL<T> objBondMDL = objMemoryBondColl[key];
            MemoryItemMDL<T> mdl = objBondMDL.KeyItem;
            double dRemeberValue = MemoryDAL.CalcRemeberValue(objMemoryBondColl.OffsetTotalCount - mdl.UpdateOffsetCount, objMemoryBondColl.MinuteOffsetSize);
            return mdl.ValidCount* dRemeberValue;
        }

        /// <summary>
        /// 计算邻键尾项记忆剩余量
        /// </summary>
        /// <typeparam name="T">泛型，具体类别由调用者传入</typeparam>
        /// <param name="keyHead">相邻两项的首项</param>
        /// <param name="keyTail">相邻两项的尾项</param>
        /// <param name="objMemoryBondColl">邻键集合</param>
        /// <returns>返回记忆剩余量</returns>
        public static double CalcRemeberValue<T>(T keyHead, T keyTail,MemoryBondColl<T> objMemoryBondColl)
        {
            if (!objMemoryBondColl.Contains(keyHead)) return 0;
            MemoryBondMDL<T> objBondMDL = objMemoryBondColl[keyHead];
            MemoryItemColl<T> objLinkColl = objBondMDL.LinkColl;
            return CalcRemeberValue<T>(keyTail, objLinkColl);
        }
        
        /// <summary>
        /// 判断键是否为有效关联键
        /// </summary>
        /// <typeparam name="T">泛型，具体类型由调用者传入</typeparam>
        /// <param name="keyHead">相邻键中首项</param>
        /// <param name="keyTail">相邻键中尾项</param>
        /// <param name="objMemoryBondColl">相邻字典</param>
        /// <returns>返回是否判断的结果：true、相邻项有关；false、相邻项无关</returns>
        /// <remarks>判断标准：共享键概率 > 单字概率之积 </remarks>
        public static bool IsBondValid<T>(T keyHead, T keyTail, MemoryBondColl<T> objMemoryBondColl )
        {
            //如果相邻项任何一个不在相邻字典中，则返回false 。
            if (!objMemoryBondColl.Contains(keyHead) || !objMemoryBondColl.Contains(keyTail)) return false;

            //分别获得相邻单项的频次
            double dHeadValidCount = CalcRemeberValue<T>(keyHead, objMemoryBondColl);
            double dTailValidCount = CalcRemeberValue<T>(keyTail, objMemoryBondColl);
            //获得相邻字典全库的总词频
            double dTotalValidCount = objMemoryBondColl.MinuteOffsetSize;
           
            if (dTotalValidCount <= 0) return false;

            //获得相邻项共现的频次
            MemoryItemColl<T> objLinkColl = objMemoryBondColl[keyHead].LinkColl;
            if (!objLinkColl.Contains(keyTail)) return false;
            double dShareValidCount = CalcRemeberValue<T>(keyTail, objLinkColl);

            //返回计算的结果
            return dShareValidCount / dHeadValidCount > dTailValidCount / dTotalValidCount;

        }

        /// <summary>
        /// 清理邻键集合，移除低于阈值的邻键
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objMemoryBondColl"></param>
        /// <param name="dMinValidValue"></param>
        public static void ClearMemoryBondColl<T>(MemoryBondColl<T> objMemoryBondColl, double dMinValidValue = 1.28)
        {
            for (int k = objMemoryBondColl.Count - 1; k >= 0; k--)
            {
                if (objMemoryBondColl[k].KeyItem.ValidCount < dMinValidValue)
                {
                    objMemoryBondColl.RemoveAt(k);
                }
                else
                {
                    ClearMemoryItemColl<T>(objMemoryBondColl[k].LinkColl, dMinValidValue);
                }
            }
        }

        /// <summary>
        /// 将相邻两项（邻键）添加到集合中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyHead"></param>
        /// <param name="keyTail"></param>
        /// <param name="objMemoryBondColl"></param>
        public static void UpdateMemoryBondColl<T>(T keyHead, T keyTail, MemoryBondColl<T> objMemoryBondColl)
        {
            if (!objMemoryBondColl.Contains(keyHead))
            {
                MemoryBondMDL<T> bond = new MemoryBondMDL<T>();
                bond.KeyItem.Key = keyHead;
                bond.LinkColl.OffsetTotalCount = 0;
                bond.LinkColl.MinuteOffsetSize = objMemoryBondColl.MinuteOffsetSize ;
                objMemoryBondColl.Add(bond);
            }

            MemoryBondMDL<T> objBondMDL = objMemoryBondColl[keyHead];


            MemoryItemMDL<T> mdl = objBondMDL.KeyItem;
            double dRemeberValue = MemoryDAL.CalcRemeberValue(objMemoryBondColl.OffsetTotalCount - mdl.UpdateOffsetCount, objMemoryBondColl.MinuteOffsetSize);
            mdl.TotalCount += 1;//累加总计数
            mdl.ValidDegree = CalcValidDegree<T>(mdl, dRemeberValue);//计算成熟度
            mdl.ValidCount = mdl.ValidCount * dRemeberValue + 1;// 遗忘累频=记忆保留量+1          
            mdl.UpdateOffsetCount = objMemoryBondColl.OffsetTotalCount;//更新时的偏移量

            MemoryItemColl<T> objLinkColl = objBondMDL.LinkColl;
            objLinkColl.OffsetTotalCount = objMemoryBondColl.OffsetTotalCount;
            UpdateMemoryItemColl(keyTail, objLinkColl);

           
            objMemoryBondColl.OffsetTotalCount += 1;
        }
        /// <summary>
        /// 清理集合，移除低于阈值的项
        /// </summary>
        /// <typeparam name="T">C#中的泛型，具体类型由调用者传入</typeparam>
        /// <param name="objMemoryItemColl">词库</param>
        /// <param name="dMinValidValue">阈值，默认值相当于至少1个记忆周期时间内，未曾再次出现</param>
        public static void ClearMemoryItemColl<T>(MemoryItemColl<T> objMemoryItemColl,double dMinValidValue=1.25)
        {
            
            for (int k = objMemoryItemColl.Count - 1; k >= 0; k--)
            {
                //此处使用最后一次的计数即可，无需计算当前剩余值
                //double dValidValue = CalcRemeberValue<T>(objMemoryItemColl[k].Key, objMemoryItemColl);
                //if (dValidValue < dMinVaildValue) objMemoryItemColl.RemoveAt(k);

                if (objMemoryItemColl[k].ValidCount < dMinValidValue) objMemoryItemColl.RemoveAt(k);
            }
        }

        /// <summary>
        /// 将候选项添加到词典中
        /// </summary>
        /// <typeparam name="T">C#中的泛型，具体类型由调用者传入</typeparam>
        /// <param name="keyItem">候选项</param>
        /// <param name="objMemoryItemColl">候选项词典</param>
        public static void UpdateMemoryItemColl<T>(T keyItem, MemoryItemColl<T> objMemoryItemColl)
        {
            
            if (!objMemoryItemColl.Contains(keyItem))
            {
                //如果词典中不存在该候选项

                //声明数据对象，用于存放候选项及其相关数据
                MemoryItemMDL<T> mdl = new MemoryItemMDL<T>();
                mdl.Key = keyItem;//候选项
                mdl.TotalCount = 1;//候选项出现的物理次数
                mdl.ValidCount = 1;//边遗忘边累加共同作用下的有效次数
                mdl.ValidDegree = 1;//该词的默认成熟度
                objMemoryItemColl.Add(mdl);//添加至词典中
            }
            else
            {
                //如果词典中已包含该候选项

                //从词典中取出该候选项
                MemoryItemMDL<T> mdl = objMemoryItemColl[keyItem];
                //计算从最后一次入库至现在这段时间剩余量系数
                double dRemeberValue =  MemoryDAL.CalcRemeberValue(objMemoryItemColl.OffsetTotalCount - mdl.UpdateOffsetCount, objMemoryItemColl.MinuteOffsetSize);
                mdl.TotalCount +=  1;//累加总计数                
                mdl.ValidDegree =  CalcValidDegree<T>(mdl, dRemeberValue);//计算成熟度
                mdl.ValidCount =mdl.ValidCount* dRemeberValue+ 1;// 遗忘累频=记忆保留量+1
                mdl.UpdateOffsetCount = objMemoryItemColl.OffsetTotalCount;//更新时的偏移量（相当于记录本次入库的时间）
            }

            objMemoryItemColl.OffsetTotalCount += 1;//处理过的数据总量（相当于一个全局的计时器）
        }
    }
}
