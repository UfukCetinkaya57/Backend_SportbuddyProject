using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities.Concerete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public int ProductCatalogId { get; set; }
        public string Name { get; set; }
        public short UnitsOnOrder { get; set; }
        public short UnitsInStock { get; set; }
        public short QuantityPerUnit { get; set; }
        public decimal Price { get; set; }
        public string IsSale { get; set; }

        [NotMapped]
        public string PhotoBase64 { get; set; } = null;

        public string? PhotoPath { get; set; } = null;
    }
}
