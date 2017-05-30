using App.Services.Data.Common.Contracts;
using Ganss.XSS;

namespace App.Services.Data.Common
{
    public class HtmlSanitizerAdapter : ISanitizer
    {
        public string Sanitize(string html)
        {
            var sanitizer = new HtmlSanitizer();
            var result = sanitizer.Sanitize(html);
            return result;
        }
    }
}
