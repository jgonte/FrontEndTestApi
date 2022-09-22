using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEndTestApi.DataTransferObjects
{
    public class ContactInputDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public DateTimeOffset? DateOfBirth { get; set; }

        public int? Reputation { get; set; }

        public string Description { get; set; }

        public IFormFile Avatar { get; set; }
    }
}
