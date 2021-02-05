using System;
using System.ComponentModel.DataAnnotations;

namespace AllBackgroundStuff
{
    public class ModelAUpdateDTO
    {
        [Required]
        public int PropInt { get; set; }
        [ValidateEmail(ErrorMessage = "Email should contain @gmail.com.")]
        public string PropString { get; set; }
        public double PropDouble { get; set; }
        public Guid PropGuid { get; set; }
        public ModelEnum PropModelEnum { get; set; }
    }
}
