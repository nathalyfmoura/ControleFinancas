using System;

namespace FinanceManager.Api.Model
{
    public class Receita
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataRecebimento { get; set; }
        public string Categoria { get; set; }
        public bool Recebido { get; set; }
    }
}
