internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.UseStaticFiles();

      
        string wwwrootPath = Path.Combine(
            Directory.GetCurrentDirectory(), 
            "wwwroot"
        );

       
        app.MapGet("/", () => Results.File(Path.Combine(wwwrootPath, "HTML/static.html"), "text/html"));
        app.MapGet("/html", () => Results.File(Path.Combine(wwwrootPath, "HTML/static.html"), "text/html"));
        app.MapGet("/css", () => Results.File(Path.Combine(wwwrootPath, "CSS/static.css"), "text/css"));
        app.MapGet("/js", () => Results.File(Path.Combine(wwwrootPath, "Js/static.js"), "application/javascript"));
        app.MapGet("/image", () => Results.File(Path.Combine(wwwrootPath, "image/Strawberry.png"), "image/png"));
        app.MapGet("/pdf", () => Results.File(Path.Combine(wwwrootPath, "Docs/static.pdf"), "application/pdf"));
        app.MapGet("/doc", () => Results.File(Path.Combine(wwwrootPath, "Docs/static.docx"), "application/vnd.openxmlformats-officedocument.wordprocessingml.document"));

        app.Run();
    }
}