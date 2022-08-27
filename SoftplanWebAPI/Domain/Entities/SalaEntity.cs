using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftplanWebAPI.Entities
{
    [Table("Salas")]
    public class SalaEntity
    {
        public long Id { set; get; }
        public string? Nome { set; get; }
        public string? Descricao { set; get; }
        public int? Disponivel { set; get; }
        public string? Tipo { set; get; }
    }
}
