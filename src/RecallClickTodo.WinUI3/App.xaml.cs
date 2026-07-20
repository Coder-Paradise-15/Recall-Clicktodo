using Microsoft.UI.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RecallClickTodo.Data;
using RecallClickTodo.Core.Interfaces;
using RecallClickTodo.Api.Services;
using RecallClickTodo.Api.Implementations;

namespace RecallClickTodo.WinUI3
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null!;

        public App()
        {
            this.InitializeComponent();
            SetupDependencyInjection();
        }

        private void SetupDependencyInjection()
        {
            var services = new ServiceCollection();

            // Add DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=RecallClickTodo.db"));

            // Add Services
            services.AddScoped<IScreenshotService, ScreenshotService>();
            services.AddScoped<ITodoService, TodoService>();
            services.AddScoped<IApiService, ApiService>();
            services.AddHttpClient<CustomApiClient>();

            ServiceProvider = services.BuildServiceProvider();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();
        }

        private Window? m_window;
    }
}
