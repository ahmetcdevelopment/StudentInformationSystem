﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using studentProgramV2.Shared.Utilities.Results.Abstract;

namespace studentProgramV2.Entities.DTOs
{
    public class LessonUpdateDto:DtoGetBase
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Ders Adı")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string Name { get; set; }
        [DisplayName("Ders Kredisi")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir.")]
        public int Credit { get; set; }
        [DisplayName("Ders Özel Not Alanı")]
        [MaxLength(500, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string Note { get; set; }
        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir.")]
        public bool IsActive { get; set; }
        [DisplayName("Silindi Mi?")]
        [Required(ErrorMessage = "{0} Boş Geçilmemelidir.")]
        public bool IsDeleted { get; set; }
    }
}
