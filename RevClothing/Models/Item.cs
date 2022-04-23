﻿using System;
using System.ComponentModel.DataAnnotations;
namespace RevClothing.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Name { get; set; }

        public string code { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Required.")]
        public decimal Price { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Date Modified")]
        public DateTime? DateModified { get; set; }

        [Display(Name = "Item Type")]
        public ItemType Type { get; set; }

    }

    public enum ItemType
    {
        Mens = 1,
        Womens = 2,
        Childern = 3
    }
}
