﻿using System.ComponentModel.DataAnnotations;

namespace FinShark.Api.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(005, ErrorMessage = "Title must be at least 5 characters")]
        [MaxLength(280, ErrorMessage = "Title cannot be over 280 characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(005, ErrorMessage = "Content must be at least 5 characters")]
        [MaxLength(280, ErrorMessage = "Content cannot be over 280 characters")]
        public string Content { get; set; } = string.Empty;
    }
}