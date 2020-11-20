using System.Globalization;
using System.Text;

namespace smartfy.portal_api.presentation.UI.Web.Extensions
{
    public static class CommomExtension
    {
        public static string MaskCpf(this string cpf)
        {
            if (string.IsNullOrEmpty(cpf)) return string.Empty;

            var normalizedCpf = cpf.Replace(".", string.Empty).Replace("-", string.Empty);

            if (normalizedCpf.Length != 11) return cpf;

            return normalizedCpf.Substring(0, 3) + "." + normalizedCpf.Substring(3, 3) + "." +
                   normalizedCpf.Substring(6, 3) + "-" + normalizedCpf.Substring(9, 2);
        }

        public static string RemoveDiacritics(this string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
