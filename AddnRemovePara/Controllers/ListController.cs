using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AddnRemovePara.Models;
using System.ComponentModel;
using AddnRemovePara.ViewModel;
using System.Text;
using System.Reflection;

namespace AddnRemovePara.Controllers
{

    /// <summary>
    /// Class to select the action based on the button pressed from the front page
    /// </summary>
    public class ButtonSelector : ActionNameSelectorAttribute
    {
        public string BtnName { get; set; }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            var value = controllerContext.Controller.ValueProvider.GetValue(BtnName);

            if (value == null)
            {
                return false;
            }
            else
            {
                return true;
            }
           
        }
    }

   
    public class ListController : Controller
    {
        // GET: List
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Action method for the button Add that is used to Add items from the left List to the right List of the view "ShowPara"
        /// </summary>
        /// <param name="pModel"></param>
        /// <returns></returns>
        [ButtonSelector(BtnName = "Add")]
        public ActionResult Add(ParaViewModel pModel)
        {
            LawDBEntities objLaw = new LawDBEntities();

            if(pModel.SelectedParaLeftID!=null)
            {
                foreach (var item in pModel.SelectedParaLeftID.Distinct())
                {
                    objLaw.SP_ProcMove("ADD", item);
                }

                objLaw.SaveChanges();
            }

            //calls the method getUpdatedList that Gets the updated RightPara list and LeftPara list from the database
            pModel = getUpdatedList(pModel,objLaw);

            return View(pModel);
        }


        /// <summary>
        ///  Action method for the button Remove that is used to Remove items from the right List back to the left List of the view "ShowPara"
        /// </summary>
        /// <param name="pModel"></param>
        /// <returns></returns>
        [ButtonSelector(BtnName = "Remove")]
        public ActionResult Remove(ParaViewModel pModel)
        {
            LawDBEntities objLaw = new LawDBEntities();

            if(pModel.SelectedParaRightID!=null)
            {
                foreach (var item in pModel.SelectedParaRightID.Distinct())
                {
                    objLaw.SP_ProcMove("REMOVE", item);
                }

                objLaw.SaveChanges();
            }

            //calls the method getUpdatedList that Gets the updated RightPara list and LeftPara list from the database
            pModel = getUpdatedList(pModel, objLaw);

            return View(pModel);
            
        }

        [ButtonSelector(BtnName = "Submit")]
        public ActionResult Submit(ParaViewModel pModel)
        {
            LawDBEntities objLaw = new LawDBEntities();

            pModel = getUpdatedList(pModel, objLaw);

            if(pModel.paraRightList.Count()>0)
            {
                foreach (var item in pModel.paraRightList)
                {

                    pModel.ParaSelectedList = (from x in objLaw.tblParas
                                               where x.ParaID == item.Value
                                               select x.ParaText).ToList();
                }


                StringBuilder sb = new StringBuilder();

                foreach (var item in pModel.ParaSelectedList)
                {
                    sb.Append(item);
                    sb.Append('\n');
                }

                pModel.ParaListForTextArea = sb.ToString();
            }
            


            return View(pModel);
        }


        /// <summary>
        /// Makes DB calls to fetch the updated data from the tables tblParaLeft and tblParaRight
        /// </summary>
        /// <param name="pVM"></param>
        /// <param name="objLaw"></param>
        /// <returns></returns>
        public ParaViewModel getUpdatedList(ParaViewModel pVM, LawDBEntities objLaw)
        {
            pVM.paraLeftList = objLaw.tblParaLefts
                   .ToList<tblParaLeft>()
                   .Select(x => new SelectListItem
                   {
                       Value = x.ParaID,
                       Text = x.ParaID
                   });

            pVM.paraRightList = objLaw.tblParaRights
                  .ToList<tblParaRight>()
                  .Select(x => new SelectListItem
                  {
                      Value = x.ParaID,
                      Text = x.ParaID
                  });

            return pVM;
        }

        /// <summary>
        /// The method that gets fired at the page load of the "showPara" view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ShowPara()
        {
                ParaViewModel paraVM = new ParaViewModel();

                //ParaDAL objDal = new ParaDAL();

                LawDBEntities objLaw = new LawDBEntities();

                //executes the stored proc sp_ProcInitialize
                objLaw.sp_ProcInitialize();

                //Loads the table tblParaLeft into the paraLeftList
                //List<tblParaLeft> paraLeftList = new List<tblParaLeft>();

                paraVM.paraLeftList = objLaw.tblParaLefts
                        .ToList<tblParaLeft>()
                        .Select(x => new SelectListItem
                        {
                            Value = x.ParaID,
                            Text = x.ParaID
                        });

                paraVM.paraRightList = objLaw.tblParaRights
                       .ToList<tblParaRight>()
                       .Select(x => new SelectListItem
                       {
                           Value = x.ParaID,
                           Text = x.ParaID
                       });
            

            return View(paraVM);
        }

      
    }
}