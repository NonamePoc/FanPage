﻿using System.ComponentModel.DataAnnotations;

namespace FanPage.Domain.Entities.Identity
{
    public class Bookmark
    {
        [Key] public int BookmarkId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string TitelName { get; set; }

        public string Stage { get; set; }
    }
}