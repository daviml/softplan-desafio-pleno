using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftplanWebAPI.Entities
{
    [Table("Reservas")]
    public class ReservaEntity
    {
        public long Id { set; get; }
        public DateTime DataInicio { set; get; }
        public DateTime DataFim { set; get; }
        public string? Email { set; get; }
        public string? Sala { set; get; }
    }
}
