using _20GRPED.MVC1.TP2.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace _20GRPED.MVC1.TP2.Repositories
{
    public class CalculatorHistoryRepository
    {
        private readonly string _connectionString;

        public CalculatorHistoryRepository()
        {
            _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\felipe.andrade\source\repos\20GRPED.MVC1.CalculadoraLog\20GRPED.MVC1.TP2\20GRPED.MVC1.TP2\App_data\Calculadora.mdf;Integrated Security=True;Connect Timeout=30";
        }

        public void Insert(CalculatorModel calculator)
        {
            var cmdText = "INSERT INTO CalculatorHistory" +
                "		(Operator, LeftNumber, RightNumber, Result)" +
                "VALUES	(@operator, @leftNumber, @rightNumber, @result);";

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

                sqlConnection.Open();

                var resutScalar = sqlCommand.ExecuteScalar();
            }
        }

        public IEnumerable<CalculatorModel> GetAll()
        {
            var cmdText = $"SELECT Id, Operator, LeftNumber, RightNumber, Result " +
                $"FROM CalculatorHistory";

            var history = new List<CalculatorModel>();

            using (var sqlConnection = new SqlConnection(_connectionString)) //já faz o close e dispose
            using (var sqlCommand = new SqlCommand(cmdText, sqlConnection)) //já faz o close
            {
                sqlCommand.CommandType = CommandType.Text;

                sqlConnection.Open();

                using (var reader = sqlCommand.ExecuteReader())
                {
                    var idColumnIndex = reader.GetOrdinal("ID");
                    var operatorColumnIndex = reader.GetOrdinal("Operator");
                    var leftNumberColumnIndex = reader.GetOrdinal("LeftNumber");
                    var rightNumberColumnIndex = reader.GetOrdinal("RightNumber");
                    var resultColumnIndex = reader.GetOrdinal("Result");
                    while (reader.Read())
                    {
                        var id = reader.GetFieldValue<int>(idColumnIndex);
                        var @operator = reader.GetFieldValue<string>(operatorColumnIndex);
                        var left = reader.GetFieldValue<decimal>(leftNumberColumnIndex);
                        var right = reader.GetFieldValue<decimal>(rightNumberColumnIndex);
                        var result = reader.GetFieldValue<string>(resultColumnIndex);

                        var entry = new CalculatorModel
                        {
                            Id = id,
                            Operator = @operator,
                            Left = left,
                            Right = right,
                            Result = result
                        };
                        history.Add(entry);
                    }
                }
            }

            return history;
        }
    }
}
