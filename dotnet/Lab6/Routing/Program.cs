namespace Routing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            app.UseRouting();
            app.UseAuthorization();

            // Route order matters: the most specific routes are registered FIRST,
            // so they get priority over the generic conventional route below.

            // 1. Custom route + int constraint (only whole numbers reach the action)
            app.MapControllerRoute(
                name: "orderById",
                pattern: "order/{id:int}",
                defaults: new { controller = "Order", action = "Id" });

            // 2. Custom route + regex constraint (exactly 3 digits via constraint argument)
            app.MapControllerRoute(
                name: "orderByCode",
                pattern: "code/{code}",
                defaults: new { controller = "Order", action = "Code" },
                constraints: new { code = @"^\d{3}$" });

            // 3. Custom route with optional parameter and default value
            app.MapControllerRoute(
                name: "productList",
                pattern: "products/{category?}",
                defaults: new { controller = "Product", action = "List" });

            // 4. Conventional routing (defaults + optional id) - lowest priority
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}