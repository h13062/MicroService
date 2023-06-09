﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruiting.Core.Entity
{
    public class SubmissionStatus
    {
        [Key]
        public int LookupCode { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }
        public List<Submission>? Submissions { get; set; }
    }
}
