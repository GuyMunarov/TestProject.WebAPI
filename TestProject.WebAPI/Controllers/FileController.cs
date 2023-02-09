using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestProject.WebAPI.Models;
using TestProject.WebAPI.SeedData;
using TestProject.WebAPI.Services.Abstractation;

namespace TestProject.WebAPI.Controllers
{

    [Route("api")]
    public class FileController: ControllerBase
    {
        private readonly IUsersRepository usersRepository;
        private readonly IXmlDeserializer xmlDeserializer;

        public FileController(IUsersRepository usersRepository,IXmlDeserializer xmlDeserializer)
        {
            this.usersRepository = usersRepository;
            this.xmlDeserializer = xmlDeserializer;
        }
        [HttpPost("analyze")]
        public async Task<ActionResult<StatisticalModel>> Analyze()
        {
            var userCollection = xmlDeserializer.GetObjectFromXml<UserCollection>(Request.Body);

           var mappedUsers =  userCollection.Users.Select(x => x.CreateUser()).ToList();
           await usersRepository.AddUsers(mappedUsers);

            var allRates = userCollection.Users.Select(x => x.Rate).ToList();
            return Ok(new StatisticalModel(allRates));
        }

        [HttpPost("addUser")]
        public async Task<ActionResult<string>> AddUsersToFile([FromBody] XMLUpdateRequest request)
        {

            byte[] data = Convert.FromBase64String(request.Content);
            string decodedString = Encoding.UTF8.GetString(data);
            var userCollection = xmlDeserializer.GetObjectFromXml<UserCollection>(decodedString);

  

           var usersToAdd = userCollection.Users.Select(x => new XMLUser(x.FirstName, x.LastName, x.Email, x.Rate)).ToList();
            userCollection.Users.AddRange(usersToAdd);
            return Ok(xmlDeserializer.Serialize(userCollection));
        }


       
    }

}
