using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Share.Models
{
    public class SharedTool
    {
        public SharedTool() { }

        public SharedTool(string toolName, string description, int quantity, string imagePath)
        {
            ToolName = toolName;
            Description = description;
            Quantity = quantity;
            ImagePath = imagePath;
        }

        [Required(ErrorMessage = "Tool Name Cannot be empty!")]
        public string ToolName { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        [Range(0, 100)]
        public int Quantity { get; set; }
        public string ImagePath { get; set; }

    }
}
    