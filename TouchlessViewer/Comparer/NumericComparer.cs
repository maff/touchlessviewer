using System;
using System.Collections;

namespace TouchlessViewer
{
    /// <summary>
    /// Source: http://www.codeproject.com/KB/recipes/csnsort.aspx
    /// </summary>
    public class NumericComparer : IComparer
    {
        public NumericComparer()
        {
            //Selbes Phänomen, leere Funktion?!
        }

        public int Compare(object x, object y)
        {
            if ((x is string) && (y is string))
            {
                return StringLogicalComparer.Compare((string)x, (string)y);
            }

            return -1;
        }
    }
}
