﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geonorge.Forvaltningsinformasjon.Core.Abstractions.Services;
using Geonorge.Forvaltningsinformasjon.Web.Abstractions.Common.Helpers;
using Geonorge.Forvaltningsinformasjon.Web.Models.FkbData.DataContent;
using Microsoft.AspNetCore.Mvc;

namespace Geonorge.Forvaltningsinformasjon.Web.Controllers.FkbData.DataContent
{
    [Route("fkb-data/data-content/data-age-distribution")]
    public class DataAgeDistributionController : Controller
    {
        private IContextViewModelHelper _contextViewModelHelper;
        private IDataAgeDistributionService _dataAgeDistributionService;
        private ICountyService _countyService;
        private IMunicipalityService _municipalityService;
        private ApplicationSettings _applicationSettings;

        public DataAgeDistributionController(
            IContextViewModelHelper contextViewModelHelper,
            IDataAgeDistributionService dataAgeDistributionService,
            ICountyService countyService,
            IMunicipalityService municipalityService,
            ApplicationSettings applicationSettings)
        {
            _contextViewModelHelper = contextViewModelHelper;
            _dataAgeDistributionService = dataAgeDistributionService;
            _countyService = countyService;
            _municipalityService = municipalityService;
            _applicationSettings = applicationSettings;
        }

        public IActionResult Country()
        {
            ViewBag.ContextViewModel = _contextViewModelHelper.Create();

            DataAgeDistributionViewModel model = new DataAgeDistributionViewModel(_dataAgeDistributionService.Get(), _applicationSettings.AgeCategoryColors)
            {
                Type = DataAgeDistributionViewModel.AdministrativeUnitType.Country
            };
            return View("Views/FkbData/DataContent/Aspects/DataAgeDistribution/Index.cshtml", model);
        }

        [HttpGet("county")]
        public IActionResult County([FromQuery]int id)
        {
            ViewBag.ContextViewModel = _contextViewModelHelper.Create(_contextViewModelHelper.Id2Key(id, true));

            DataAgeDistributionViewModel model = new DataAgeDistributionViewModel(_dataAgeDistributionService.GetByCounty(id), _applicationSettings.AgeCategoryColors)
            {
                AdministrativeUnitName = _countyService.Get(id).Name,
                Type = DataAgeDistributionViewModel.AdministrativeUnitType.County
            };
            return View("Views/FkbData/DataContent/Aspects/DataAgeDistribution/Index.cshtml", model);
        }

        [HttpGet("municipality")]
        public IActionResult Municipality([FromQuery]int id)
        {
            ViewBag.ContextViewModel = _contextViewModelHelper.Create(_contextViewModelHelper.Id2Key(id, false));

            DataAgeDistributionViewModel model = new DataAgeDistributionViewModel(_dataAgeDistributionService.GetByMunicipality(id), _applicationSettings.AgeCategoryColors)
            {
                AdministrativeUnitName = _municipalityService.Get(id).Name,
                Type = DataAgeDistributionViewModel.AdministrativeUnitType.Municipality
            };
            return View("Views/FkbData/DataContent/Aspects/DataAgeDistribution/Index.cshtml", model);
        }
    }
}