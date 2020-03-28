using ADO.DataAccessHelper;
using eMids.QA.Application.Common;
using eMids.QA.Application.DataAccess.Contracts;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace eMids.QA.Application.DataAccess.Patient
{
    public class PatientDataAccess : IPatientDataAccess
    {
        public List<QA.Application.Common.Patient> GetPatientList()
        {
            List<QA.Application.Common.Patient> patientList = null;
            patientList = DataAccess<MySqlClientFactory>
                .ExecuteReaderProcedure("Sp_GetPatientList",
                (reader) =>
                {
                    if (reader.HasRows)
                    {
                        patientList = new List<QA.Application.Common.Patient>();
                        while (reader.Read())
                        {
                            patientList.Add(new QA.Application.Common.Patient
                            {
                                PatientId = ConverterHelper.ConvertIntColumnValue(reader["PatientId"]),
                                FirstName = ConverterHelper.GetStringValue(reader["FirstName"]),
                                LastName = ConverterHelper.GetStringValue(reader["LastName"]),
                                MemberId = ConverterHelper.GetStringValue(reader["MemberId"])
                            });
                        }
                    }
                    return patientList;
                }, null);
            return patientList;
        }

        public void Create(QA.Application.Common.Patient patient)
        {
            try
            {
                MySqlParameter[] parameters = new MySqlParameter[3];
                parameters[0] = new MySqlParameter()
                {
                    ParameterName = "@FirstName",
                    Value = patient.FirstName,
                    DbType = DbType.String
                };
                parameters[1] = new MySqlParameter()
                {
                    ParameterName = "@LastName",
                    Value = patient.LastName,
                    DbType = DbType.String
                };
                parameters[2] = new MySqlParameter()
                {
                    ParameterName = "@MemberId",
                    Value = patient.MemberId,
                    DbType = DbType.String
                };

                DataAccess<MySqlClientFactory>
                     .ExecuteProcedure("Sp_SavePatient", parameters);
            }
            catch
            {

                throw;
            }
        }

        public void Edit(QA.Application.Common.Patient patient)
        {
            try
            {
                MySqlParameter[] parameters = new MySqlParameter[4];
                parameters[0] = new MySqlParameter()
                {
                    ParameterName = "@PatientId",
                    Value = patient.PatientId,
                    DbType = DbType.Int32
                };
                parameters[1] = new MySqlParameter()
                {
                    ParameterName = "@FirstName",
                    Value = patient.FirstName,
                    DbType = DbType.String
                };
                parameters[2] = new MySqlParameter()
                {
                    ParameterName = "@LastName",
                    Value = patient.LastName,
                    DbType = DbType.String
                };
                parameters[3] = new MySqlParameter()
                {
                    ParameterName = "@MemberId",
                    Value = patient.MemberId,
                    DbType = DbType.String
                };

                DataAccess<MySqlClientFactory>
                     .ExecuteProcedure("Sp_UpdatePatient", parameters);
            }
            catch
            {

                throw;
            }
        }

        public void Delete(int patientId)
        {
            try
            {
                MySqlParameter[] parameters = new MySqlParameter[1];
                parameters[0] = new MySqlParameter()
                {
                    ParameterName = "@PatientId",
                    Value = patientId,
                    DbType = DbType.Int32
                };

                DataAccess<MySqlClientFactory>
                     .ExecuteProcedure("Sp_DeletePatient", parameters);
            }
            catch
            {

                throw;
            }
        }

        public QA.Application.Common.Patient GetById(int patientId)
        {
            try
            {
                MySqlParameter[] parameters = new MySqlParameter[1];
                parameters[0] = new MySqlParameter()
                {
                    ParameterName = "@PatientId",
                    Value = patientId,
                    DbType = DbType.Int32
                };

                QA.Application.Common.Patient patient = null;
                patient = DataAccess<MySqlClientFactory>
                    .ExecuteReaderProcedure("Sp_GetPatientById",
                    (reader) =>
                    {
                        if (reader.HasRows)
                        {
                            patient = new QA.Application.Common.Patient();
                            while (reader.Read())
                            {
                                patient = (new QA.Application.Common.Patient
                                {
                                    PatientId = ConverterHelper.ConvertIntColumnValue(reader["PatientId"]),
                                    FirstName = ConverterHelper.GetStringValue(reader["FirstName"]),
                                    LastName = ConverterHelper.GetStringValue(reader["LastName"]),
                                    MemberId = ConverterHelper.GetStringValue(reader["MemberId"])
                                });
                            }
                        }
                        return patient;
                    }, parameters);
                return patient;
            }
            catch
            {

                throw;
            }
        }
    }
}
