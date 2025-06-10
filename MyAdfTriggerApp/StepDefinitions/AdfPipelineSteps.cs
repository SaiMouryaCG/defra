[Binding]
public class AdfPipelineSteps
{
    private readonly AdfPipelineService _pipelineService;

    public AdfPipelineSteps()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        _pipelineService = new AdfPipelineService(config);
    }

    [Given(@"I trigger and monitor the ADF pipeline")]
public async Task GivenITriggerAndMonitorTheAdfPipeline()
{
    var status = await _pipelineService.TriggerAndMonitorPipelineAsync();
    Console.WriteLine($"Final pipeline status: {status}");
}

}
