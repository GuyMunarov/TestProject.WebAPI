using System.Collections.Generic;
using TestProject.WebAPI.SeedData;

namespace TestProject.WebAPI.Models
{
    public class XMLUpdateRequest
    {
        public string Content { get; set; }
        public List<UserForAddModelForm> Users { get; set; }
    }
}
