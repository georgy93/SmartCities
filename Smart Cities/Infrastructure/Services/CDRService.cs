namespace SmartCities.Infrastructure.Services
{
    using ApplicationCore.DTOs;
    using ApplicationCore.Services;
    using Infrastructure.DAL;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public class CDRService : ICDService
    {
        public async Task<IEnumerable<CallsFromLocationResultDTO>> GetCDRDataAsync(
            CallsFromLocationSearchDTO searchDto)
        {
            using (SqlConnection connection = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandTimeout = 120;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = StoredProcedures.SpShowCallDetailRecords;

                    cmd.Parameters.AddWithValue("@IncludeMale", searchDto.IncludeMale);
                    cmd.Parameters.AddWithValue("@IncludeFemale", searchDto.IncludeFemale);
                    cmd.Parameters.AddWithValue("@IncludeUnknowGender", searchDto.IncludeUnknowGender);
                    cmd.Parameters.AddWithValue("@Include_18_to_25", searchDto.Include_18_to_25);
                    cmd.Parameters.AddWithValue("@Include_26_to_35", searchDto.Include_26_to_35);
                    cmd.Parameters.AddWithValue("@Include_36_to_45", searchDto.Include_36_to_45);
                    cmd.Parameters.AddWithValue("@Include_46_to_65", searchDto.Include_46_to_65);
                    cmd.Parameters.AddWithValue("@Include_66_to_100", searchDto.Include_66_to_100);
                    cmd.Parameters.AddWithValue("@StartDate", searchDto.StartDate);

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
