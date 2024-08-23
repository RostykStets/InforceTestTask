namespace InforceTestTask.Repositories.Interfaces
{
    public interface IShorteningAlgorithmRepository
    {
        Task<string> ShorteningAlgorithm(string originalUrl);
    }
}
