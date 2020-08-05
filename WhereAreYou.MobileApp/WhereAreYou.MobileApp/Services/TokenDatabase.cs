using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WhereAreYou.MobileApp.Models;
using Xamarin.Forms;

namespace WhereAreYou.MobileApp.Services
{
    public partial class TokenDatabase : ITokenDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(DbConstants.DatabasePath, DbConstants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public TokenDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);

        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(SavedToken).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(SavedToken)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public async Task InsertOrReplaceTokenAsync(SavedToken token)
        {
            await Database.InsertOrReplaceAsync(token);
            MessagingCenter.Send<SavedToken>(token, SavedToken.TOKEN_SAVED_MESSAGE);
        }

        public async Task RemoveTokenAsync(string meetHash)
        {
            var savedToken = await Database.FindAsync<SavedToken>(f => f.MeetHash == meetHash);

            if (savedToken == null)
            {
                return;
            }

            await Database.DeleteAsync<SavedToken>(meetHash);
            MessagingCenter.Send<SavedToken>(savedToken, SavedToken.TOKEN_REMOVED_MESSAGE);
        }

        public async Task<IEnumerable<SavedToken>> GetTokenListAsync()
        {
            return await Database.Table<SavedToken>().ToListAsync();
        }
    }
}
