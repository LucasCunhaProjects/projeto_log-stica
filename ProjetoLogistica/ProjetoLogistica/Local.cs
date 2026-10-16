using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLogistica
{
    public class Local
    {
        public Item[] Features { get; set; }
    }

    public class Item
    {
        public Geo Geometry { get; set; }

    }

    public class Geo
    {
        public double[] Coordinates { get; set; }
    }

    public class Rota
    {
        public Caminho[] Routes { get; set; }
    }

    public class Caminho
    {
        public Resumo Summary { get; set; }
    }

    public class Resumo
    {
        public double Distance { get; set; }
    }
    
}
