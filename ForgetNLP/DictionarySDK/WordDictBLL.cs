using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ForgetNLP.DictionarySDK;
namespace ForgetNLP.SegmentSDK
{
    public class WordDictBLL
    {
         
 
       

        /// <summary>
        /// 从文本中生成候选词
        /// </summary>
        /// <param name="text">文本行</param>
        /// <param name="objCharBondColl">相邻字典</param>
        /// <param name="objKeyWordColl">词库</param>
        /// <param name="bUpdateCharBondColl">是否更新相邻字典</param>
        /// <param name="bUpdateKeyWordColl">是否更新词库</param>
        public static void UpdateKeyWordColl(string text, MemoryBondColl<string> objCharBondColl, MemoryItemColl<string> objKeyWordColl,  bool bUpdateCharBondColl = true, bool bUpdateKeyWordColl = true)
        {
            if (String.IsNullOrEmpty(text)) return;

            StringBuilder buffer = new StringBuilder();//用于存放连续的子串
            string keyHead = text[0].ToString(); //keyHead、keyTail分别存放相邻的两个字符
            buffer.Append(keyHead);
            for (int k = 1; k < text.Length; k++) //遍历句子中的每一个字符
            {
              
                //从句子中取一个字作为相邻两字的尾字
                string keyTail = text[k].ToString();
                if (bUpdateCharBondColl)
                {
                    //更新相邻字典
                    DictionaryDAL.UpdateMemoryBondColl<string>(keyHead, keyTail, objCharBondColl);
                }
                if (bUpdateKeyWordColl)
                {
                    //判断相邻两字是否有关
                    if (!DictionaryDAL.IsBondValid<string>(keyHead, keyTail, objCharBondColl ) )
                    {
                        //两字无关，则将绥中的字串取出，此即为候选词
                        string keyword = buffer.ToString();
                        //将候选词添加到词库中
                        DictionaryDAL.UpdateMemoryItemColl<string>(keyword, objKeyWordColl);
                        //清空缓冲
                        buffer.Clear();
                        //并开始下一个子串
                        buffer.Append(keyTail);
                    }
                    else
                    {
                        //两个字有关，则将当前字追加至串缓冲中
                        buffer.Append(keyTail);
                    }
                }
                //将当前的字作为相邻的首字
                keyHead = keyTail;
            }
        }

        /// <summary>
        /// 相邻字统计
        /// </summary>
        /// <param name="text">文本行</param>
        /// <param name="objCharBondColl">存放相邻结果的字典</param>
        /// <remarks>遍历句中相邻的字，将结果存放到字典中</remarks>
        public static void UpdateCharBondColl(string text, MemoryBondColl<string> objCharBondColl)
        {
            if (String.IsNullOrEmpty(text)) return;
            string keyHead = text[0].ToString();
            for (int k = 1; k < text.Length; k++)
            {               
                string keyTail = text[k].ToString();
                //存入相邻字典中
                DictionaryDAL.UpdateMemoryBondColl<string>(keyHead, keyTail, objCharBondColl);
                keyHead = keyTail;
            }
        }

         
        /// <summary>
        /// 按权重排序输出词库
        /// </summary>
        /// <param name="objMemoryItemColl">词库</param>
        /// <param name="nKeyWordTopCount">输出词的数量</param>  
        /// <param name="bOrderbyDesc">是否倒序</param>
        /// <param name="bIsOnlyWord">是否仅输出词</param>
        /// <returns>输出的结果</returns>
        public static string ShowKeyWordWeightColl(MemoryItemColl<string> objMemoryItemColl, int nKeyWordTopCount, bool bOrderbyDesc=true,  bool bIsOnlyWord = true)
        {
            double dTotalVaildDegree =  objMemoryItemColl.Sum(x => x.ValidDegree / x.ValidCount) / objMemoryItemColl.Count ;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("词库成熟度：{0}% ；",dTotalVaildDegree>1?0:Math.Round((1-dTotalVaildDegree)*100,2)));          
            sb.AppendLine("----------------------------------------");
            sb.AppendLine(String.Format(" 【{0}】 | {1} | {2} | {3} | {4}", "主词", "遗忘词频", "累计词频", "词权值","成熟度(%)"));

            IOrderedEnumerable<MemoryItemMDL<string>> tbuffer = null;
            if (bOrderbyDesc)
            {
                tbuffer = from x in objMemoryItemColl
                          //如果只显示词，则要求：长度大于1、不包含符号、不是纯数字
                          where !bIsOnlyWord || x.Key.Length > 1 && !Regex.IsMatch(x.Key, @"[\p{P}\s]") && !Regex.IsMatch(x.Key,@"^\d+$") //&& !Regex.IsMatch(x.Key, @"^[a-zA-Z\p{P}\d\s=]+$")
                          //按权重排序
                          orderby x.ValidCount <= 0 ? 0 : (x.ValidCount) * (Math.Log(objMemoryItemColl.MinuteOffsetSize) - Math.Log(x.ValidCount)) descending
                          select x;
            }
            else
            {
                tbuffer = from x in objMemoryItemColl
                          //如果只显示词，则要求：长度大于1、不包含符号、不是纯数字
                          where !bIsOnlyWord || x.Key.Length > 1 && !Regex.IsMatch(x.Key, @"[\p{P}\s]") && !Regex.IsMatch(x.Key, @"^\d+$") //&& !Regex.IsMatch(x.Key, @"^[a-zA-Z\p{P}\d\s=]+$")
                          //按权重排序
                          orderby x.ValidCount <= 0 ? 0 : (x.ValidCount) * (Math.Log(objMemoryItemColl.MinuteOffsetSize) - Math.Log(x.ValidCount)) ascending
                          select x;
            }
            var buffer =   (tbuffer).Take(nKeyWordTopCount) ;
            sb.AppendLine(String.Format(" =========== 共{0} 个 ============= ", tbuffer.Count()));
            //逐词输出，每个词一行
            foreach (var x in buffer)
            {
                sb.AppendLine(String.Format(" 【{0}】 | {1} | {2} | {3} | {4}",
                    x.Key,
                    Math.Round(DictionaryDAL.CalcRemeberValue<string>(x.Key, objMemoryItemColl), 2),
                    x.TotalCount,
                    Math.Round((x.ValidCount <= 0 ? 0 : (x.ValidCount) * (Math.Log(objMemoryItemColl.MinuteOffsetSize) - Math.Log(x.ValidCount))), 4),
                    x.ValidCount<=1?0: x.ValidDegree / x.ValidCount > 1 ? 0 : Math.Round((1 - x.ValidDegree / x.ValidCount) * 100, 2)));
            }
            return sb.ToString();
        }
   
    }
}
