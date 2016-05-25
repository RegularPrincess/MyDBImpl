using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDBImpl.Repository
{
    class Table
    {
        public Table()
        {
            columns = new List<string>();
        }

        public Table(string name, string fullNameInFS)
        {
            this.name = name;
            this.fullNameInFS = fullNameInFS;
            columns = new List<string>();
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string fullNameInFS;
        public string FullNameInFS
        {
            get { return fullNameInFS; }
            set { fullNameInFS = value; }
        }

        private List<string> columns;
        public void addColumn(string column) {
            columns.Add(column);
        }
        public string getColumn(int index)
        {
            return columns.ElementAt(index);
        }
    }
}
