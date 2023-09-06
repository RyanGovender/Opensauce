using Refit;

//[Headers("Authorization: Bearer")]
[Headers("User-Agent: ryangovender")]
public interface IGitHubUserApi
{
    [Get("/users/{username}")]
    Task<dynamic> GetUserAsync(string username);

    [Get("/users/{username}/repos")]
    Task<List<dynamic>> GetUserReposAsync(string username);
}