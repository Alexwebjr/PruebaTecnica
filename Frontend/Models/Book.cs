﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frontend.Models
{
    public class Book
    {
            public int ID { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int PageCount { get; set; }
            public string Excerpt { get; set; }
            public string PublishDate { get; set; }
    }
}