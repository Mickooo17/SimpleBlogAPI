﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Entity
{
    public class Tag
    {
        [Key]
        public string TagName { get; set; }
    }
}
