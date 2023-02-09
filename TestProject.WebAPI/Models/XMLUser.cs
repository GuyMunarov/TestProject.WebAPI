using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Xml.Serialization;
using TestProject.WebAPI.Data;

namespace TestProject.WebAPI.Models
{

    [XmlRoot(ElementName = "User")]
    public class XMLUser
    {

        [XmlElement(ElementName = "first_name")]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "last_name")]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [XmlElement(ElementName = "email")]
        [JsonProperty("email")]
        public string Email { get; set; }

        [XmlElement(ElementName = "rate")]
        [JsonProperty("rate")]
        public float Rate { get; set; }
        public XMLUser()
        {

        }
        public XMLUser(string firstName, string lastName, string email, float rate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Rate = rate;
        }
        public User CreateUser()
        {
            return new User()
            {

                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
            };
        }
    }
}
