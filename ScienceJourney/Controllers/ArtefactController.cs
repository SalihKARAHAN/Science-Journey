﻿using log4net;
using ScienceJourney.DAL;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace ScienceJourney.Controllers
{
    public class ArtefactController : Controller
    {
        private ScienceJourneyEntities2 context = new ScienceJourneyEntities2();
        static ILog log = log4net.LogManager.GetLogger(typeof(ArtefactController));
        //
        // GET: /Artefact/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetArtefacts()
        {
            try
            {
                var artefacts = (from u in context.Artefacts
                                 select new
                                 {
                                     ArtefactName = u.ArtefactName,
                                     ArtefactDescription = u.ArtefactDescription,
                                     ArtefactID = u.ArtefactID,
                                     MuseumID = u.MuseumID
                                 }).ToList();

                return Json(artefacts, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Info(String.Format("Exception occurred" + MethodBase.GetCurrentMethod()));
                log.Error(ex.Message);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}