using AdminTareas.Data.Abstractions.Interfaces;
using AdminTareas.Data.Dapper.Repositories;
using AdminTareas.Data.Database; // 👈 IMPORTANTE
using AdminTareas.Services.Interfaces;
using AdminTareas.Services.Service;
using AdminTareas.ViewModels.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AdminTareas.WinForms;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var connectionString = "Data Source=admintareas.db";


        DatabaseInitializer.Initialize(connectionString);

        var services = new ServiceCollection();

        services.AddSingleton<ITareaRepository>(
            _ => new TaskRepositoryDapper(connectionString)
        );

        services.AddSingleton<ITaskService, TaskService>();
        services.AddTransient<TaskViewModel>();

        using var provider = services.BuildServiceProvider();


        Application.Run(
            new TaskForm(provider.GetRequiredService<TaskViewModel>())
        );
    }
}
