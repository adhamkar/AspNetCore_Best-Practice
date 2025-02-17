using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using api.Entities;
using Microsoft.ML;
using Microsoft.ML.Transforms;

namespace api.TextClassification.Comment
{
    public class Prediction
    {
         private readonly MLContext mlContext;
    private readonly string DataPath = Path.GetFullPath("/home/adham/Téléchargements/Products_Review/Flipkart_Reviews_ Electronics.csv");
    private readonly string ModelPath = "products_reviews.zip";
    private ITransformer model;
       
        public Prediction()
    {
        mlContext = new MLContext();

        // Load or train the model
        if (File.Exists(ModelPath))
        {
            // Load the trained model
            model = mlContext.Model.Load(ModelPath, out var schema);
        }
        else
        {
            TrainModel();
        }
    }

    private void TrainModel()
    {
        var data = mlContext.Data.LoadFromTextFile<CommentData>(DataPath, separatorChar: ',', hasHeader: true);
       var labelMapping = new Action<CommentData, CommentDataWithLabel>((input, output) =>
        {
            output.Review = input.Review;     
            output.Label = input.Rating >= 3;
        });

        var pipeline = mlContext.Transforms.CustomMapping(labelMapping, contractName: "RatingToLabelMapping")
        .Append(mlContext.Transforms.Text.FeaturizeText("Features", nameof(CommentDataWithLabel.Review)))
        .Append(mlContext.BinaryClassification.Trainers.FieldAwareFactorizationMachine(labelColumnName: "Label", featureColumnName: "Features"));

        model = pipeline.Fit(data);

        // Save the trained model
        mlContext.Model.Save(model, data.Schema, ModelPath);
    }

    public int CommentPrediction(string comment) 
    {
        try{
            var predictor = mlContext.Model.CreatePredictionEngine<CommentData, Commentpredicition>(model);

        var testComment = new CommentData { Review = comment,Rating=0 };
        var prediction = predictor.Predict(testComment);
        bool predictedSentiment = prediction.Probability > 0.7; 

        Console.WriteLine($"Predicted Sentiment: {(predictedSentiment ? "Good" : "Bad")}");
        Console.WriteLine($"Confidence Score: {prediction.Probability}");

       if(predictedSentiment){
        return 1;
       }
       return 0;
        }catch(Exception e){
            Console.WriteLine(e.Message);
            return -1;
        }
        
    }
}
}