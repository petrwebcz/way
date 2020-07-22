using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhereAreYou.MobileApp.Models;

namespace WhereAreYou.MobileApp.Services
{
    public class TokenDatabase
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

        public async Task AddTokenAsync(SavedToken token)
        {
            await Database.InsertOrReplaceAsync(token);
        }

        public async Task RemoveTokenAsync(SavedToken token)
        {
            await Database.InsertOrReplaceAsync(token);
        }

        public async Task<IEnumerable<SavedToken>> GetTokenListAsync()
        {
            return await Database.Table<SavedToken>().ToListAsync();
        }
    }
}
