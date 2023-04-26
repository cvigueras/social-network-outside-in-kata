using System.Data.SQLite;
using Dapper;

namespace SocialNetwork.Api.Messages
{
    public class MessageRepository : IMessagesRepository
    {
        private readonly SQLiteConnection _connection;

        public MessageRepository(SQLiteConnection connection)
        {
            _connection = connection;
        }

        public async Task Add(Message message)
        {
            await _connection.ExecuteAsync($"INSERT INTO Messages(Author, Post, Timestamp) VALUES('{message.Author}', '{message.Post}', '{message.Timestamp:O}')");
        }

        public Task<IEnumerable<Message>> Get(string author)
        {
            return _connection.QueryAsync<Message>($"SELECT Author, Post, Timestamp FROM Messages WHERE Author = '{author}' ORDER BY Timestamp DESC");
        }
    }
}
