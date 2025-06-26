using Scalar.AspNetCore;

namespace ScreenSound.API.Scalar;

public class ScalarApp
{
    public static void Run(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference(options =>
            {
                options.Title = "ScreenSound API";
                options.Theme = ScalarTheme.DeepSpace;
                options.DefaultHttpClient = new(ScalarTarget.CSharp, ScalarClient.HttpClient);
                options.CustomCss = "";
                options.ShowSidebar = true;
            });
        }
    }
}