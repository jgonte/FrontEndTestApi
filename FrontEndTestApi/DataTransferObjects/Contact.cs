﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEndTestApi.DataTransferObjects
{
    public class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Reputation { get; set; }

        public string Description { get; set; }

        public byte[] Avatar { get; set; }
    }
}
