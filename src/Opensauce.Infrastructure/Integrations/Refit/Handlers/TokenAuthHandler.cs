
namespace Opensauce.Infrastructure.Integrations.Refit.Handlers
{
    public class TokenAuthHandler : DelegatingHandler
    {
        public TokenAuthHandler(){}

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer","");
            return await base.SendAsync(request, cancellationToken);
        }
    }
}