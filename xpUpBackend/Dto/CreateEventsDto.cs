﻿
namespace xpUpBackend.Dto
{
    public class CreateEventsDto
    {
     
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public int UsersId { get; set; }
        public string userPost { get; set;  }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
