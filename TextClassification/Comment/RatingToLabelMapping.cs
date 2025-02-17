using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Transforms;

namespace api.TextClassification.Comment
{
    
[CustomMappingFactoryAttribute("RatingToLabelMapping")]
public class RatingToLabelMapping : CustomMappingFactory<CommentData, CommentDataWithLabel>
{
    public static void Mapping(CommentData input, CommentDataWithLabel output)
    {
        output.Review = input.Review;     // Copy the Review property
        output.Label = input.Rating >= 3; // Derive the Label from Rating
    }

    public override Action<CommentData, CommentDataWithLabel> GetMapping()
    {
        return Mapping;
    }
}
}