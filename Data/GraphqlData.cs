using System.Collections.Generic;

namespace graphql_blazor.Data
{
    public class GraphqlData
    {
        List<Continents> continents { get; set; }
    }

    class Continents
    {
        public string name { get; set; }
        public List<Countries> countries { get; set; }
    }

    class Countries
    {
        public string name { get; set; }
    }
}