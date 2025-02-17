using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace api.TextClassification.Comment
{
    public class Commentpredicition
    {
        [ColumnName("PredictedLabel")]
     public bool PredictedLabel { get; set; }
     public float Probability { get; set; }
    }
}