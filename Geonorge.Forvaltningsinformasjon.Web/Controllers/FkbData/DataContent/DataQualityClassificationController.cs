﻿using Geonorge.Forvaltningsinformasjon.Core.Abstractions.Entities;
using Geonorge.Forvaltningsinformasjon.Core.Abstractions.Services;
using Geonorge.Forvaltningsinformasjon.Web.Abstractions.Common.Helpers;
using Geonorge.Forvaltningsinformasjon.Web.Models.FkbData.DataContent.DataQualityClassification;
using Microsoft.AspNetCore.Mvc;

namespace Geonorge.Forvaltningsinformasjon.Web.Controllers.FkbData.DataContent
{
    [Route("fkb-data/data-content/data-quality-classification")]
    public class DataQualityClassificationController : Controller
    {
        private IContextViewModelHelper _contextViewModelHelper;
        private IDataQualityClassificationService _dataQualityClassificationService;
        private ICountyService _countyService;
        private IMunicipalityService _municipalityService;

        public DataQualityClassificationController(
            IContextViewModelHelper contextViewModelHelper,
            IDataQualityClassificationService dataQualityClassificationService,
            ICountyService countyService,
            IMunicipalityService municipalityService)
        {
            _contextViewModelHelper = contextViewModelHelper;
            _dataQualityClassificationService = dataQualityClassificationService;
            _countyService = countyService;
            _municipalityService = municipalityService;
        }

        public IActionResult Country()
        {
            ViewBag.ContextViewModel = _contextViewModelHelper.Create();
            DataQualityClassificationModel model = new DataQualityClassificationModel
            {
                Classifications = _dataQualityClassificationService.Get()
            };

            return View("Views/FkbData/DataContent/Aspects/DataQualityClassification/Country.cshtml", model);
        }

        [HttpGet("county")]
        public IActionResult County([FromQuery]int id)
        {
            ViewBag.ContextViewModel = _contextViewModelHelper.Create(_contextViewModelHelper.Id2Key(id, true));
            ICounty county = _countyService.Get(id);

            DataQualityClassificationModel model = new DataQualityClassificationModel
            {
                Classifications = _dataQualityClassificationService.GetByCounty(id),
                AdministrativeUnitName = county.Name,
                AdministrativeUnitBBox = county as IBoundingBox
            };
            return View("Views/FkbData/DataContent/Aspects/DataQualityClassification/County.cshtml", model);
        }

        [HttpGet("municipality")]
        public IActionResult Municipality([FromQuery]int id)
        {
            ViewBag.ContextViewModel = _contextViewModelHelper.Create(_contextViewModelHelper.Id2Key(id, false));
            IMunicipality municipality = _municipalityService.Get(id);

            DataQualityClassificationModel model = new DataQualityClassificationModel
            {
                Classifications = _dataQualityClassificationService.GetByMunicipality(id),
                AdministrativeUnitName = municipality.Name,
                AdministrativeUnitBBox = municipality as IBoundingBox
            };
            return View("Views/FkbData/DataContent/Aspects/DataQualityClassification/Municipality.cshtml", model);
        }
    }
}