using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service
{
    internal class DBWork
    {
        static private string dbname = "Servis.db";
        static private string path = $"Data Source={dbname};";

        //CREATE TABLE  IF NOT EXISTS Mechanic(
        //id INTEGER PRIMARY KEY AUTOINCREMENT,
        //number INTEGER,
        //name VARCHAR);


        //INSERT INTO Mechanic (number, name) VALUES 
        //(1,'Иванов'),
        //(2,'Петров'),
        //(3,'Сидоров'),
        //(4,'Стрельцов);

        //        CREATE TABLE  IF NOT EXISTS Jobs(
        //          Jobs_id INTEGER PRIMARY KEY AUTOINCREMENT,
        //          number INTEGER,
        //name VARCHAR,
        //standartHours REAL,
        //cost DECIMAL,
        //client VARCHAR,
        //Mechanic_ID INTEGER,
        //FOREIGN KEY(Mechanic_ID) REFERENCES Mechanic(id) );


        /*INSERT INTO Jobs (number,name,standartHours,cost, client, Mechanic_id) VALUES
        (1,'Прокачака тормозной системы', 1.5, 3000, 'а001мр',1),


        (2,'Замена масла', 1, 3000, 'а004мр',3),


        (3,'Консультация', 0.5, 3000, 'а003мр',2),


        (4,'Замена лампочки', 0.7, 3000, 'а002мр',4);*/



        static public bool MakeDB(string _dbname = "Servis.db")
{


    bool result = false;
    string path = $"Data Source={_dbname};";
    string create_table_mechanic = "CREATE TABLE IF NOT EXISTS " +
                "Mechanic " +
                " (id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                " number INTEGER," +
                " name VARCHAR);";
        
    string init_data_mechanic = "INSERT INTO Mechanic (number, name) " +
                "VALUES " +
                "(1, 'Иванов')," +
                "(2, 'Петров')," +
                "(3, 'Сидоров')," +
                "(4, 'Стрельцов');";

    string create_table_jobs = "CREATE TABLE IF NOT EXISTS " +
                "Jobs " +
                "(Jobs_id INTEGER PRIMARY KEY AUTOINCREMENT," +
                "number INTEGER," +
                "name VARCHAR," +
                "standartHours REAL," +
                "cost DECIMAL," +
                "client VARCHAR," +
                "Mechanic_ID INTEGER," +
                "FOREIGN KEY(Mechanic_ID) REFERENCES Mechanic(id));";
    string init_data_jobs = "INSERT INTO Jobs "+" (number,name,standartHours,cost,"+
                " client, Mechanic_id) "+
                "VALUES " +
                " (1,'Прокачака тормозной системы', 1.5, 3000, 'а001мр',1)," +
                " (2,'Замена масла', 1, 3000, 'а004мр',3)," +
                " (3,'Консультация', 0.5, 3000, 'а003мр',2)," +
                " (4,'Замена лампочки', 0.7, 3000, 'а002мр',4);";



    SQLiteConnection conn = new SQLiteConnection(path);
    SQLiteCommand cmd01 = conn.CreateCommand();
    SQLiteCommand cmd02 = conn.CreateCommand();
    SQLiteCommand cmd03 = conn.CreateCommand();
    SQLiteCommand cmd04 = conn.CreateCommand();

    cmd01.CommandText = create_table_mechanic;
    cmd02.CommandText = init_data_mechanic;
    cmd03.CommandText = create_table_jobs;
    cmd04.CommandText = init_data_jobs;


    conn.Open();
    cmd01.ExecuteNonQuery();
    cmd02.ExecuteNonQuery();
    cmd03.ExecuteNonQuery();
    cmd04.ExecuteNonQuery();

    conn.Close();
    result = true;
    return result;
}

static public List<string> GetMechanics()
        {
            List<string> result = new List<string>();
            string get_mechanics = "SELECT name  FROM Mechanic";
            using (SQLiteConnection conn = new SQLiteConnection(path))
            {
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = get_mechanics;
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                }

            }

                return result;
        }
static public void AddData(string _newCategoryInsert, string _dbname = "Servis.db")
{
    string path = $"Data Source={_dbname};";
    using (SQLiteConnection conn = new SQLiteConnection(path))
    {

        SQLiteCommand cmd = new SQLiteCommand(conn);
        //conn.ConnectionString = path;
        cmd.CommandText = _newCategoryInsert;
        conn.Open();
        cmd.ExecuteNonQuery();

    }
}
static public DataSet Refresh(string _dbname =  "Servis.db")
{
    DataSet result = new DataSet();
    string path = $"Data Source={_dbname};";
    string show_all_data = "SELECT * FROM Category;";
    using (SQLiteConnection conn = new SQLiteConnection(path))
    {
        conn.Open();
        SQLiteDataAdapter adapter = new SQLiteDataAdapter(show_all_data, conn);
        adapter.Fill(result);
    }
    return result;

}
static public void Save(DataTable dt, out string _query, string _dbname = "Servis.db")
{
    string path = $"Data Source={_dbname};";
    string show_all_data = "SELECT * FROM Category;";
    using (SQLiteConnection conn = new SQLiteConnection(path))
    {
        conn.Open();
        SQLiteDataAdapter adapter = new SQLiteDataAdapter(show_all_data, conn);
        SQLiteCommandBuilder commandBulder = new SQLiteCommandBuilder(adapter);
        adapter.Update(dt);
        _query = commandBulder.GetUpdateCommand().CommandText;
    }

}

}
}
