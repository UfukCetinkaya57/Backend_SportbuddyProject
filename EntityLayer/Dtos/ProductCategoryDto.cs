using CoreLayer.Entities;
using CoreLayer.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos
{
    public class ProductCategoryDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryType { get; set; }
        public List<Product> Products { get; set; }
    }
}
