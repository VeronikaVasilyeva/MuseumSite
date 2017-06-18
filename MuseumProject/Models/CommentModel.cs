using System;
using MuseumProject.Context;

namespace MuseumProject.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Comment { get; set; }
        public bool Deleted { get; set; }

        public CommentModel() { }

        public CommentModel(Comments comment)
        {
            Id = comment.Id;
            UserName = comment.UserProfile.UserName;
            CreatedDate = comment.CreatedDate;
            Comment = comment.Comment;
            Deleted = comment.Deleted;
        }
    }
}