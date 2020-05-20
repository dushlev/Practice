using System;
using System.IO;

namespace task1
{
    class FormatExpression
    {
        string result = null;
        string str = null;
        int count = 0;
        int[] numArr; // = { -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20 };                  
        public string FormatStr()
        {
            try
            {
                str = File.ReadAllText(@"file.txt");
                string[] strArr = str.Split(',');
                numArr = new int[strArr.Length];

                for (int i = 0, j = strArr.Length; i < j; i++)
                {
                    numArr[i] = Int32.Parse(strArr[i]);

                }



                for (int i = 0, j = numArr.Length; i < j; i++)
                {
                    if (i + 1 != j)
                    {
                        if (numArr[i] + 1 != numArr[i + 1])
                        {
                            if (count == 0) { result += numArr[i].ToString() + ','; }
                            if (count == 1) { result += numArr[i - 1].ToString() + ',' + numArr[i].ToString() + ','; }
                            if (count > 1) { result += numArr[i - count].ToString() + '-' + numArr[i].ToString() + ','; }
                            count = 0;
                        }
                        else ++count;
                    }
                    else
                    {
                        if (count == 0) { result += numArr[i].ToString(); }
                        if (count == 1) { result += numArr[i - 1].ToString() + ',' + numArr[i].ToString(); }
                        if (count > 1) { result += numArr[i - count].ToString() + '-' + numArr[i].ToString(); }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

    }
}