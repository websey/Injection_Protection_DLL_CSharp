using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InjectionProtector
{
    /// <summary>
    /// This Class allows you to check for any 
    /// Sql or Javascript injection 
    /// and when caught sets a boolean value and then
    /// returns it.
    /// 
    /// You can then decide how to handle the input
    /// when caught
    /// </summary>

    public class InputParser
    {
        #region ParserConstructor (empty)
        /// <summary>
        /// This constructor takes no arguments
        /// </summary>
        public InputParser()
        {

        }
        #endregion

        #region ParserConstructor
        /// <summary>
        /// This is the main constructor, it takes a string
        /// and then evaluates if they are clean
        /// </summary>
        /// <param name="feed">user entered string</param>
        public InputParser(string feed)
        {
            checkJS(feed);
            checkSql(feed);
        }
        #endregion

        #region sqlBlackList
        public static string[] sqlBlackList = {"--",";--",";","/*","*/","@@","@",
                                        "char","nchar","varchar","nvarchar",
                                        "alter","begin","cast","create","cursor","declare","delete","drop","end","exec","execute",
                                        "fetch","insert","kill","open",
                                        "select", "sys","sysobjects","syscolumns",
                                        "table","update"
                                       };
        #endregion

        #region jsBlackList
        public static string[] jsBlackList = {"<",">",";","script*","*/","@@","@",
                                        "char","=","confirm","alert",
                                        "var","foreach","cast","create","cursor"
                                       };
        #endregion

        #region CheckSQL
        public bool checkSql(string feed)
        {
            bool sqlError = false; ;

            foreach (string s in sqlBlackList)
            {
                if (s.Contains(feed))
                {
                    sqlError = true;
                }
                else
                {
                    sqlError = false;
                }
            }

            return sqlError;
        }
        #endregion

        #region CheckJavascript
        public bool checkJS(string feed)
        {
            bool jsError = false;

            foreach (string j in sqlBlackList)
            {
                if (j.Contains(feed))
                {
                    jsError = true;
                }
                else
                {
                    jsError = false;
                }
            }

            return jsError;
        }
        #endregion
    }
}
