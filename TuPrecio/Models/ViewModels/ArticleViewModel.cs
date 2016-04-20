using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuPrecio.Models.ViewModels
{
    public class ArticleViewModel
    {
        [Required]
        [Display(Name="Nombre del artículo")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Latitud")]
        public string Latitude { get; set; }
        [Required]
        [Display(Name = "Longitud")]
        public string Longitude { get; set; }
        [Required]
        [Display(Name = "Dirección del negocio")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Nombre del negocio")]
        public string BusinnesName { get; set; }

        public string Comment { get; set; } 
    }
}