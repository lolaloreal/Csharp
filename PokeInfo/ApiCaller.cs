using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
 
namespace PokeInfo
{
    public class WebRequest
    {
        // The second parameter is a function that returns a Dictionary of string keys to object values.
        // If an API returned an array as its top level collection the parameter type would be "Action>"
        public static async Task GetPokemonDataAsync(int PokeId, Action<Pokemon> Callback)
        {
            // Create a temporary HttpClient connection.
            using (var Client = new HttpClient())
            {
                try
                {
                    Client.BaseAddress = new Uri($"http://pokeapi.co/api/v2/pokemon/{PokeId}");
                    HttpResponseMessage Response = await Client.GetAsync(""); // Make the actual API call.
                    Response.EnsureSuccessStatusCode(); // Throw error if not successful.
                    string StringResponse = await Response.Content.ReadAsStringAsync(); 

                    
                    JObject PokemonInfo = JsonConvert.DeserializeObject<JObject>(StringResponse);

                    JArray TypeList = PokemonInfo["types"].Value<JArray>();
                    List<string> Types = new List<string>();

                    foreach (JObject TypeObject in TypeList)
                    {
                        Types.Add(TypeObject["type"]["name"].Value<string>());
                    }

                    Pokemon thePokemon = new Pokemon 
                        {
                            Name = PokemonInfo["name"].Value<string>(),
                            Types = Types,
                            Height = PokemonInfo["height"].Value<long>(),
                            Weight = PokemonInfo["weight"].Value<long>()
                        };
                     
                    // Finally, execute our callback, passing it the response we got.
                    Callback(thePokemon);
                }
                catch (HttpRequestException e)
                {
                    // If something went wrong, display the error.
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
        }
    }
}