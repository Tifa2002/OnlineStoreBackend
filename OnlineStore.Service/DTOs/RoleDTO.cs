﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.DTOs
{
    public class RoleDTO
    {
        [MinLength(2)]
        public string Name {  get; set; }
    }
}
