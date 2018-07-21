using Microsoft.ProjectOxford.Face;
using System;
using System.Threading.Tasks;

namespace FaceDetectApiSdkDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IFaceServiceClient faceServiceClient = CreateFaceClient();

            var faceAttri = new[] { FaceAttributeType.Emotion, FaceAttributeType.Age };
            var faces = await faceServiceClient.DetectAsync("https://psfaceapicourse.blob.core.windows.net/images/diverse-people.png",
                returnFaceAttributes : faceAttri);

            foreach (var face in faces)
            {
                Console.WriteLine("-------Face-------");
                Console.WriteLine($"{face.FaceId}");
                Console.WriteLine($"T: {face.FaceRectangle.Top}; L: {face.FaceRectangle.Left}; " +
                    $"W: {face.FaceRectangle.Width}; H: {face.FaceRectangle.Height}");
                Console.WriteLine($"Age: {face.FaceAttributes.Age}; Happiness: {face.FaceAttributes.Emotion.Happiness}");
            }
        }

        static IFaceServiceClient CreateFaceClient() => new FaceServiceClient("<SubscriptionKeys>", "https://eastasia.api.cognitive.microsoft.com/face/v1.0");
        

    }
}
