using Microsoft.AspNetCore.Mvc.Razor;
using MVC01.Services;

internal class Program
{
    public static string ContentRootPath { get; set; }
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();
        //builder.Services.AddTransient(typeof(ILogger<>), typeof(Logger<>)); //sẽ tự động đc đk

        builder.Services.Configure<RazorViewEngineOptions>(options =>
        {
            //  /Views/Controller/Action.cshtml
            //  /MyView/Controller/Action.cshtml

            //  {0} -> tên action
            //  {1} -> tên controller
            //  {2} -> tên area
            options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
        });

        builder.Services.AddTransient<ProductService>();

        var app = builder.Build();

        IWebHostEnvironment env = app.Services.GetRequiredService<IWebHostEnvironment>();
        ContentRootPath = env.ContentRootPath; //lấy đường dẫn của project

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();


        //URL: {controler}/{action}/{id}
        //abc/xyz => controller = abc/action = xyz gọi method xyz trong controller abc
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();


        app.Run();
    }
}