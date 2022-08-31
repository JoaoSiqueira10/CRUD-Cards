using System.ComponentModel.DataAnnotations;

namespace CartaoAPI.Models
{
    public class Cartao
    {
        [Key]
        public Guid Id { get; set; }
        public string NomeCartao { get; set; }
        public string NumCartao { get; set; }
        public int VencimentoMes { get; set; }
        public int VencimentoAno { get; set; }
        public int CVV { get; set; }
    }
}
