using _20GRPED.MVC1.TP2.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace _20GRPED.MVC1.TP2.Repositories
{
    public class CalculatorHistoryRepository
    {
        private readonly string _connectionString;

        public CalculatorHistoryRepository(
            IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("MdfConnectionString");
        }

        public void Insert(CalculatorModel calculator)
        {
            var cmdText = "INSERT INTO CalculatorHistory" +
                "		(Operator, LeftNumber, RightNumber, Result, Hora)" +
                "VALUES	(@operator, @leftNumber, @rightNumber, @result, @hora);";

            using (var sqlConnection = new SqlConnection(_connectionString)) //já faz o close e dispose
            using (var sqlCommand = new SqlCommand(cmdText, sqlConnection)) //já faz o close
            {
                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters
                    .Add("@operator", SqlDbType.VarChar).Value = calculator.Operator;
                sqlCommand.Parameters
                    .Add("@leftNumber", SqlDbType.Decimal).Value = calculator.Left;
                sqlCommand.Parameters
                    .Add("@rightNumber", SqlDbType.Decimal).Value = calculator.Right;
                sqlCommand.Parameters
                    .Add("@result", SqlDbType.VarChar).Value = calculator.Result;
                sqlCommand.Parameters
                    .Add("@hora", SqlDbType.DateTime).Value = DateTime.Now;

                sqlConnection.Open();

                var resutScalar = sqlCommand.ExecuteScalar();
            }
        }

        public IEnumerable<CalculatorModel> GetAll()
        {
            var cmdText = $"SELECT " +
                $"Id as '{nameof(CalculatorModel.Id)}', " +
                $"Operator as '{nameof(CalculatorModel.Operator)}', " +
                $"LeftNumber as '{nameof(CalculatorModel.Left)}', " +
                $"RightNumber as '{nameof(CalculatorModel.Right)}', " +
                $"Result as '{nameof(CalculatorModel.Result)}', " +
                $"Hora as '{nameof(CalculatorModel.Hora)}' " +
                $"FROM CalculatorHistory ORDER BY Hora DESC";

            var history = new List<CalculatorModel>();

            using (var sqlConnection = new SqlConnection(_connectionString)) //já faz o close e dispose
            using (var sqlCommand = new SqlCommand(cmdText, sqlConnection)) //já faz o close
            {
                sqlCommand.CommandType = CommandType.Text;

                sqlConnection.Open();

                using (var reader = sqlCommand.ExecuteReader())
                {
                    var idColumnIndex = reader.GetOrdinal(nameof(CalculatorModel.Id));
                    var operatorColumnIndex = reader.GetOrdinal(nameof(CalculatorModel.Operator));
                    var leftNumberColumnIndex = reader.GetOrdinal(nameof(CalculatorModel.Left));
                    var rightNumberColumnIndex = reader.GetOrdinal(nameof(CalculatorModel.Right));
                    var resultColumnIndex = reader.GetOrdinal(nameof(CalculatorModel.Result));
                    var horaColumnIndex = reader.GetOrdinal(nameof(CalculatorModel.Hora));
                    while (reader.Read())
                    {
                        var id = reader.GetFieldValue<int>(idColumnIndex);
                        var @operator = reader.GetFieldValue<string>(operatorColumnIndex);
                        var left = reader.GetFieldValue<decimal>(leftNumberColumnIndex);
                        var right = reader.GetFieldValue<decimal>(rightNumberColumnIndex);
                        var result = reader.GetFieldValue<string>(resultColumnIndex);
                        var hora = reader.GetFieldValue<DateTime>(horaColumnIndex);

                        var entry = new CalculatorModel
                        {
                            Id = id,
                            Operator = @operator,
                            Left = left,
                            Right = right,
                            Result = result,
                            Hora = hora
                        };
                        history.Add(entry);
                    }
                }
            }

            return history;
        }
    }
}
