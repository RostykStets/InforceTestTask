using InforceTestTask.Repositories.Interfaces;
using System.Text;

namespace InforceTestTask.Repositories.Implementations
{
    public class ShorteningAlgorithmRepository : IShorteningAlgorithmRepository
    {
        public async Task<string> ShorteningAlgorithm(string originalUrl)
        {
            string shortenedUrl = "";
            string vowels = "aeiouyAEIOUY";

            originalUrl = originalUrl.Substring(8);

            await Task.Run(() =>
            {
                if (!originalUrl.Contains('/'))
                {
                    shortenedUrl = new string(originalUrl.Where(c => !vowels.Contains(c)).ToArray());
                    return;
                }
                var urls = originalUrl.Split('/');
                int limit = 0;
                if (originalUrl.Contains("="))
                    limit = urls.Length;
                else
                    limit = urls.Length - 1;

                for (int i = 0; i < limit; i++)
                {
                    var url = urls[i];
                    var urlsParameters = url.Split('&');

                    for (int j = 0; j < urlsParameters.Length; j++)
                    {
                        var urlChunks = urlsParameters[j].Split('=');
                        urlChunks[0] = new string(urlChunks[0].Where(c => !vowels.Contains(c)).ToArray());
                        urlsParameters[j] = String.Join('=', urlChunks);
                    }
                    urls[i] = String.Join('&', urlsParameters);
                }
                shortenedUrl = String.Join('/', urls);

            });

            return shortenedUrl;
        }
    }
}
