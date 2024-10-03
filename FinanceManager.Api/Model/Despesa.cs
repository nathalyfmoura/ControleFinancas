using System;

namespace FinanceManager.Api.Model
{
    public class Despesa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public string Categoria { get; set; }
        public bool Pago { get; set; }
    }
}

