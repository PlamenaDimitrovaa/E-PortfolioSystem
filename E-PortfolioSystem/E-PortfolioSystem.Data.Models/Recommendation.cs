﻿namespace E_PortfolioSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Recommendation;
    public class Recommendation
    {
        public Recommendation()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid FromUserId { get; set; }

        public Guid ToUserId { get; set; }

        [Required]
        [MaxLength(TextMaxLength)]
        public string Text { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public ApplicationUser FromUser { get; set; } = null!;

        public ApplicationUser ToUser { get; set; } = null!;
    }
}
