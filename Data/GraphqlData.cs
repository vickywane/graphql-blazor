using System.Collections.Generic;

namespace graphql_blazor.Data
{
    public class CreateCountry
    {
        public int id { get; set; }
        public string name { get; set; }
        public string dateInserted { get; set; }
        public string code { get; set; }
    } 

    public class GraphqlData
    {
        public List<Countries> countries { get; set; }
    }

    public class Countries
    { 
        public string name { get; set; }
        public int id { get; set; }
        public string dateInserted { get; set; }
        public int code { get; set; }

        public List<State> states { get; set; }
    }

    public class State
    {
        public int id { get; set; }

        public string name { get; set; }
    }
}