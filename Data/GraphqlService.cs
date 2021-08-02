using System;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQL;

using GraphQL.Client.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace graphql_blazor.Data
{
    public class GraphqlService
    {
       private readonly GraphQLRequest _fetchCountriesQuery = new GraphQLRequest
        {
            Query = @"
            query FetchCountries {
              continents {
                name
                countries {
                  name
                }
              }
            }
        ",
            OperationName = "FetchCountries"
        };
        
        public async void FetchCountries()
        {
            var graphqlClient = new GraphQLHttpClient("https://countries.trevorblades.com/", new NewtonsoftJsonSerializer());
            var fetchQuery = await graphqlClient.SendQueryAsync<GraphqlData>(_fetchCountriesQuery);
            Console.WriteLine(fetchQuery);

            // return new[] { };
        } 
    }
}