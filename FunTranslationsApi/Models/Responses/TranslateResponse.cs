namespace FunTranslationsApi.Models.Responses
{
    public class TranslateResponse
    {
        public Success Success { get; set; }
        public Contents Contents { get; set; }
    }

    public class Contents
    {
        public string Translation { get; set; }
        public string Text { get; set; }
        public string Translated { get; set; }
    }
}
