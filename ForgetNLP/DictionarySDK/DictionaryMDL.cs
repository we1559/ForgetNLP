using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using ForgetNLP.MemorySDK;
namespace ForgetNLP.DictionarySDK
{

    [Serializable]
    public class MemoryBondMDL<T>
    {
        private MemoryItemMDL<T> _KeyItem = new MemoryItemMDL<T>();
        /// <summary>
        /// 主项
        /// </summary>
        public MemoryItemMDL<T> KeyItem
        {
            get { return _KeyItem; }
            set { _KeyItem = value; }
        }

        private MemoryItemColl<T> _LinkColl = new MemoryItemColl<T>();
        /// <summary>
        /// 关联项集合
        /// </summary>
        public MemoryItemColl<T> LinkColl
        {
            get { return _LinkColl; }
            set { _LinkColl = value; }
        }
    }

    [Serializable]
    public class MemoryBondColl<T> : KeyedCollection<T, MemoryBondMDL<T>>
    {
        private double _OffsetTotalCount = 0;
        /// <summary>
        /// 偏移总量
        /// </summary>
        public double OffsetTotalCount
        {
            get { return _OffsetTotalCount; }
            set { _OffsetTotalCount = value; }
        }

        private double _MinuteOffsetSize = 7/*每秒7个字符*/ * 60 * 60 * 24 /*一天*/ * 6; //最大记忆容量
        /// <summary>
        /// 每分钟偏移量
        /// </summary>
        public double MinuteOffsetSize
        {
            get { return _MinuteOffsetSize; }
            set { _MinuteOffsetSize = value; }
        }


        protected override T GetKeyForItem(MemoryBondMDL<T> item)
        {
            return item.KeyItem.Key;
        }
    }

    [Serializable]
    public class MemoryItemMDL<T>:MemoryMDL
    {
        private T _Key = default(T);
        /// <summary>
        /// 记忆单元主体项
        /// </summary>
        public T Key
        {
            get { return _Key; }
            set { _Key = value; }
        }
      
    }
     
    [Serializable]
    public class MemoryItemColl<T> : KeyedCollection<T, MemoryItemMDL<T>>
    {
        private double _OffsetTotalCount = 0;
        /// <summary>
        /// 偏移总量
        /// </summary>
        public double OffsetTotalCount
        {
            get { return _OffsetTotalCount; }
            set { _OffsetTotalCount = value; }
        }

        private double _MinuteOffsetSize = 7/*每秒7个字符*/ * 60 * 60 * 24 /*一天*/ * 6; //最大记忆容量
        /// <summary>
        /// 每分钟偏移量
        /// </summary>
        public double MinuteOffsetSize
        {
            get { return _MinuteOffsetSize; }
            set { _MinuteOffsetSize = value; }
        }

        protected override T GetKeyForItem(MemoryItemMDL<T> item)
        {
            return item.Key;
        }
    }
}
