using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Notes.Persistence;

namespace Notes.Tests.Common
{
    public class NotesContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid NoteIdForDelete = Guid.NewGuid();
        public static Guid NoteIdForUpdate = Guid.NewGuid();

        public static NotesDbContext Create()
        {
            var options = new DbContextOptionsBuilder<NotesDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new NotesDbContext(options);
            context.Database.EnsureCreated();
            context.Notes.AddRange(
                new Note
                {
                    UserId = UserAId,
                    Id = Guid.Parse("7AA4E538-D19D-45D2-8EE9-A2A71511B120"),
                    Title = "Title1",
                    Details = "Details1",
                    CreationDate = DateTime.Today,
                    EditDate = null
                },
                new Note
                {
                    UserId = UserBId,
                    Id = Guid.Parse("F00F6867-71A6-443F-B76A-282A0022DC0A"),
                    Title = "Title2",
                    Details = "Details2",
                    CreationDate = DateTime.Today,
                    EditDate = null
                },
                new Note
                {
                    UserId = UserAId,
                    Id = NoteIdForDelete,
                    Title = "Title3",
                    Details = "Details3",
                    CreationDate = DateTime.Today,
                    EditDate = null
                },
                new Note
                {
                    UserId = UserBId,
                    Id = NoteIdForUpdate,
                    Title = "Title4",
                    Details = "Details4",
                    CreationDate = DateTime.Today,
                    EditDate = null
                }
                );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(NotesDbContext context)
        {
            context.Database.EnsureCreated();
            context.Dispose();
        }
    }
}
