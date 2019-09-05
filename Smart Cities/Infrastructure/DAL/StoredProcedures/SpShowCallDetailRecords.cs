﻿namespace Infrastructure.DAL.StoredProcedures
{
    using SmartCities.ApplicationCore.DTOs;
    using SmartCities.Infrastructure.DAL;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    internal class SpShowCallDetailRecords
    {
        public static async Task<IEnumerable<CallsFromLocationResultDTO>> Execute(
              bool includeMale,
              bool includeFemale,
              bool includeUnknowGender,
              bool include_18_to_25,
              bool include_26_to_35,
              bool include_36_to_45,
              bool include_46_to_65,
              bool include_66_to_100,
              DateTime? startDate)
        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spShowCallDetailRecords";

                    cmd.Parameters.AddWithValue("@IncludeMale", includeMale);
                    cmd.Parameters.AddWithValue("@IncludeFemale", includeFemale);
                    cmd.Parameters.AddWithValue("@IncludeUnknowGender", includeUnknowGender);
                    cmd.Parameters.AddWithValue("@Include_18_to_25", include_18_to_25);
                    cmd.Parameters.AddWithValue("@Include_26_to_35", include_26_to_35);
                    cmd.Parameters.AddWithValue("@Include_36_to_45", include_36_to_45);
                    cmd.Parameters.AddWithValue("@Include_46_to_65", include_46_to_65);
                    cmd.Parameters.AddWithValue("@Include_66_to_100", include_66_to_100);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);

                    var result = new List<CallsFromLocationResultDTO>();

                    var reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        result.Add(new CallsFromLocationResultDTO()
                        {
                            CellLat = (decimal)reader["cellLat"],
                            CelLong = (decimal)reader["cellLong"],
                            Count = (int)reader["count"],
                        });
                    }

                    return result;
                }
            }
        }
    }
}
