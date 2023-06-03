using projetoCaixa.Entites;
using System.Text.Json.Serialization;

namespace projetoCaixa.DTOs
{
    public class ItemVendaDTO
    {
        public int Id { get; set; }

        public float Preco { get; set; }

        public string? Descricao { get; set; }

        public int Quantidade { get; set; }


    }
}
