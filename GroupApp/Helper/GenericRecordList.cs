using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupApp.Helper
{
    public class GenericRecordList<T>
    {
        public List<T> RecordList { get; set; }
        public int TotalRecords { get; set; }
        public GenericRecordList()
        {
            RecordList = new List<T>();
        }
    }
}
