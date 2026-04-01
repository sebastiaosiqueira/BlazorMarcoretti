using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorScaffolding.Data
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string  Name { get; set; }
        [MaxLength(200)]
        public string Description  { get; set; }
        [MaxLength(200)]
        public string ImageUrl  { get; set; }
        [Column(TypeName ="decimal(10,2)")]
        public decimal Price { get; set; }
        public double Stock { get; set; }
        public bool Active { get; set; }
    }
}
