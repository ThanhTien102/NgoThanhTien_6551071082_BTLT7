namespace WinFormsApp1.Data
{
    /// <summary>
    /// Factory interface để tạo DbContext instances
    /// </summary>
    public interface IDbContextFactory
    {
        /// <summary>
        /// Tạo một instance DbContext mới
        /// </summary>
        AppDbContext CreateDbContext();
    }

    /// <summary>
    /// Implementation của DbContext Factory
    /// </summary>
    public class AppDbContextFactory : IDbContextFactory
    {
        public AppDbContext CreateDbContext()
        {
            return new AppDbContext();
        }
    }
}
