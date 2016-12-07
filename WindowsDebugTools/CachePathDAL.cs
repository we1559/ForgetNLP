using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace WindowsDebugTools
{
    /// <summary>
    /// 缓存目录的相关操作
    /// </summary>
    
    public class CachePathDAL
    {
        public static string ClearFileName(string sFileName)
        {
            char[] objCharList = Path.GetInvalidFileNameChars();
            IEnumerable<char> objInvaildCharColl = from ch in objCharList
                                                   where sFileName.Contains(ch)
                                                   select ch;
            string sClearFileName = String.Empty;
            if (objInvaildCharColl != null && objInvaildCharColl.Count() > 0)
            {
                foreach (char ch in objInvaildCharColl)
                {
                    sClearFileName = sClearFileName.Replace(ch, '_');
                }
         
            }
            return sClearFileName;
        }
        /// <summary>
        /// 获得默认的缓存目录。
        /// </summary>
        /// <returns></returns>
        public static string GetCachePath()
        {
            return GetCachePath(String.Empty, String.Empty);
        }
        /// <summary>
        /// 获取缓存目录。
        /// </summary>
        /// <param name="sWorkSpacePath"></param>
        /// <returns></returns>
        public static string GetCachePath(string sWorkSpacePath)
        {
            return GetCachePath(sWorkSpacePath, String.Empty);
        }
        /// <summary>
        /// 获取缓存目录特定分组的目录
        /// </summary>
        /// <param name="sWorkSpacePath"></param>
        /// <param name="sCoreWordLine"></param>
        /// <returns></returns>
        public static string GetCachePath(string sWorkSpacePath, string sCoreWordLine)
        {
            StringBuilder sb = new StringBuilder();
            if (String.IsNullOrEmpty(sWorkSpacePath))
            {
                sWorkSpacePath = GetWorkSpacePath();
            }
            sb.Append(String.Format(@"{0}\", sWorkSpacePath));
            sb.Append(String.Format(@"{0}\", "Cache"));
            if (!String.IsNullOrEmpty(sCoreWordLine))
            {
                sb.Append(String.Format(@"{0}\", sCoreWordLine));
            }
            
 
            string sFloderPath = sb.ToString();
            if (!Directory.Exists(sFloderPath))
            {
                Directory.CreateDirectory(sFloderPath);
            }
            return sFloderPath;
        }
         /// <summary>
         /// 获取文章存放路径
         /// </summary>
         /// <param name="sWorkSpacePath"></param>
         /// <param name="sGroupName"></param>
         /// <param name="sChapterStyle"></param>
         /// <returns></returns>
        public static string GetChapterPath(string sWorkSpacePath, string sGroupName, string sChapterStyle)
        {
            StringBuilder sb = new StringBuilder();
            if (String.IsNullOrEmpty(sWorkSpacePath))
            {
                sWorkSpacePath = GetWorkSpacePath();
            }
            sb.Append(String.Format(@"{0}\", sWorkSpacePath));
            sb.Append(String.Format(@"{0}\", "Chapter"));
            if (String.IsNullOrEmpty(sGroupName))
            {
                sGroupName = "GroupName";
            }
            sb.Append(String.Format(@"{0}\", sGroupName));
           
            if (String.IsNullOrEmpty(sChapterStyle))
            {
                sChapterStyle = "ChapterMode";
            }
            sb.Append(String.Format(@"{0}\", sChapterStyle));

            string sFloderPath = sb.ToString();
            if (!Directory.Exists(sFloderPath))
            {
                Directory.CreateDirectory(sFloderPath);
            }
            return sFloderPath;
        }
        /// <summary>
        /// 获得生成文章的默认目录
        /// </summary>
        /// <returns></returns>
        public static string GetChapterPath()
        {
            return GetChapterPath(String.Empty);
        }
         
        /// <summary>
        /// 获得生成文章的目录
        /// </summary>
        /// <param name="sWorkSpacePath"></param>
        /// <returns></returns>
        public static string GetChapterPath( string sWorkSpacePath)
        {
            if (String.IsNullOrEmpty(sWorkSpacePath))
            {
                sWorkSpacePath = GetWorkSpacePath();
            }
            string sDictPath = Path.GetFullPath(String.Format(@"{0}\{1}", sWorkSpacePath, "Chapter" ));
            if (!Directory.Exists(sDictPath)) Directory.CreateDirectory(sDictPath);
            return sDictPath;
        }

        /// <summary>
        /// 获得 CharIndex.Coll 文件路径
        /// </summary>
        /// <param name="sWorkSpacePath"></param>
        /// <returns></returns>
        public static string GetCharIndexPathFile(string sWorkSpacePath)
        {

            string sMemoryPath = GetMemoryPath(sWorkSpacePath);

            string sDictPath = Path.GetFullPath(String.Format(@"{0}\{1}", sMemoryPath, "CharIndex.Coll"));
            return sDictPath;
        }
        /// <summary>
        /// 获得默认 CharIndex.Coll 文件路径
        /// </summary>
        /// <returns></returns>
        public static string GetCharIndexPathFile()
        {
            return GetCharIndexPathFile(String.Empty);
        }
        /// <summary>
        /// 获得 WordIndex.Coll 文件路径
        /// </summary>
        /// <param name="sWorkSpacePath"></param>
        /// <returns></returns>
        public static string GetWordIndexPathFile(string sWorkSpacePath)
        {
            string sMemoryPath = GetMemoryPath(sWorkSpacePath);

            string sDictPath = Path.GetFullPath(String.Format(@"{0}\{1}", sMemoryPath, "WordIndex.Coll"));
            return sDictPath;
        }
        /// <summary>
        /// 获得默认 WordIndex.Coll 文件路径
        /// </summary>
        /// <returns></returns>
        public static string GetWordIndexPathFile()
        {
            return GetWordIndexPathFile(String.Empty);
        }


        /// <summary>
        /// 获得默认Memory目录 
        /// </summary>
        /// <returns></returns>
        public static string GetMemoryPath()
        {
            return GetMemoryPath(String.Empty);
        }
        /// <summary>
        /// 获得Memory目录 
        /// </summary>
        /// <param name="sWorkSpacePath"></param>
        /// <returns></returns>
        public static string GetMemoryPath(string sWorkSpacePath)
        {
            if (String.IsNullOrEmpty(sWorkSpacePath))
            {
                sWorkSpacePath = GetWorkSpacePath();
            }
            string sDictPath = Path.GetFullPath(String.Format(@"{0}\{1}", sWorkSpacePath, "Memory"));
            if (!Directory.Exists(sDictPath)) Directory.CreateDirectory(sDictPath);
            return sDictPath;
        }
         
        /// <summary>
        /// 获得默认工作目录
        /// </summary>
        /// <returns></returns>
        public static string GetWorkSpacePath()
        {
            return GetWorkSpacePath(String.Empty);
        }
        /// <summary>
        /// 获得工作目录
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static string GetWorkSpacePath(string root)
        {
            if (!String.IsNullOrEmpty(root))
            {
                string sRootPath = Path.GetFullPath(root);
                if (Directory.Exists(sRootPath))
                {
                    return sRootPath;
                }
            }
            string sExecPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string sDictPath = Path.GetFullPath(String.Format(@"{0}\{1}", sExecPath, "WorkSpace"));
            if (!Directory.Exists(sDictPath)) Directory.CreateDirectory(sDictPath);
            return sDictPath;
        }

        /// <summary>
        /// 获取全路径文件名称
        /// </summary>
        /// <param name="sFileName"></param>
        /// <returns></returns>
        public static string GetPathFullName(string sFileName)
        {
            string sExecPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string sDictPath = Path.GetFullPath(String.Format(@"{0}\{1}", sExecPath, "Data"));
            if (!Directory.Exists(sDictPath)) Directory.CreateDirectory(sDictPath);
            return Path.GetFullPath(String.Format(@"{0}\{1}", sDictPath, sFileName));
        }
    }
}
