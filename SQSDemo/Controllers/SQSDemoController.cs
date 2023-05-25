using Amazon.SQS.Model;
using Amazon.SQS;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Amazon;
using SQSDemo.Services;
using SQSDemo.Models;

namespace SQSDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SQSDemoController : ControllerBase
    {
       
      
        private readonly ILogger<SQSDemoController> _logger;
        private readonly IAWSSQSService _AWSSQSService;
        public SQSDemoController(ILogger<SQSDemoController> logger, IAWSSQSService AWSSQSService)
        {
            _logger = logger;
            this._AWSSQSService = AWSSQSService;
        }
        [Route("postMessage")]
        [HttpPost]
        public async Task<IActionResult> PostMessageAsync([FromBody] User user)
        {
            var result = await _AWSSQSService.PostMessageAsync(user);
            return Ok(new { isSucess = result });
        }
        [Route("getAllMessages")]
        [HttpGet]
        public async Task<IActionResult> GetAllMessagesAsync()
        {
            var result = await _AWSSQSService.GetAllMessagesAsync();
            return Ok(result);
        }
        [Route("deleteMessage")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMessageAsync(DeleteMessage deleteMessage)
        {
            var result = await _AWSSQSService.DeleteMessageAsync(deleteMessage);
            return Ok(new { isSucess = result });
        }






        //[HttpGet]
        //public async Task<IActionResult> GetAllMessagesAsync()
        //{
        //    var result = await _AWSSQSService.GetAllMessagesAsync();
        //    return Ok(result);
        //}
        ////[HttpGet(Name = "GetWeatherForecast")]
        ////public IEnumerable<WeatherForecast> Get()
        ////{
        ////    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        ////    {
        ////        Date = DateTime.Now.AddDays(index),
        ////        TemperatureC = Random.Shared.Next(-20, 55),
        ////        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        ////    })
        ////    .ToArray();
        ////}
        //[HttpPost]
        //public async Task Post(WeatherForecast data)
        //{
        //    string messageBody = "This is a sample message to send to the example queue.";
        //    string queueUrl = "https://sqs.eu-west-2.amazonaws.com/181102070517/SQS_demo";

        //    // Create an Amazon SQS client object using the
        //    // default user. If the AWS Region you want to use
        //    // is different, supply the AWS Region as a parameter.
        //    IAmazonSQS client = new AmazonSQSClient(RegionEndpoint.EUWest2);

        //    var request = new SendMessageRequest
        //    {
        //        MessageBody = messageBody,
        //        QueueUrl = queueUrl,
        //    };

        //    var response = await client.SendMessageAsync(request);

        //    if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        Console.WriteLine($"Successfully sent message. Message ID: {response.MessageId}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Could not send message.");
        //    }

        //    //var client = new AmazonSQSClient();
        //    //var request = new SendMessageRequest()
        //    //{
        //    //    MessageBody = JsonSerializer.Serialize(data),
        //    //    QueueUrl = "https://sqs.eu-west-2.amazonaws.com/181102070517/SQS-demo"
        //    //};

        //    //var result = await client.SendMessageAsync(request);
        //}
    }
}