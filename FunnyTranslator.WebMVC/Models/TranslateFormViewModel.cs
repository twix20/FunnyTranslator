using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FunnyTranslator.Models
{
    public class TranslateFormViewModel
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public string TranslateType { get; set; }
    }
}