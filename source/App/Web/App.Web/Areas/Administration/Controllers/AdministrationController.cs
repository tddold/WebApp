using App.Common;
using App.Web.Controllers;
using System.Web.Mvc;

namespace App.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {        
    }
}