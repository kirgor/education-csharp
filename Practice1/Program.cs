using System;
using System.Data.SqlClient;

namespace Practice1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // строка подключения к базе данных, для этого вы должны создать
            // на вашем эеземпляре базу
            SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();

            connectionString.DataSource = @"ALEX-PC"; // путь к экземпляру, у вас скорее всего .\SQLEXPRESS
            connectionString.InitialCatalog = "TestDB"; // имя вышей БД
            connectionString.IntegratedSecurity = true;

            // создаем подключение и открываем его
            SqlConnection connection = new SqlConnection(connectionString.ToString());
            connection.Open();

            // запрос на создание таблицы
            const string sqlCreateTable =
                @"
                CREATE TABLE Person
                (
                    ID int IDENTITY(1,1),
                    Name varchar(10) NOT NULL,
                    Age int NULL,
                    Sex bit NOT NULL
                )
                ";

            // создаем пустую команду
            SqlCommand command = connection.CreateCommand();

            try
            {
                // записываем в команду запрос
                command.CommandText = sqlCreateTable;
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Table person already exists");
            }

            // заполняем таблицу данными
            command.CommandText = "INSERT INTO Person (Name, Age, Sex) VALUES ('Kirill', 22, 1)";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Person (Name, Age, Sex) VALUES ('Alex', 23, 1)";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Person (Name, Sex) VALUES ('Valya', 0)";
            command.ExecuteNonQuery();
            command.CommandText = "INSERT INTO Person (Name, Sex) VALUES ('Rashid', 1)";
            command.ExecuteNonQuery();

            // создаем запрос на получение данных и записываем его в команду
            command.CommandText = "SELECT * FROM Person";

            // выполняем запрос и получаем какие-то результаты
            SqlDataReader reader = command.ExecuteReader();

            // пока есть еще результаты читаем
            while (reader.Read())
            {
                string name = (string)reader.GetValue(1); // получаем Name
                object ageNull = reader.GetValue(2); // получаем age
                object age = ageNull == DBNull.Value ? null : (int?)ageNull; // age может быть sql NULL'ом
                bool sex = reader.GetBoolean(3); // получаем Sex

                // выводим данные
                Console.WriteLine("Name: {0}; Age: {1}; Sex: {2}.", name, age ?? "?", sex ? "Men" : "Women");
            }

            // закрываем соединение
            connection.Close();

            // ждем нажатия клавиши
            Console.ReadKey(true);
        }
    }
}