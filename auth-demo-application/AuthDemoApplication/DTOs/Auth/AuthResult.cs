using AuthDemoApplication.DTOs.Auth;

namespace AuthDemoApplication.Services.Results;

public sealed class AuthResult
{
    private AuthResult(bool succeeded, AuthResponse? response, IReadOnlyList<string> errors)
    {
        Succeeded = succeeded;
        Response = response;
        Errors = errors;
    }

    public bool Succeeded { get; }

    public AuthResponse? Response { get; }

    public IReadOnlyList<string> Errors { get; }

    public static AuthResult Success(AuthResponse response)
    {
        return new AuthResult(true, response, Array.Empty<string>());
    }

    public static AuthResult Failure(IEnumerable<string> errors)
    {
        return new AuthResult(false, null, errors.ToArray());
    }

    public static AuthResult Failure(string error)
    {
        return new AuthResult(false, null, new[] { error });
    }
}