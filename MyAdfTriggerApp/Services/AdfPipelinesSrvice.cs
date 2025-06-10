using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.DataFactory;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.Resources;
using Microsoft.Extensions.Configuration;

namespace MyAdfTriggerApp.Services
{
    public class AdfPipelineService
    {
        private readonly IConfiguration _configuration;

        public AdfPipelineService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> TriggerAndMonitorPipelineAsync()
        {
            var subscriptionId = _configuration["ADF:SubscriptionId"];
            var resourceGroup = _configuration["ADF:ResourceGroup"];
            var factoryName = _configuration["ADF:FactoryName"];
            var pipelineName = _configuration["ADF:PipelineName"];

            var credential = new DefaultAzureCredential();
            var armClient = new ArmClient(credential, subscriptionId);

            var rgResource = armClient.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroup));
            var factory = rgResource.GetDataFactoryResource(factoryName);
            var pipeline = factory.GetDataFactoryPipelineResource(pipelineName);

            var runResponse = await pipeline.Value.CreateRunAsync(WaitUntil.Completed);
            var runId = runResponse.Value.RunId;

            Console.WriteLine($"Pipeline triggered. Run ID: {runId}");

            // Polling for status
            var pipelineRun = await factory.GetPipelineRunAsync(runId);
            string status = pipelineRun.Value.Status;

            while (status == "InProgress" || status == "Queued")
            {
                Console.WriteLine($"Pipeline status: {status}. Waiting...");
                await Task.Delay(TimeSpan.FromSeconds(10));
                pipelineRun = await factory.GetPipelineRunAsync(runId);
                status = pipelineRun.Value.Status;
            }

            Console.WriteLine($"Pipeline completed with status: {status}");
            return status;
        }
    }
}
