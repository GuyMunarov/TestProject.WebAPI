using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestProject.WebAPI.Models
{


	[XmlRoot(ElementName = "UserCollection")]
	public class UserCollection
	{

		[XmlElement(ElementName = "User")]
		public List<XMLUser> Users { get; set; }
	}
}
