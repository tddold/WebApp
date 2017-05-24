namespace App.Services.Data.Common.Contracts
{
    public interface ISanitizer
    {
        string Sanitize(string html);
    }
}
