﻿using FinShark.Api.Dtos.Comment;
using FinShark.Api.Models;
using System.Runtime.CompilerServices;

namespace FinShark.Api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId,
            };
        }
        public static Comment ToCommentFromCreatedDTO(this CreateCommentDto commentDto, int stockId)
        {
            return new Comment
            {

                Title = commentDto.Title,
                Content = commentDto.Content,
                StockId = stockId
            };
        }
        public static Comment ToCommentFromUpdateDTO(this UpdateCommentReqDto commentDto)
        {
            return new Comment
            {

                Title = commentDto.Title,
                Content = commentDto.Content
            };
        }
    }
}
