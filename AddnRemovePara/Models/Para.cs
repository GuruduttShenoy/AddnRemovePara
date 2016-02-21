using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AddnRemovePara.Models
{
    public class Para
    {
        [Key]
        public string ParaID { get; set; }

        public string ParaText { get; set; }
       
    }
}