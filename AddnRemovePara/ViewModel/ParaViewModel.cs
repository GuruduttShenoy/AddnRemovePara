using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AddnRemovePara.Models;
using System.Web.Mvc;
using System.Text;

namespace AddnRemovePara.ViewModel
{
    public class ParaViewModel
    {

        public IEnumerable<tblPara> ParaList { get; set; }

        public IEnumerable<string> ParaSelectedList { get; set; }

        public string ParaListForTextArea { get; set; }
        //public List<tblParaLeft> paraLeftList { get; set; }

        public IEnumerable<string> SelectedParaLeftID { get; set; }

        public IEnumerable<string> SelectedParaRightID { get; set; }

        public IEnumerable<SelectListItem> paraLeftList { get; set; }

        public IEnumerable<SelectListItem> paraRightList { get; set; }
    }
}