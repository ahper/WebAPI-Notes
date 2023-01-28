namespace Notes.Persistence
{
    public class DbInitializer
    {
        /// <summary>
        /// Метод Initialize
        /// используется при старте приложения и проверять создана ли БД.
        /// Если нет, то будет создана на основе <param name="context"></param>
        /// </summary>
        public static void Initialize(NotesDbContext context) 
        {
            context.Database.EnsureCreated();
        }
    }
}
