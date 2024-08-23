using InforceTestTask.Repositories.Interfaces;
using System.Text;

namespace InforceTestTask.Repositories.Implementations
{
    public class ShorteningAlgorithmRepository : IShorteningAlgorithmRepository
    {
        public string ShorteningAlgorithm(string originalUrl)
        {
            string shortenedUrl = "";
            string vowels = "aeiouyAEIOUY";
            var stringBuilder = new StringBuilder();
            originalUrl = originalUrl.Substring(7);

            if(!originalUrl.Contains('/'))
            {
                shortenedUrl = new string(originalUrl.Where(c => !vowels.Contains(c)).ToArray());
                return shortenedUrl;
            }

            var urls = originalUrl.Split('/');
            for (int i = 0; i < urls.Length - 1; i++)
            {
                var url = urls[i];
                var urlsParameters = url.Split('&');
                foreach(var parameter in urlsParameters)
                {
                    string urlChunk = new string(parameter.Split('=')[0].Where(c => !vowels.Contains(c)).ToArray());
                    stringBuilder.Append(urlChunk);
                }
            }
            shortenedUrl = stringBuilder.ToString();

            return shortenedUrl;
        }
    }
}
