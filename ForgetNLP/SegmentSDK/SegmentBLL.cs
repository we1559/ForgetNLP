using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForgetNLP.DictionarySDK;
using ForgetNLP.MemorySDK;
namespace ForgetNLP.SegmentSDK
{
    public class SegmentBLL
    {
        public static string ShowSegment(List<string> buffer)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string keyword in buffer)
            {
                sb.Append(String.Format("<{0}>",keyword));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 分词（同时自动维护词典）
        /// </summary>
        /// <param name="text">待分词文本</param>
        /// <param name="objCharBondColl">邻键集合（用于生成词库）</param>
        /// <param name="objKeyWordColl">词库</param>
        /// <param name="maxWordLen">最大词长（建议：细粒度为4、粗粒度为7）</param>
        /// <param name="bUpdateCharBondColl">是否同时更新邻键集合</param>
        /// <param name="bUpdateKeyWordColl">是否同时更新词库</param>
        /// <returns>返回分词结果</returns>
        public static List<string> Segment(string text, MemoryBondColl<string> objCharBondColl, MemoryItemColl<string> objKeyWordColl, int maxWordLen = 7, bool bUpdateCharBondColl = true, bool bUpdateKeyWordColl = true)
        {
            if (String.IsNullOrEmpty(text)) return new List<string>();
            if (maxWordLen == 0) maxWordLen = text.Length;

            //此处使用了个技巧：偶尔发现，词库在遗忘公式作用下，其总量也为相对稳定的固定值，且与MinuteOffsetSize相当。
            //故此处以此替换所有词的遗忘后的总词频，这样可以在处理流式数据时，避免动态计算词库总词频（因其计算量较大）。
            double dLogTotalCount = Math.Log(objKeyWordColl.MinuteOffsetSize, Math.E);

            if (bUpdateCharBondColl || bUpdateKeyWordColl)
            {
                WordDictBLL.UpdateKeyWordColl(text, objCharBondColl, objKeyWordColl, bUpdateCharBondColl, bUpdateKeyWordColl);
            }

            Dictionary<int, List<string>> objKeyWordBufferDict = new Dictionary<int, List<string>>();
            Dictionary<int, double> objKeyWordValueDict = new Dictionary<int, double>();

            for (int k = 0; k < text.Length; k++)
            {
                List<string> objKeyWordList = new List<string>();
                double dKeyWordValue = 0;

                for (int len = 0; len <= Math.Min(k, maxWordLen); len++)
                {
                    int startpos = k - len;
                    string keyword = text.Substring(startpos, len + 1);
                    if (len > 0 && !objKeyWordColl.Contains(keyword)) continue;
                    double dTempValue = 0;
                    if (objKeyWordColl.Contains(keyword))
                    {
                        dTempValue = -(dLogTotalCount - Math.Log(DictionaryDAL.CalcRemeberValue<string>(keyword, objKeyWordColl), Math.E));
                    }
                    if (objKeyWordValueDict.ContainsKey(startpos - 1))
                    {
                        dTempValue += objKeyWordValueDict[startpos - 1];
                        if (dKeyWordValue == 0 || dTempValue > dKeyWordValue)
                        {
                            dKeyWordValue = dTempValue;
                            objKeyWordList = new List<string>(objKeyWordBufferDict[startpos - 1]);
                            objKeyWordList.Add(keyword);
                        }
                    }
                    else
                    {
                        if (dKeyWordValue == 0 || dTempValue > dKeyWordValue)
                        {
                            dKeyWordValue = dTempValue;
                            objKeyWordList = new List<string>();
                            objKeyWordList.Add(keyword);
                        }
                    }

                }
                objKeyWordBufferDict.Add(k, objKeyWordList);
                objKeyWordValueDict.Add(k, dKeyWordValue);
            }

            return objKeyWordBufferDict[text.Length - 1];
        }
         
    }
}
