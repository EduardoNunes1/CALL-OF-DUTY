namespace CallOfDuty.Models
{
    public class Personagens
    {
        public int Numero { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public string Patente { get; set; }
        public List<string> Tipo { get; set; }
    }
}
