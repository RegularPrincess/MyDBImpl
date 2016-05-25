using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDBImpl.Repository
{
    class MyDB : ICrud
    {
        const string NT_SEP = "#";
        const string NC_SEP = "&";
        const string END = ";";

        private string nameDB;
        public string NameDB
        {
            get { return nameDB; }
        }

        private string locationInFS;
        public string LocationInFS
        {
            get { return locationInFS; }
        }

        private List<Table> tables;

        bool ICrud.createDB(string pathInFS, string NameDB)
        {
            locationInFS = System.IO.Path.Combine(pathInFS, NameDB);
            System.IO.Directory.CreateDirectory(locationInFS);
            return true;
        }

        public bool createTable(string nameTable, List<string> columns)
        {
            Table table = new Table();
            table.Name = nameTable;
            nameTable += NT_SEP + columns.ElementAt(0);
            for(int i = 1; i < columns.Count; i++)
            {
                table.addColumn(columns.ElementAt(i));
                nameTable += NC_SEP;
                nameTable += columns.ElementAt(i);
            }
            nameTable += END;
            table.FullNameInFS = nameTable;
            tables.Add(table);
            

            string pathTable = System.IO.Path.Combine(locationInFS, nameTable);
            System.IO.Directory.CreateDirectory(pathTable);
            return true;
        }

        public bool addRow(string nameTable, Dictionary<string, string> columnAndValue)
        {
            Table table = getTableByName(nameTable);
            string row = "";
            row += columnAndValue[table.getColumn(0)];
            for(int i = 1; i < columnAndValue.Count; i++)
            {
                row += NC_SEP;
                row += columnAndValue[table.getColumn(i)];
            }
            row += END;
            locationInFS = System.IO.Path.Combine(table.FullNameInFS, row);
            System.IO.Directory.CreateDirectory(locationInFS);
            return true;
        }

        private Table getTableByName(string name)
        {
            foreach(Table table in tables)
            {
                if (table.Name == name)
                    return table;
            }
            return null;
        }
    }
}
