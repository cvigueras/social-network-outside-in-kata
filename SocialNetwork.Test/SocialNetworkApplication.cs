using Dapper;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocialNetwork.Api;
using System.Data.SQLite;

namespace SocialNetwork.Test
{
    public class SocialNetworkApplication: WebApplicationFactory<Program>
    {
        private readonly ITime _time;
        private readonly SQLiteConnection _sqLiteConnection;

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton(_time);
                services.AddSingleton(_sqLiteConnection);
                services.AddSingleton<IMessagesRepository, MessageRepository>();
            });

            return base.CreateHost(builder);
        }

        public SocialNetworkApplication(ITime time)
        {
            _time = time;
            _sqLiteConnection = new SQLiteConnection("Data Source=:memory:");
            _sqLiteConnection.Open();
            _sqLiteConnection.Execute(@"Create Table if not exists Messages(
                Author VARCHAR(100) NOT NULL,
                Post VARCHAR(144) NOT NULL,
                Timestamp DATETIME NOT NULL)");
        }
    }
}