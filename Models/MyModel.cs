    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System;
    
    namespace CRUDelicious.Models
    {
        public class Dishes
        {
            // auto-implemented properties need to match the columns in your table
            // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
            [Key]
            public int UserId { get; set; }
            // MySQL VARCHAR and TEXT types can be represeted by a string

            [Required]
            [MinLength(2)]
            public string Name { get; set; }

            [Required]
            [MinLength(2)]
            public string Chef{ get; set; }

            [Required]
            [Range(1,5)]
            public int Tastiness { get; set; }

            [Required]
            [Range(1,5000)]
            public int Calories { get; set; }
            // The MySQL DATETIME type can be represented by a DateTime

            [Required]
            [MinLength(5)]
            public string Text {get;set;}

            public DateTime CreatedAt {get;set;}
            public DateTime UpdatedAt {get;set;}
        }
    }
    