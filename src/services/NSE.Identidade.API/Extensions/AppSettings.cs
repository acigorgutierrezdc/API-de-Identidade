namespace NSE.Identidade.API.Extensions
{
    public class AppSettings
    {
        //Igor - 06072021 - Propriedades criadas na unha pro JWT utilizar no Token.
        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
    }
}