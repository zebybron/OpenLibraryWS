using System;
using LibraryDTO;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace JsonReader
{
	public static class AuthorJsonReader
	{
        public static AuthorDTO ReadAuthor(string json)
        {
            JObject o = JObject.Parse(json);
            string bioTokenAsString = null;
            if(o.TryGetValue("bio", out JToken? bioToken))
            {
                if(bioToken.Type == JTokenType.String)
                {
                    bioTokenAsString = (string)bioToken;
                }
                else
                {
                    var bioTokenValue = o["bio"]?["value"];
                    bioTokenAsString = (string)bioTokenValue;
                }
            }

            AuthorDTO author = new AuthorDTO
            {
                Id = (string)o["key"],
                Name = (string)o["name"],
                Bio = bioTokenAsString,
                BirthDate = o.TryGetValue("birth_date", out JToken? bd) ? DateTime.ParseExact((string)bd, "d MMMM yyyy", CultureInfo.InvariantCulture) : null,
                DeathDate = o.TryGetValue("death_date", out JToken? dd) ? DateTime.ParseExact((string)dd, "d MMMM yyyy", CultureInfo.InvariantCulture) : null,
                Links = o.TryGetValue("links", out JToken? links) ? links.Select(l => new LinkDTO { Title = (string)l["title"], Url = (string)l["url"] }).ToList() : new List<LinkDTO>(),
                AlternateNames = o.TryGetValue("alternate_names", out JToken? altNames) ? altNames.Select(alt => (string)alt).ToList() : new List<string?>()
            };
            return author;
        }

        public static Tuple<long, IEnumerable<AuthorDTO>> GetAuthorsByName(string json)
        {
            JObject o = JObject.Parse(json);
            long numFound = (long)o["numFound"];
            var authors = o["docs"].Select(doc => new AuthorDTO
            {
                Id = $"/authors/{(string)doc["key"]}",
                Name = (string)doc["name"],
            });
            return Tuple.Create(numFound, authors);
        }
	}
}

