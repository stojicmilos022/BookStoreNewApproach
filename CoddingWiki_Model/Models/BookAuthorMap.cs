﻿using CoddingWiki_Model.Models.FluentModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoddingWiki_Model.Models
{
    public class BookAuthorMap
    {
        [ForeignKey("Book")]
        public int Book_Id { get; set; }
        [ForeignKey("Author")]
        public int Author_Id { get; set; }
        
        public Fluent_Book Book { get; set; }

        public Fluent_Author Author { get; set; }

    }
}
