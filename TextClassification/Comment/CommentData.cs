using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace api.TextClassification.Comment
{
    public class CommentData
    {
        [LoadColumn(0)]
        public float Rating { get; set; }
        [LoadColumn(1)]
        public string Review {get;set;}
        
    }
}