using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDBImpl.Repository
{
    interface ICrud
    {
        bool createDB(string pathInFS, string nameDB);
        bool createTable(string nameTable, List<string> columns);
        bool addRow(string nameTable, Dictionary<string, string> columnAndValue);
        
    }
}
