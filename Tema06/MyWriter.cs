using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tema06
{
    class MyWriter
    {
        private string filename;
        private List<string> list;

        public MyWriter(List<string> list, string filename)
        {
            this.list = list;
            this.filename = filename;
        }

        public void WriteAll()
        {
            try
            {
                using (StreamWriter sw = File.CreateText(filename))
                {
                    this.list.ForEach(line => sw.WriteLine(line.ToString()));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }        
    }
}
