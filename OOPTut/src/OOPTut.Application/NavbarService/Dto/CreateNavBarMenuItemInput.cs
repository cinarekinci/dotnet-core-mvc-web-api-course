﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OOPTut.Application.NavbarService.Dto
{
    public class CreateNavBarMenuItemInput
    {
        [Required]
        [Display(Name ="Link'in Adı")]
        public string Title { get; set; }
        [Required]
        [Display(Name ="URL")]
        public string Url { get; set; }
        [Required]
        [Display(Name ="Aynı Sayfada Açılsın mı?")]
        public bool OpenInSamePage { get; set; }
        [Display(Name = "İkon Kodu")]
        public string Icon { get; set; }
        [Display(Name = "Roller")]
        public string Roles { get; set; }
    }
}
