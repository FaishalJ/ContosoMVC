namespace ContosoMVC.StartUpExtensions
{
    public static class AddServices
    {
        public static void AddServies(this WebApplicationBuilder builder) {
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContextService(builder.Configuration);
        }
    }
}
