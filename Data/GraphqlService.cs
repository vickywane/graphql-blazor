using GraphQL.Client.Serializer.Newtonsoft;
using GraphQL;
using GraphQL.Client.Http;
using System.Threading.Tasks;

namespace graphql_blazor.Data
{
    public class GraphqlService
    {
       private readonly GraphQL.Client.Http.GraphQLHttpClient _graphqlClient =
            new GraphQLHttpClient("http://localhost:4000", new NewtonsoftJsonSerializer());

        private readonly GraphQLRequest _fetchCountriesQuery = new GraphQLRequest
        {
            Query = @"
            query FetchCountries {
                countries {
                    name
                    id
                    dateInserted
                    code
                    states {
                      id
                      name
                    }
                  }
            }
        ",
            OperationName = "FetchCountries"
        };

        public async Task<GraphQL.GraphQLResponse<graphql_blazor.Data.GraphqlData>> FetchCountries()
        {
            var fetchQuery = await _graphqlClient.SendQueryAsync<GraphqlData>(_fetchCountriesQuery);

            return fetchQuery;
        }

        public async Task InsertCountry(string countryName, string code)
        {
            var createCountryMutation = new GraphQLRequest
            {
                Query = @"            
                 mutation insertCountry($code : String, $countryName : String) {
                   CreateCountry(input: {
                       name: $countryName
                       code: $code
                     }) 
                    {
                      id
                      dateInserted
                      code
                      name
                     }
                 }
             ",
                OperationName = "insertCountry",
                Variables = new
                {
                    countryName,
                    code
                }
            };

            await _graphqlClient.SendMutationAsync<CreateCountry>(createCountryMutation);
        }
    }
}