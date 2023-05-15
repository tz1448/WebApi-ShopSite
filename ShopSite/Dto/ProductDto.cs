using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDto
    {

        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? CategoryId { get; set; }

        public string? CategoryName { get; set; }
        
        public int Price { get; set; }

        public string? Image { get; set; }


    }
}
