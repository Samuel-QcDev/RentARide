using RentARide.Database;
using RentARide.Models;
using SQLite;

public class RentARideDatabase
{
    private SQLiteAsyncConnection Database;

    private async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        await Database.CreateTableAsync<Membre>();
        await Database.CreateTableAsync<Auto>();
        await Database.CreateTableAsync<Moto>();
        await Database.CreateTableAsync<Station>();
        await Database.CreateTableAsync<Vehicule>();
        await Database.CreateTableAsync<Velo>();
    }

    public async Task<int> SaveMembre(Membre membre)
    {
        await Init();
        if (membre.MembreId != 0)
        {
            return await Database.UpdateAsync(membre);
        }
        else
        {
            return await Database.InsertAsync(membre);
        }
    }

    public async Task<List<Membre>> GetMembres()
    {
        await Init();
        return await Database.Table<Membre>().ToListAsync();
    }
}
