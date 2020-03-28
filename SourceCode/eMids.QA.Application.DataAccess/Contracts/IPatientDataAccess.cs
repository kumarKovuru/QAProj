using System;
using System.Collections.Generic;
using System.Text;

namespace eMids.QA.Application.DataAccess.Contracts
{
    public interface IPatientDataAccess
    {
        List<Common.Patient> GetPatientList();
        void Create(Common.Patient patient);
        void Edit(QA.Application.Common.Patient patient);
        void Delete(int patientId);
        QA.Application.Common.Patient GetById(int patientId);
    }
}
