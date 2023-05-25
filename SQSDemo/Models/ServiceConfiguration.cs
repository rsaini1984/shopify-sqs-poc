using static System.Net.WebRequestMethods;

namespace SQSDemo.Helpers
{
    public class ServiceConfiguration
    {
        public AWSSQS AWSSQS { get; set; }
        public string QueueUrl = "https://sqs.eu-west-1.amazonaws.com/181102070517/SQS_demo";
    }
    public class AWSSQS
    {
        public string QueueUrl= "https://sqs.eu-west-1.amazonaws.com/181102070517/SQS_demo";
    }
}
