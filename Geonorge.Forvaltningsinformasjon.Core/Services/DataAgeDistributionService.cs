﻿using Geonorge.Forvaltningsinformasjon.Core.Abstractions.DataAccess;
using Geonorge.Forvaltningsinformasjon.Core.Abstractions.Entities;
using Geonorge.Forvaltningsinformasjon.Core.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geonorge.Forvaltningsinformasjon.Core.Services
{
    class DataAgeDistributionService : IDataAgeDistributionService
    {
        private IRepository _repository;

        public DataAgeDistributionService(IRepository repository)
        {
            _repository = repository;
        }
   
        public List<IDataAgeDistribution> Get()
        {
            return _repository.DataAgeDistributions.Get();
        }

        public IDataAgeDistribution Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<IDataAgeDistribution> GetByCounty(int id)
        {
            return _repository.DataAgeDistributions.GetByCounty(id);
        }

        public List<IDataAgeDistribution> GetByMunicipality(int id)
        {
            return _repository.DataAgeDistributions.GetByMunicipality(id);
        }
    }
}
