using System;
namespace ElevenNoteWebApp.Shared.Models.Note
{
    public class NoteDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CaregoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
