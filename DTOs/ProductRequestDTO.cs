﻿namespace projetoCaixa.DTOs
{
    public class ProductRequestDTO
    {
        public string? Descricao { get; set; }
        public float Preco { get; set; }
        public int Estoque { get; set; }
        public int UserId { get; set; }
    }
}
