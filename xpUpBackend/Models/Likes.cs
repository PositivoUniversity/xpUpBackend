﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xpUpBackend.Models
{
    public class Likes
    {
        [Key]
        public int Id { get; set; }
        public bool Like { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [ForeignKey("Users")]
        public Users LikedBy { get; set; }
        [ForeignKey("News")]
        public News Notice { get; set; }
        [ForeignKey("Events")]
        public Events Event { get; set; }

        public Likes() { }

        public Likes(bool like, Users likedBy, News notice, Events ev)
        {
            Like = like;
            LikedBy = likedBy;
            Notice = notice;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Event = ev;
        }
    }
}
